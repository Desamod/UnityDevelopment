using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

	// Use this for initialization
	public GameObject EndOfGame;
	bool end = false;
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

	}


	void Update () {
		if (player.GetComponent<PlayerManager> ().Overlaps () && end == false) {
			Transform.Instantiate (EndOfGame);
			PlayerManager.isAlive = false;
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			end = true;
		}
			
		if (PlayerManager.isAlive == false && Input.touchCount > 0) { 
			SceneManager.LoadScene (0);
		}

	}


}
