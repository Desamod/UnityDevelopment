using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	private bool isGrounded = false;
	//ссылка на компонент Transform объекта
	//для определения соприкосновения с землей
	public Transform groundCheck;
	//радиус определения соприкосновения с землей
	private float groundRadius = 0.2f;
	//ссылка на слой, представляющий землю
	public LayerMask whatIsGround;

	Rigidbody2D rd;
	float speed = 6.0f;
	private float atmosphere = 10.0f;

	// Use this for initialization
	void Start () {
		int testplayer = GlobalPlayer.playerid;
		Debug.Log (testplayer);
		rd = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		if (isGrounded == true && Input.GetButtonDown ("Jump")) {     // заменить на Input.touches
			rd.AddForce (new Vector2 (0, 40 * atmosphere));
			isGrounded = false;
		}

	}



	void OnCollisionEnter2D(Collision2D coll) {
		
		if (coll.gameObject.name == "hill") {
			//Debug.Log (coll.gameObject.name);
			isGrounded = true;
			if (Input.GetButtonDown ("Jump")) {     // заменить на Input.touches
				//rd.AddForce (new Vector2 (0, 20 * atmosphere));
			}
		}
	}
}
