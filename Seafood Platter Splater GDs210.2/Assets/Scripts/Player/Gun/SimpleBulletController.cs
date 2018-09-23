using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleBulletController : MonoBehaviour 
{
	[HideInInspector] public int _bulletPlayerID;
	[SerializeField] private float _speed;
	[SerializeField] private float _destroyTime;
	private Rigidbody _rb;
	public Vector3 controllerPos;
    private GameObject _targetFish;

	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
		Camera c = Camera.main;
		Vector3 mousePos = c.ScreenToWorldPoint(new Vector3(controllerPos.x, controllerPos.y, 20f));
		_rb.AddForce((mousePos - transform.position).normalized * _speed, ForceMode.VelocityChange);

		//Invoke("Destroy", _destroyTime);
	}

	private void OnCollisionEnter(Collision other)
	{
        transform.parent = other.transform;
        transform.position = other.transform.position;
        transform.rotation = other.transform.rotation;
        _targetFish = other.gameObject;
        _rb.velocity = Vector3.zero;
	}

	private void Destroy()
	{
		Destroy(this.gameObject);
	}

    private void Update()
    {
        if(_targetFish != null)
        {
            transform.position = _targetFish.transform.position;
        }
    }
}
