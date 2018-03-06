using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotater : MonoBehaviour {

	void Update () {
		transform.Rotate (Vector3.forward * 20 * Time.deltaTime);
	}
}