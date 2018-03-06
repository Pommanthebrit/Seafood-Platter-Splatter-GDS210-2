using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWaypointSmoothMove : EnemyMovementWaypointSimple
{
	[SerializeField] private float _smoothTime;
	[SerializeField] private float _maxSpeed;

	protected override void MoveToNextWaypoint ()
	{
		Vector3 directionToWaypoint = (_targetWaypoint.position - transform.position).normalized;
		Vector3 myCurrentVelocity = Vector3.zero;
		_rb.MovePosition(Vector3.SmoothDamp(transform.position, _targetWaypoint.position, ref myCurrentVelocity, _smoothTime, _maxSpeed));
	}
}
