using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	//Open scene button
	public void OpenScene(string sceneName){
		SceneManager.LoadScene (sceneName);
	}

	//Restart current scene
	public void RestartScene() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	//Quit button
	public void Quit() {
		Debug.Log ("Application Closed");
		Application.Quit();
	}
}