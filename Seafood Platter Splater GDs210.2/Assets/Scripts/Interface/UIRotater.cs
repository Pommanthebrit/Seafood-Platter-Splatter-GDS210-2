using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotater : MonoBehaviour {

	[SerializeField] float mySpeed, waitTime;
	public bool goClockwise = false;

	void Start () {
		//Pick a different wait time and speed for each button
		mySpeed = Random.Range (2, 6);
		waitTime = Random.Range (2, 6);

		StartCoroutine ("Rotater"); 
	}

	void Update () {
		if (goClockwise == true) {
			transform.Rotate (-Vector3.forward * mySpeed * Time.unscaledDeltaTime); //Rotate Z axis clockwise
		} else
			transform.Rotate (Vector3.forward * mySpeed * Time.unscaledDeltaTime); //Rotate Z axis counter clockwise
	}

	//When wait time expires, flip rotation direction
	IEnumerator Rotater () {
		yield return new WaitForSecondsRealtime (waitTime);
		goClockwise = !goClockwise;
		StartCoroutine ("Rotater");
	}
}