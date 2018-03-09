using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovementSimpleNoodle : MonoBehaviour 
{
	[SerializeField] private bool _loop;
	[SerializeField] private int _loopAmount;
	[SerializeField] private float _turnAroundOverscan;

	[SerializeField] private float _horizontalSpeed;
	[SerializeField] private float _verticalSpeed;
	[SerializeField] private float _velocityTurnPoint;

	private Renderer _myRenderer;
	private bool _enteredScreen;
	private float _currentLoop;

	private bool _rising;
	private Rigidbody _rb;

	private void Start()
	{
		_enteredScreen = false;
		_myRenderer = GetComponent<Renderer>();
		_rb = GetComponent<Rigidbody>();
		_rb.velocity = new Vector3(_horizontalSpeed, 0.0f, 0.0f);
//		_isReversing = true;
	}

//	private void Update()
//	{
//		if(_myRenderer.isVisible)
//		{
//			_isReversing = false;
//		}
//		else if(_loop && !_isReversing)
//		{
//			if(_currentLoop < _loopAmount && _loopAmount != 0)
//			{
//				TurnAround();
//			}
//			else if(_loopAmount != 0)
//			{
//				// Lose Score.
//				Destroy(this.gameObject); // Temp.
//			}
//
//			if(_loopAmount == 0)
//			{
//				TurnAround();
//			}
//		}
//	}

	private void Update()
	{
		Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);
		print(screenPos);

		if(_enteredScreen)
		{
			if(screenPos.x > (1.0f + _turnAroundOverscan) || screenPos.x < (0.0f - _turnAroundOverscan))
			{
				if(_loop)
				{
					if(_currentLoop < _loopAmount && _loopAmount != 0)
					{
						TurnAround();
					}
					else if(_loopAmount != 0)
					{
						// Lose Score.
						Destroy(this.gameObject); // Temp.
					}
					else
					{
						TurnAround();
					}
				}
				else
				{
					// Lose Score.
					Destroy(this.gameObject); // Temp.
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
	}

	private void TurnAround()
	{
//		_isReversing = true;
		_rb.velocity = new Vector3(_rb.velocity.x * -1, 0.0f, 0.0f);
		_currentLoop++;
	}

	private void FixedUpdate()
	{
		if(_rb.velocity.y > _velocityTurnPoint || _rb.velocity.y < -_velocityTurnPoint)
		{
			if(_rising)
			{
				_rising = false;
			}
			else
			{
				_rising = true;
			}
		}

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
