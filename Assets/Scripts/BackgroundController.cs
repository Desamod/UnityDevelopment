using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	public float speed = 0.5f;
	
	// Update is called once per frame
	void Update () {

		Vector2 offset = new Vector2 (Time.time * speed, 0);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;
		if (speed <= 0.2f) 
		   speed = speed + 0.000025f;
	}


}
