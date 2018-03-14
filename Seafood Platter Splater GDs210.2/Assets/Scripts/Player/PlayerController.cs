using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public int _playerID;
	public int _currentAmmo; // TEMP(Change to hide in inspector. Set value elsewhere).
	[HideInInspector] public GameGod _gg; // Set up on GameGod.
	[HideInInspector] public int _currentScore;

	private GunController _myGunController;

	private void Start()
	{
		_myGunController = GetComponentInChildren<GunController>();
		gameObject.GetComponent<GunLookAtMouse>()._playerID = _playerID;
	}

	private void Update()
	{
		if (_playerID == 1)
		{
			if (Input.GetButtonUp ("Fire1") && _gg._isPaused == false && _currentAmmo > 0) 
			{
				_myGunController.Shoot(_playerID);
				_currentAmmo--;
			}
			else
			{
				// Play empty clip sound.
			}
		}
		else 
		{
			if (Input.GetButtonUp ("Fire2") && _gg._isPaused == false && _currentAmmo > 0) 
			{
				_myGunController.Shoot(_playerID);
				_currentAmmo--;
			}
			else
			{
				// Play empty clip sound.
			}
		}
	}
}
