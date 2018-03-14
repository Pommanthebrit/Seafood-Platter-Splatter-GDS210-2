using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public int _playerID;
	public int _currentAmmo; // TEMP(Change to hide in inspector. Set value elsewhere).
	[HideInInspector] public GameGod _gg; // Set up on GameGod.
	[HideInInspector] public int _currentScore;

	[SerializeField] private int _clipSize;
	[SerializeField] private float _reloadTime;

	private int _currentClip;
	private bool _reloading;

	private GunController _myGunController;

	private void Start()
	{
		_myGunController = GetComponentInChildren<GunController>();
		gameObject.GetComponent<GunLookAtMouse>()._playerID = _playerID;

		_currentClip = _clipSize;
		_reloading = false;
	}

	private void Update()
	{
		if (_playerID == 1)
		{
			if (Input.GetButtonUp ("Fire1") && _gg._isPaused == false) 
			{
				TryShoot ();
			}
		}
		else 
		{
			if (Input.GetButtonUp ("Fire2") && _gg._isPaused == false) 
			{
				TryShoot ();
			}
		}
	}

	private void TryShoot()
	{
		if(!_reloading)
		{
			if(_currentClip > 0)
			{
				_myGunController.Shoot(_playerID);
				_currentClip--;
			}
			else
			{
				Invoke ("Reload", _reloadTime);
				_reloading = true;
				Debug.Log ("Reloading");
			}
		}
	}

	private void Reload()
	{
		Debug.Log ("Reloaded");
		_reloading = false;
		_currentClip = _clipSize;
		_currentAmmo -= _clipSize;
	}
}