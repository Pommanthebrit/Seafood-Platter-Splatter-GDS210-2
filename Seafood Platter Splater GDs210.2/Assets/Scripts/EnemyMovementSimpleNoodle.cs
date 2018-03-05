using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovementSimpleNoodle : MonoBehaviour 
{
	[SerializeField] private float _horizontalSpeed;
	[SerializeField] private float _verticalSpeed;
	[SerializeField] private float _velocityTurnPoint;

	private bool _rising;
	private Rigidbody _rb;

	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
		_rb.velocity = new Vector3(_horizontalSpeed, 0.0f, 0.0f);
	}

	private void FixedUpdate()
	{
		print(_rb.velocity.y);
		print(_rising);
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
