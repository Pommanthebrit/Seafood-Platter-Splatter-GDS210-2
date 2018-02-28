using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleBulletController : MonoBehaviour 
{
	[SerializeField] private float _speed;
	[SerializeField] private float _destroyTime;
	private Rigidbody _rb;

	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
		_rb.velocity = transform.up * _speed;

		Invoke("Destroy", _destroyTime);
	}

	private void OnCollisionEnter(Collision other)
	{
		Destroy(this.gameObject);
	}

	private void Destroy()
	{
		Destroy(this.gameObject);
	}
}
