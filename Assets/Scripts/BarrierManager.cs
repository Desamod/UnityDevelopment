using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierManager : MonoBehaviour {


	GameObject player;
	private float regulation = 250;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		float offset;
		Vector2 pos = new Vector2(transform.position.x , transform.position.y);
		Vector2 halfsize = GetComponent<SpriteRenderer> ().sprite.rect.size / GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
		halfsize.y = halfsize.y * transform.localScale.y / 2;

		if (pos.x < -14.0f) {
			Destroy (gameObject);
		} else if (PlayerManager.isAlive == true) {
			offset = regulation * player.GetComponent<PlayerManager>().Speed;
			if (pos.y - halfsize.y >= -4.0f)
				transform.position = new Vector3(transform.position.x - offset, transform.position.y - offset,transform.position.z);
			else transform.position = new Vector3(transform.position.x - offset , transform.position.y,transform.position.z);
		} 
	}
}
