using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	GameObject player;
	void Start () {
		switch (GlobalParameters.id_player)
		{
		  case 1: 
			gameObject.AddComponent<SquarePlayer> ();
			break; 
		  case 2: 
			gameObject.AddComponent<BallPlayer> ();
			break; 
		  case 3: 
			gameObject.AddComponent<TrianglePlayer> ();
			break; 
		}

		player = GameObject.FindGameObjectWithTag("Player");

		switch (GlobalParameters.id_level)
		{
		case 1: 
			player.GetComponent<PlayerManager> ().Gravity = 11.8f;
			break; 
		case 2: 
			player.GetComponent<PlayerManager> ().Gravity = 9.8f;
			break; 
		case 3: 
			player.GetComponent<PlayerManager> ().Gravity = 8.0f;
			break; 
		}


		//gameObject.AddComponent<TrianglePlayer> ();

	}


	void Update () {


	}



	//void OnCollisionEnter2D(Collision2D coll) {
		
		//if (coll.gameObject.name == "hill") {
			//Debug.Log (coll.gameObject.name);
			//isGrounded = true;
			//if (Input.GetButtonDown ("Jump")) {     // заменить на Input.touches
				//rd.AddForce (new Vector2 (0, 20 * atmosphere));
		//	}
		//} else if (coll.gameObject.name == "kektus(Clone)" || coll.gameObject.name == "stone(Clone)" ) {
		//	PlayerManager.isAlive = false;
		//	rd.gameObject.SetActive (false);
		//	Lose_Panel.SetActive (true);
		//}
	//}
}
