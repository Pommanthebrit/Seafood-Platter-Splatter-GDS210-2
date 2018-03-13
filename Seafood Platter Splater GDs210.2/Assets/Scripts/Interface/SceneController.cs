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

	//	public void OpenSceneDelayed(string sceneName){ //function for loading scenes with a delay
	//		StartCoroutine("Load", sceneName); //Calls coroutine
	//	}
	//
	//	IEnumerator Load(string sceneName) { //coroutine for loading a scene
	//		yield return new WaitForSeconds (0.3f); //waits for 1 second
	//		SceneManager.LoadScene (sceneName); //Loads the assigned scene when this function is run
	//	}
	//
	//	public void PausedQuit(string sceneName){ //function for loading main menu while paused
	//		Time.timeScale = 1f; //sets timescale to 0 (paused)
	//		SceneManager.LoadScene (sceneName); //Loads the assigned scene when this function is run
	//	}
	//
	//	public void QuitDelayed(){ //function quit quitting with delay
	//		Invoke ("Quit", 0.3f); //calls function with specified delay
	//	}
	//
	//	public void Quit(){ //function for quitting the game when Quit button is clicked
	//		print("Quitting game"); //"Displays "Quitting game" to console
	//		Application.Quit(); //Quits the application (Built game only, doesn't work within Unity editor)
	//	}

}