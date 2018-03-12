using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	[HideInInspector] public GameGod _gg;
	[SerializeField] private int _health;
	[SerializeField] private int _scoreWorth;
	[SerializeField] private bool _endangered;

	// When a collision happens.
	private void OnCollisionEnter(Collision other)
	{
		// If bullet collision.
		if(other.gameObject.tag == "Bullet")
		{
			Hit(); // Get hit.
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
		_gg.ConfirmFishDeath(_scoreWorth);
	}
}