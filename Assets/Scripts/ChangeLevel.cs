using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("Change level initialized");
	}

	//changes the level using a name input
	public void changeLevel (string sceneName){
		Debug.Log(sceneName);
		SceneManager.LoadScene (sceneName);
		//SceneManager.SetActiveScene (sceneName);
	}

	public void quitGame (){
		Application.Quit();
	}
}
