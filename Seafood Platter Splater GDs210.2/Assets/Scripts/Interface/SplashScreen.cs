using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

	public ParticleSystem idleBubble, fastBubble;

	void Start () {
		//Stop fast bubble effect from playing
		ParticleSystem.EmissionModule emit = fastBubble.emission;
		emit.enabled = false;
	}

	//Press any key
	void Update () {
		if (Input.anyKey) {
			//Stop idle bubble effect from playing
			ParticleSystem.EmissionModule cease = idleBubble.emission;
			cease.enabled = false;

			//Play fast bubble effect
			ParticleSystem.EmissionModule emit = fastBubble.emission;
			emit.enabled = true;
			Invoke ("OpenScene", 2f);
		}
	}

	//Open next scene in build index order
	void OpenScene() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}