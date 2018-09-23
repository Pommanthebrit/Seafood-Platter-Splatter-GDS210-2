using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	[HideInInspector] public GameGod _gg;
	[SerializeField] private int _health;
	[SerializeField] private int _scoreWorth;
	[SerializeField] private bool _endangered;
    [SerializeField] private GameObject _bloodEffect;
    private bool _isDead;

	// When a collision happens.
	private void OnCollisionEnter(Collision other)
	{
		// If bullet collision.
		if(other.gameObject.tag == "Bullet")
		{
			Hit(other.gameObject.GetComponent<SimpleBulletController>()._bulletPlayerID); // Get hit.
		}
	}

	// Damages Enemy.
	private void Hit(int bulletPlayerID)
	{
		_health--;
		if(_health < 1)
		{
			Die(bulletPlayerID);
		}
	}

	// Destroys Enemy and Adds score.
	private void Die(int bulletPlayerID)
	{
        gameObject.layer = 0;
		Instantiate(_gg.deathEffect, gameObject.transform.position, gameObject.transform.rotation, transform);
        Instantiate(_bloodEffect, gameObject.transform.position, gameObject.transform.rotation, transform);
        if(_endangered)
		{
			_gg.ConfirmFishDeath(-_scoreWorth, bulletPlayerID);
		}
		else
		{
			_gg.ConfirmFishDeath(_scoreWorth, bulletPlayerID);
		}
	}

	public void FishEscape()
	{
		_gg.ConfirmFishEscape();
	}
}