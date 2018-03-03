using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_generation : MonoBehaviour {


	Rigidbody2D rd;
	//float speed = 6.0f;
	GameObject player;
	private float regulation = 200;
	// Use this for initialization
	void Start () {
		rd = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.tag = "Enemy";
		//Vector2 vel = rd.velocity;
		float vel;
		Vector2 pos = rd.position;
		if (pos.x < -14.0f) {
			Destroy (gameObject);
		} else if (PlayerManager.isAlive == true) {
			vel = regulation * player.GetComponent<PlayerManager>().Speed;
			transform.position = new Vector3(transform.position.x - vel , transform.position.y,transform.position.z);
			//vel.x = -regulation * player.GetComponent<PlayerManager>().Speed; //speed
			//rd.velocity = vel;
		} else {
			//rd.velocity = new Vector2 (0,0);
		}
	}
}
