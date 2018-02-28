using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleBulletController : MonoBehaviour 
{
	[SerializeField] private float _speed;
	private Rigidbody _rb;

	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
		_rb.velocity = transform.up * _speed;
	}

	private void OnCollisionEnter(Collision other)
	{
		Destroy(this.gameObject);
	}
}
