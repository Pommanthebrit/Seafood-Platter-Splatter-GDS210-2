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
		Camera c = Camera.main;
		Vector3 mousePos = c.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f));
		_rb.AddForce((mousePos - transform.position).normalized * _speed, ForceMode.VelocityChange);

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
