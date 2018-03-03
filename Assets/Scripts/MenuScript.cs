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
	{   //по умолчанию
		setLevel (1);
		setPerson (1);
	}
	

	public void OnClickStart () {
		//SceneManager.LoadScene (level);
		Debug.Log(GlobalParameters.id_level + "level");
		Debug.Log(GlobalParameters.id_player);
		SceneManager.LoadScene (GlobalParameters.id_level);
	}

	public void OnClickPersChanger () {
		perschanger.SetActive (true);
	}

	public void OnClickBPerson (int pers) {
		setPerson (pers);
		perschanger.SetActive (false);
	}

	public void setPerson (int id) {
		GlobalParameters.id_player = id;
	}

	public void setLevel (int lvl) {
		GlobalParameters.id_level = lvl;
	}

	public void OnClickLvlChanger () {
		lvlchanger.SetActive (true);
	     
	}

	public void OnClickBLevel (int lvl) {
		GlobalParameters.id_level = lvl;
		lvlchanger.SetActive (false);
	}

	public void OnClickExit () {
		Application.Quit ();

	}
}

