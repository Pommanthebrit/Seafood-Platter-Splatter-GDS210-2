using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovementWaypointSimple : MonoBehaviour 
{
	[Header("Loop Options")]

	[Tooltip("Will this fish loop. (Go from point A to point B back to point A then to point B again. " +
		"Point B is counted as the last waypoint).")]
	[SerializeField] private bool _loop;

	[Tooltip("How many times will this fish loop. (A trip from point A to B is considered 1 loop.)" +
		"(If 0 is inputed here the fish will loop indefinitely.)")]
	[SerializeField] private int _loopAmount;



	[Header("Movement Settings")]

	[Tooltip("The speed of which this fish will move from waypoint to waypoint.")]
	[SerializeField] protected float _speed;

	[Header("Waypoint Settings")]
	[Tooltip("Waypoints are set as transforms. " +
		"Put empty gameObjects in here connected to your Enemy prefab equal or above in hierarchy.")]
	[SerializeField] protected Transform[] _waypoints;

	[Tooltip("The distance an object will reach from its target before swithcing to the next waypoint.")]
	[SerializeField] protected float _switchDistance;

	// References.
	protected Rigidbody _rb;
	private EnemyController _myEnemyController;

	// Waypoint Variables.
	public Transform _targetWaypoint;
	private int _targetWaypointIndex;
	private int _currentLoop;

	// Other Variables.
	[SerializeField] protected bool _correctFlipping;
	[SerializeField] protected bool _stopFlipping;

	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
		_myEnemyController = GetComponent<EnemyController>();
		SetWaypoints();
		SetupOther();
	}

	private void Update()
	{
		// When the switchDistance has been reached.
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

	// Sets/Resets waypoints. Defaulted to selecting the first waypoint as the target waypoint.
	protected virtual void SetWaypoints()
	{
		_targetWaypointIndex = 0;
		_targetWaypoint = _waypoints[0];
	}

	// This changes the waypoint to the next one in line. It also checks looping settings and loops if nesscacary.
	// NOTE: May need to break down further to allow easy changes to how waypoint are selected and changed.
	private void ChangeWaypoint()
	{
		_targetWaypointIndex++;
		if(_targetWaypointIndex < _waypoints.Length)
		{
			_targetWaypoint = _waypoints[_targetWaypointIndex];
			TryFlip();

		}
		else if(_loop && _currentLoop < _loopAmount || _loop && _loopAmount == 0)
		{
			_currentLoop++;
			_targetWaypointIndex = 0;
			_targetWaypoint = _waypoints[_targetWaypointIndex];
			TryFlip();
		}
		else
		{
			_myEnemyController.FishEscape();
			Destroy(transform.parent.gameObject); // TEMP.
		}
	}

	// Moves to the next waypoint.
	protected virtual void MoveToNextWaypoint()
	{
		Vector3 directionToWaypoint = (_targetWaypoint.position - transform.position).normalized;
		_rb.MovePosition(transform.position+(directionToWaypoint * _speed * Time.fixedDeltaTime));
	}

	// Skeleton method for other setups (Deletion of this method is probably best).
	protected virtual void SetupOther()
	{
		
	}

	// Skeleton method for other movement being added (Deletion of this method is probably best).
	protected virtual void AddOtherMovement()
	{
		
	}

	private void TryFlip()
	{
		if(!_stopFlipping)
		{
			if(transform.position.x < _targetWaypoint.transform.position.x)
			{
				if(_correctFlipping)
					transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
				else
					transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
			}
			else
			{
				if(_correctFlipping)
					transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
				else
					transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
			}
		}
	}
}
