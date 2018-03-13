using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
	public GameObject particlesToSpawn;
	//Open scene button with delay
	public void OpenSceneDelayed(string sceneName) {
		StartCoroutine("Load", sceneName);
	}

	IEnumerator Load(string sceneName) { //coroutine for loading a scene
		yield return new WaitForSeconds (0.3f); //waits for 1 second
		SceneManager.LoadScene (sceneName); //Loads the assigned scene when this function is run
	}

	//Quit button with delay
	public void QuitDelayed(){ //function quit quitting with delay
		Debug.Log ("Application Closing");
		Invoke ("Quit", 0.3f); //calls function with specified delay
	}

	public void Quit() { 
		Application.Quit();
	}

	public void SpawnParticleEffect(RectTransform rT){
		Vector3 worldPos = Camera.main.ScreenToWorldPoint (new Vector3(rT.position.x,rT.position.y, 20));

		Instantiate (particlesToSpawn,worldPos, Quaternion.identity);
	}
}