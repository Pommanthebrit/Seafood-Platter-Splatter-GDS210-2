using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotater : MonoBehaviour {

	[SerializeField] float mySpeed, waitTime;
	public bool goClockwise = false;

	void Start () {
		//Pick a different wait time and speed for each button
		mySpeed = Random.Range (2, 6);
		waitTime = Random.Range (2, 8);

		StartCoroutine ("Rotater"); 
	}

	void Update () {
		if (goClockwise == true) {
			transform.Rotate (-Vector3.forward * mySpeed * Time.deltaTime); //Rotate Z axis clockwise
		} else
			transform.Rotate (Vector3.forward * mySpeed * Time.deltaTime); //Rotate Z axis counter clockwise
	}

	//When wait time expires, flip rotation direction
	IEnumerator Rotater () {		
		yield return new WaitForSeconds (waitTime);
		goClockwise = !goClockwise;
		StartCoroutine ("Rotater");
	}
}