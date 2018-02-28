using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleBulletMove : MonoBehaviour 
{
	[SerializeField] private float _speed;
	private Rigidbody _rb;

	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		_rb.velocity = transform.up * _speed;
	}
}
