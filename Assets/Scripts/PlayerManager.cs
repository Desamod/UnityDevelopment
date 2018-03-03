using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	protected bool isGrounded = false;
	protected float floor = -3.3f;
	protected float MaxSpeed = 0.1f;
	protected Sprite spr;
	protected float FlySpeed;
	protected float speed;
	protected float gravity = 9.8f;

	public static bool isAlive;

	public float Gravity {
		get {
			return gravity;
		}
		set {
			gravity = value;
		}
	}

	public float Speed {
		get {
			return speed;
		}
		set {
			speed = value;
		}
	}




	virtual public void Set_Avatar () 
	{	
		
      
	}

	virtual public void UpdateSpeed () 
	{	


	}

	public void Jump () 
	{
		if (transform.position.y + FlySpeed * Time.deltaTime < floor) {
			isGrounded = true;
			transform.position = new Vector3 (transform.position.x, floor, transform.position.z);
			gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
		} else { 
			transform.position = new Vector3 (transform.position.x, transform.position.y + FlySpeed * Time.deltaTime, transform.position.z); 
			gameObject.GetComponent<SpriteRenderer> ().color = Color.green;
		}
	}




	void Start () {
		isGrounded = true;
		isAlive = true;
		Set_Avatar ();
		speed = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		
		UpdateSpeed ();
		if (isGrounded == true && Input.GetButtonDown ("Jump")) {
			FlySpeed = 10.0f;
			isGrounded = false;
		} 
		else if (isGrounded == false) {
			FlySpeed = FlySpeed - gravity * Time.deltaTime;
			Jump ();
		}

			
	}

}
