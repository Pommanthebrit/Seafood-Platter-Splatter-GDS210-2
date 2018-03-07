using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovementWaypointSimple : MonoBehaviour 
{
	[SerializeField] protected float _speed;
	[SerializeField] protected Transform[] _waypoints;
	[SerializeField] protected float _switchDistance;
	protected Transform _targetWaypoint;
	protected Rigidbody _rb;

	private int _targetWaypointIndex;

	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
		SetWaypoints();
		SetupOther();
	}

	private void Update()
	{
		if((_targetWaypoint.position - transform.position).magnitude < _switchDistance)
		{
			ChangeWaypoint();
		}
	}

	private void FixedUpdate()
	{
		MoveToNextWaypoint();
		AddOtherMovement();
	}

	protected virtual void SetWaypoints()
	{
		_targetWaypointIndex = 0;
		_targetWaypoint = _waypoints[0];
	}

	private void ChangeWaypoint()
	{
		_targetWaypointIndex++;
		if(_targetWaypointIndex < _waypoints.Length)
		{
			_targetWaypoint = _waypoints[_targetWaypointIndex];
		}
		else
		{
			_targetWaypointIndex = 0;
			_targetWaypoint = _waypoints[_targetWaypointIndex];
		}
	}

	protected virtual void MoveToNextWaypoint()
	{
		Debug.Log (_targetWaypoint.position.ToString ());
		Vector3 directionToWaypoint = (_targetWaypoint.position - transform.position).normalized;
		_rb.MovePosition(transform.position+(directionToWaypoint * _speed*Time.fixedDeltaTime));
	}

	protected virtual void SetupOther()
	{
		
	}

	protected virtual void AddOtherMovement()
	{
		
	}
}
