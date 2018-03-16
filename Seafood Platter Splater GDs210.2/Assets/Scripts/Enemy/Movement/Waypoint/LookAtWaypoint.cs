using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtWaypoint : MonoBehaviour {

	[SerializeField] float turningRate;
	private EnemyMovementWaypointSimple _waypointCtrl;

	// Use this for initialization
	void Start () {
		_waypointCtrl = GetComponent<EnemyMovementWaypointSimple>();
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion rotation = Quaternion.LookRotation(transform.position - _waypointCtrl._targetWaypoint.position, Vector3.up);
		rotation.x = 0.0f;
		rotation.y = 0.0f;
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 8);
	}
}