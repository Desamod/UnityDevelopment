using UnityEngine;
using System.Collections;

public class BallPlayer : PlayerManager
{

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

		if (isAlive == false) {
			speed = 0;
		}
	}


	override public bool Overlaps() {
		GameObject[] collarray = GameObject.FindGameObjectsWithTag ("Collision");
		Vector2 center = new Vector2 (transform.position.x, transform.position.y);

		Vector2 size = GetComponent<SpriteRenderer> ().sprite.rect.size / GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
		float player_R = transform.localScale.x * (size.x / 2);
		foreach (GameObject arr in collarray) {
			Vector2 collcentr = new Vector2 (arr.transform.position.x, arr.transform.position.y);
			Vector2 collsize = arr.GetComponent<SpriteRenderer> ().sprite.rect.size / arr.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
			collsize.x = collsize.x * arr.transform.localScale.x / 2.0f;    //halfsize
			collsize.y = collsize.y * arr.transform.localScale.y / 2.0f;


		    float Xmin = collcentr.x - collsize.x;
			float Xmax = collcentr.x + collsize.x;
			float Ymin = collcentr.y - collsize.y;
			float Ymax = collcentr.y + collsize.y;
			//Для первой прямой 
			float y = Mathf.Sqrt(player_R*player_R - Mathf.Pow((Xmin - center.x),2)) + center.y;
			if (Ymin <= y && y <= Ymax)
				return true;

			//Для второй прямой
			float x = Mathf.Sqrt(player_R*player_R - Mathf.Pow((Ymax - center.y),2)) + center.x;
			if (Xmin <= x && x <= Xmax)
				return true;
			
			//Для третьей прямой
			y = Mathf.Sqrt(player_R*player_R - Mathf.Pow((Xmax - center.x),2)) + center.y;
			if (Ymin <= y && y <= Ymax)
				return true;
		}
		return false;
	}

}

