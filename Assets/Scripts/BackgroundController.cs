using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	public float speed = 9.5f;
	GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () {

		//Debug.Log(player.GetComponent<PlayerManager>().Speed);
		Vector2 offset = new Vector2 (player.GetComponent<PlayerManager>().Speed*speed, 0);
		//Debug.Log (player.GetComponent<PlayerManager> ().Speed + speed);

		GetComponent<Renderer> ().material.mainTextureOffset = GetComponent<Renderer> ().material.mainTextureOffset+offset;
		//if (speed <= 0.2f && PlayerManager.isAlive == true) 
		   //speed = speed + 0.00000025f;
		//if (PlayerManager.isAlive == false) {
			//speed = 0;
		//}
	}


}
