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


	virtual public bool Overlaps() {
		GameObject[] collarray = GameObject.FindGameObjectsWithTag ("Collision");
		Vector2 center = new Vector2 (transform.position.x, transform.position.y);
		Vector2 halfsize = GetComponent<SpriteRenderer> ().sprite.rect.size / GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
		halfsize.x = halfsize.x * transform.localScale.x / 2.1f;
		halfsize.y = halfsize.y * transform.localScale.y / 2.2f;
		foreach (GameObject arr in collarray) {
			Vector2 collcentr = new Vector2 (arr.transform.position.x, arr.transform.position.y);
			Vector2 collsize = arr.GetComponent<SpriteRenderer> ().sprite.rect.size / arr.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
		
			collsize.x = collsize.x * arr.transform.localScale.x / 2.1f;
			collsize.y = collsize.y * arr.transform.localScale.y / 2.2f;

			if (Mathf.Abs (center.x - collcentr.x) <= halfsize.x + collsize.x && 
				Mathf.Abs (center.y - collcentr.y) <= halfsize.y + collsize.y)
				return true;
		}
		return false;
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

		if (isGrounded == true && (Input.touchCount > 0 || Input.GetButtonDown ("Jump"))) { 
			FlySpeed = 10.0f;
			isGrounded = false;
		} 
		else if (isGrounded == false) {
			FlySpeed = FlySpeed - gravity * Time.deltaTime;
			Jump ();
		}
			
	}

}
