using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

	public Transform upPos, downPos;
	public ParticleSystem idleBubble, idleBubble2, fastBubble;

	public float mySpeed = 0, waitTime = 0;
	bool isMoving = false;

	void Start () {
		//Begin looping movement function
		StartCoroutine ("TextMove");

		//Stop fast bubble effect from playing
		ParticleSystem.EmissionModule emit = fastBubble.emission;
		emit.enabled = false;
	}

	void Update () {
		//Move title text towards transform location points (below and above)
		if (isMoving == true) {
			transform.position = Vector2.MoveTowards (transform.position, upPos.transform.position, (mySpeed * Time.deltaTime));
		} else {
			transform.position = Vector2.MoveTowards (transform.position, downPos.transform.position, (mySpeed * Time.deltaTime));
		}

		//Press any key to cause scene jump and bubble effects
		if (Input.anyKey) {
			//Stop idle bubble effects from playing
			ParticleSystem.EmissionModule cease = idleBubble.emission;
			cease.enabled = false;
			ParticleSystem.EmissionModule cease2 = idleBubble2.emission;
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

	//Run text movement function periodically
	IEnumerator TextMove () {		
		yield return new WaitForSeconds (waitTime);
		isMoving = !isMoving;
		StartCoroutine ("TextMove");
	}
}