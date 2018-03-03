using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_generation : MonoBehaviour {


	Rigidbody2D rd;

	float speed = 6.0f;
	// Use this for initialization
	void Start () {

		rd = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {


		Vector2 vel = rd.velocity;
		Vector2 pos = rd.position;
		if (pos.x < -15.0f) {
			Destroy (gameObject);
		} else {
			vel.x = -1 * speed;
			rd.velocity = vel;
		}
	}
}
