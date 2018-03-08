using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothedNoodleWaypointMovement : SimpleWaypointSmoothMove 
{
	[SerializeField] private float _horizontalSpeed;
	[SerializeField] private float _verticalSpeed;
	[SerializeField] private float _velocityTurnPoint;

	private bool _rising;

	protected override void SetupOther ()
	{
//		_rb.velocity = new Vector3(_horizontalSpeed, 0.0f, 0.0f);
	}

	protected override void AddOtherMovement ()
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

//		_rb.MovePosition(new Vector3(transform.position.x + 0.0001f, transform.position.y, transform.position.z));
	}
}
