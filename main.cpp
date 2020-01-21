#include <iostream>
#include <pthread.h>
#include <vector>
#include <sstream>
#include <map>
#include <thread>

std::vector<pthread_t> consumers;
std::map<int,int> threadsID;

thread_local int psum = 0;

bool isFinished = false;
bool isDebugMode = false;
int sleep_time;
int counter = 1;
int threadsCount;

pthread_mutex_t shared_variable_mutex = PTHREAD_MUTEX_INITIALIZER;

pthread_cond_t consumer_notification = PTHREAD_COND_INITIALIZER;
pthread_cond_t producer_notification = PTHREAD_COND_INITIALIZER;

pthread_barrier_t all_threads_started;

int get_tid() {
  // 1 to 3+N thread ID
  return threadsID[pthread_self()];
}

void* producer_routine(void* arg) {
  // Wait for consumer to start
  // Read data, loop through each value and update the value, notify consumer, wait for consumer to process
    pthread_mutex_lock(&shared_variable_mutex);
    threadsID[pthread_self()] = counter;
    counter++;
    pthread_mutex_unlock(&shared_variable_mutex);

    pthread_barrier_wait(&all_threads_started);    
    int* number = static_cast<int*>(arg);
    std::string input;
    std::getline(std::cin, input);
    std::stringstream sin(input);
    while (sin >> *number) {
        pthread_mutex_lock(&shared_variable_mutex);
        pthread_cond_signal(&consumer_notification);

        while (*number != 0) {
            pthread_cond_wait(&producer_notification, &shared_variable_mutex);
        }

        pthread_mutex_unlock(&shared_variable_mutex);
    }

    pthread_mutex_lock(&shared_variable_mutex);
    isFinished = true;

    pthread_cond_broadcast(&consumer_notification);
    pthread_mutex_unlock(&shared_variable_mutex);
  return nullptr;
}
 
void* consumer_routine(void* arg) {
  // notify about start
  // for every update issued by producer, read the value and add to sum
  // return pointer to result (for particular consumer)
    int old_state;
    pthread_setcancelstate(PTHREAD_CANCEL_DISABLE, &old_state);
    pthread_mutex_lock(&shared_variable_mutex);
    threadsID[pthread_self()] = counter;
    counter++;
    pthread_mutex_unlock(&shared_variable_mutex);

    pthread_barrier_wait(&all_threads_started);

    auto number = static_cast<int*>(arg);

    while (!isFinished) {
        pthread_mutex_lock(&shared_variable_mutex);
        while (!isFinished && *number == 0) {
            pthread_cond_wait(&consumer_notification, &shared_variable_mutex);
        }
        if (!isFinished) {
           psum += *number;
           *number = 0;
           if(isDebugMode) 
               std::cout << "tid, psum: " << get_tid() << ", " << psum << std::endl;
		   pthread_cond_signal(&producer_notification);
        }

        pthread_mutex_unlock(&shared_variable_mutex);
        usleep(rand() % (sleep_time + 1));
    }
    auto result = new int(psum);
return result;
}
 
void* consumer_interruptor_routine(void* arg) {
  // wait for consumers to start
  // interrupt random consumer while producer is running 
    pthread_mutex_lock(&shared_variable_mutex);
    threadsID[pthread_self()] = counter;
    counter++;
    pthread_mutex_unlock(&shared_variable_mutex);

    pthread_barrier_wait(&all_threads_started);

    while (!isFinished) {
         pthread_cancel(consumers[rand() % threadsCount]);
    }                                        
}
 
int run_threads() {
  // start N threads and wait until they're done
  // return aggregated sum of values
    threadsID[pthread_self()] = counter;
    counter++;
    //srand(time(nullptr));
    pthread_barrier_init(&all_threads_started, nullptr, threadsCount + 3);
    int shared_variable = 0;

    pthread_t producer;
    pthread_create(&producer, nullptr, producer_routine, &shared_variable);

    consumers.resize(threadsCount);
    for (pthread_t& consumer : consumers) {
        pthread_create(&consumer, nullptr, consumer_routine, &shared_variable);
    }

    pthread_t interrupter;
    pthread_create(&interrupter, nullptr, consumer_interruptor_routine, nullptr);

	pthread_barrier_wait(&all_threads_started);
    pthread_barrier_destroy(&all_threads_started);
    pthread_join(producer, nullptr);
    pthread_join(interrupter, nullptr);

    int result = 0;
    int* return_value;
    for (pthread_t& consumer : consumers) {
        pthread_join(consumer, (void**) &return_value);
        result += *return_value;
        delete return_value;
    }

    pthread_mutex_destroy(&shared_variable_mutex);
    pthread_cond_destroy(&consumer_notification);
    pthread_cond_destroy(&producer_notification);

  return result;
}
 
bool isDebugKey(std::string arg) {
    if (arg == "--debug") return true;
 return false; 
}
 
int main(int argc, char *argv[]) {
    threadsCount = std::stoi(argv[1]);
    sleep_time = std::stoi(argv[2]);
    if(argv[3] != NULL) {
       isDebugMode = isDebugKey(std::string(argv[3]));
    }
    std::cout << run_threads() << std::endl;
    return 0;
}
