using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	AudioSource myAudioSource;
	public AudioClip bubblePop;
	public GameObject particlesToSpawn;

	void Start () {
		myAudioSource = GetComponent<AudioSource> ();
	}

	public void OpenScene (string sceneName) {
		SceneManager.LoadScene (sceneName);
	}

	//Open new scene button with delay
	public void OpenSceneDelayed(string sceneName) {
		StartCoroutine("Load", sceneName);
	}

	IEnumerator Load(string sceneName) { //coroutine for loading a scene
		yield return new WaitForSeconds (0.3f); //wait time
		SceneManager.LoadScene (sceneName); //Loads the assigned scene when this function is run
	}

	//Quit button with delay
	public void QuitDelayed(){ //function quit quitting with delay
		Debug.Log ("Application Closing");
		Invoke ("Quit", 0.3f); //calls function with specified delay
	}

	void Quit() { 
		Application.Quit();
	}

	//Spawns particle effect when button is pressed
	public void SpawnParticleEffect(RectTransform rT){
		Vector3 worldPos = Camera.main.ScreenToWorldPoint (new Vector3(rT.position.x,rT.position.y, 20));

		Instantiate (particlesToSpawn,worldPos, Quaternion.identity);
		myAudioSource.PlayOneShot (bubblePop);
	}
}