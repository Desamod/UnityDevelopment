using UnityEngine;
using System.Collections;

public class Obj_spawn : MonoBehaviour
{

	public GameObject[] array;
	public float delay;
	public float timer = 2.0f;

	// Use this for initialization
	void Start ()
	{
		delay = timer;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		delay = delay - Time.deltaTime;

		if (delay <= 0) {
			int num = Random.Range(0,1);
			Transform.Instantiate (array [num], transform.position, transform.rotation);
			delay = timer;
		}
	}
}

