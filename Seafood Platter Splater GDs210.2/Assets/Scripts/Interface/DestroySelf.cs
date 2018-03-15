using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {

	void Start () {
		Invoke ("DestroyMe", 1f);
	}

	void DestroyMe () {
		Destroy (gameObject);
	}
}
