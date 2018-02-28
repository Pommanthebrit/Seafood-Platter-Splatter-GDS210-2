using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	[SerializeField] private GameGod _gg; // Temp.
	[SerializeField] private int _health;
	[SerializeField] private int _scoreWorth;
	private Rigidbody _rb;

	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
	}

	// When a collision happens.
	private void OnCollisionEnter(Collision other)
	{
		// If bullet collision
		if(other.gameObject.tag == "Bullet")
		{
			Hit(); // Get hit
		}
	}

	// Damages Enemy.
	private void Hit()
	{
		_health--;
		if(_health < 1)
		{
			Die();
		}
	}

	// Destroys Enemy and Adds score.
	private void Die()
	{
		Destroy(this.gameObject);
		_gg.AddScore(_scoreWorth);
	}
}