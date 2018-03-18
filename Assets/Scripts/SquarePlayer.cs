using UnityEngine;
using System.Collections;

public class SquarePlayer : PlayerManager
{

	override public void Set_Avatar () 
	{
		spr = Resources.Load<Sprite>("Sprites/square");
		GetComponent<SpriteRenderer> ().sprite = spr;
		transform.localScale = new Vector2 (0.5f, 0.5f);
	}

	override public void UpdateSpeed ()
	{
		if (speed <= MaxSpeed && isAlive == true)
			speed = speed + (speed + 2.5f) / 10000000;

		if (isAlive == false) {
			speed = 0;
		}
	}
}

