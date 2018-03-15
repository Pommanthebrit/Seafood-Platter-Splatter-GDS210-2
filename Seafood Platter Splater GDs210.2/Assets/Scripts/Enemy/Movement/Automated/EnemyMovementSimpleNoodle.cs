using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class moves the object in a noodle formation in a simple way.
// TO-DO_0: Code Segment in Update() method needs revising
// TO-DO_1: Needs connection to GameGod to lose score (aka fish life)
[RequireComponent(typeof(Rigidbody))]
public class EnemyMovementSimpleNoodle : MonoBehaviour 
{
	[Header("Loop Settings")]

	[Tooltip("Enables looping")]
	[SerializeField] private bool _loop;

	[Tooltip("How many times object will loop from A to B. (1 movement (ie. A to B or B to A) is considered 1 loop.")]
	[SerializeField] private int _loopAmount;

	[Tooltip("How far the object will move off screen before looping (turning around).")]
	[SerializeField] private float _turnAroundOverscan;


	[Header("Speed Settings")]

	[Tooltip("The speed of which the object will move horizontally across the screen.")]
	[SerializeField] private float _horizontalSpeed;

	[Tooltip("The speed of which the object will move up and down the screen.")]
	[SerializeField] private float _verticalSpeed;

	[Tooltip("The y-velocity of which the object will reach before reversing the force input.")]
	[SerializeField] private float _velocityTurnPoint;

	// References.
//	private Renderer _myRenderer;
	private Rigidbody _rb;
	private EnemyController _myEnemyController;

	// Looping Variables.
	private bool _enteredScreen;
	private float _currentLoop;

	// Moving Variables.
	private bool _rising;

	private void Start()
	{
		_enteredScreen = false;
//		_myRenderer = GetComponent<Renderer>();
		_rb = GetComponent<Rigidbody>();
		_rb.velocity = new Vector3(_horizontalSpeed, 0.0f, 0.0f);
		_myEnemyController = GetComponent<EnemyController>();
	}

	private void Update()
	{
		// Gets screen position relative to this object transform.
		Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);

		// TO-DO_0: This code needs revising.
		if(_enteredScreen)
		{
			// If object is outside given boundaries.
			if(screenPos.x > (1.0f + _turnAroundOverscan) || screenPos.x < (0.0f - _turnAroundOverscan))
			{
				if(_loop)
				{
					// If current loop is less than loop amount and that loop amount is not set to zero (the loop indefinitely value).
					if(_currentLoop < _loopAmount && _loopAmount != 0)
					{
						TurnAround();
					}
					else if(_loopAmount != 0)
					{
						// TO-DO_1: Add appropriate fish death by default method.
						Destroy(this.gameObject); // Temp.
						// :TO-DO_1.
					}
					else
					{
						TurnAround();
					}
				}
				else
				{
					_myEnemyController.FishEscape();
					Destroy(transform.parent.gameObject); // TEMP.
				}
			}
		}
		else
		{
			if(screenPos.x > 0.0f && screenPos.x < 1.0f)
			{
				_enteredScreen = true;
			}
		}
		// :TO-DO_0.
	}

	// Applies exact opposite x-velocity and increases currentLoop.
	private void TurnAround()
	{
		_rb.velocity = new Vector3(_rb.velocity.x * -1, 0.0f, 0.0f);
		_currentLoop++;
	}

	private void FixedUpdate()
	{
		Move();
	}

	// Moves object up and down acording to speed and the set velocity turn point.
	private void Move()
	{
		// If y-velocity is more than the turn point or less than negative value of the turn point, switch _rising state.
		if(_rb.velocity.y > _velocityTurnPoint || _rb.velocity.y < -_velocityTurnPoint)
		{
			if(_rising)
				_rising = false;
			else
				_rising = true;
		}

		// Adds the appropriate force to make the object either rise or fall depending on bool.
		if(_rising)
		{
			_rb.AddForce(transform.up * _verticalSpeed, ForceMode.Force);
		}
		else
		{
			_rb.AddForce(-transform.up * _verticalSpeed, ForceMode.Force);
		}
	}
}
