using UnityEngine;
using System.Collections;

public class BallPlayer : PlayerManager
{

	//protected Sprite spr;

	override public void Set_Avatar () 
	{
		spr = Resources.Load<Sprite>("Sprites/ball");
		GetComponent<SpriteRenderer> ().sprite = spr;
		transform.localScale = new Vector2 (0.2f, 0.2f);
	}

	override public void UpdateSpeed ()
	{
		if (speed <= MaxSpeed && isAlive == true)
			speed = speed + (speed + 2.5f) / 10000000;
		   
			//speed = speed + 0.00000025f;
		if (isAlive == false) {
			speed = 0;
		}
	}
}

