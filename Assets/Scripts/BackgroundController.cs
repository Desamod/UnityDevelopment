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

		if(PlayerManager.isAlive == true) {
		Vector2 offset = new Vector2 (player.GetComponent<PlayerManager>().Speed*speed, 0);
		GetComponent<Renderer> ().material.mainTextureOffset = GetComponent<Renderer> ().material.mainTextureOffset+offset;
		}
	}


}
