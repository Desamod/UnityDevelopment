using UnityEngine;
using System.Collections;

public class Obj_spawn : MonoBehaviour
{

	public GameObject[] array;
	public float delay;
	public float timer = 4.0f;
	private float complic;

	// Use this for initialization
	void Start ()
	{
		delay = timer;
		complic = 0;
	}

	// Update is called once per frame
	void Update ()
	{

		delay = delay - Time.deltaTime;

		if (delay <= 0 && PlayerManager.isAlive == true) {
			int num = Random.Range (0, 2);
		
			Transform.Instantiate (array [num], transform.position, transform.rotation);
			delay = Random.Range (5 - complic, 7 - complic/2.0f );
			if (complic < 3.0f)
				complic = complic + 0.1f;
		}
	}
}
