using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
	int level;
	//int character;
	public GameObject lvlchanger;
	public GameObject perschanger;

	// Use this for initialization
	void Start ()
	{
		level = 1;
		//character = 1;
		//по умолчанию 
		setPerson (1);
	}
	

	public void OnClickStart () {
		//SceneManager.LoadScene (level);
		Debug.Log(level + "level");
		Debug.Log(GlobalPlayer.playerid);
		SceneManager.LoadScene (level);
	}

	public void OnClickPersChanger () {
		perschanger.SetActive (true);
	}

	public void OnClickBPerson (int pers) {
		//character = pers;
		//сверху просто для теста, а вот ниже уже годно
		setPerson (pers);
		perschanger.SetActive (false);
	}

	public void setPerson (int id) {
		GlobalPlayer.playerid = id;
	}

	public void OnClickLvlChanger () {
		lvlchanger.SetActive (true);
	     
	}

	public void OnClickBLevel (int lvl) {
		level = lvl;
		lvlchanger.SetActive (false);
	}

	public void OnClickExit () {
		Application.Quit ();

	}
}

