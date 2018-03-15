using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour 
{
	public int _playerID;
	public int _currentAmmo; // TEMP(Change to hide in inspector. Set value elsewhere).
	[HideInInspector] public GameGod _gg; // Set up on GameGod.
	[HideInInspector] public int _currentScore;

	[SerializeField] private int _clipSize;
	[SerializeField] private float _reloadTime;

	[Header("Audio Settings")]
	[SerializeField] private AudioClip _emptyClip;
	[SerializeField] private AudioClip _reloadingClip;
	[SerializeField] private AudioClip _reloadedClip;

	private AudioSource _audioSource;
	public int _currentClip;
	private bool _reloading;

	private GunController _myGunController;

	private void Start()
	{
		_audioSource = GetComponent<AudioSource>();
		_myGunController = GetComponentInChildren<GunController>();
		gameObject.GetComponent<GunLookAtMouse>()._playerID = _playerID;
		_currentClip = _clipSize;
		_reloading = false;
	}

	private void Update()
	{
		if (_playerID == 1)
		{
			//Edit by Aston Olsen. I re-wrote a bunch of the shooting and reloading code to place reload checks in the update function. Previously the gun wasn't checking if the mag was empty until the shoot function was called, meaning you had to click fire again when the mag was empty to reload
			CheckReload ();  
			if (Input.GetButtonUp ("Fire1") && _gg._isPaused == false) 
			{
				TryShoot ();
			}
		}
		else 
		{
			CheckReload ();
			if (Input.GetButtonUp ("Fire2") && _gg._isPaused == false) 
			{
				TryShoot ();
			}
		}
	}

	private void CheckReload() //function for checking if the gun needs to reload
	{
		if(_currentClip == 0 && _currentAmmo > 0 && !_reloading)
		{
			Invoke ("Reload", _reloadTime);
			_reloading = true;
			Debug.Log ("Reloading");
		}
	}

	private void TryShoot()
	{
		if(!_reloading)
		{
			if(_currentAmmo == 0 && _currentClip == 0)
			{
//					PlaySound(_emptyClip);
			}
			else
			{
				_myGunController.Shoot(_playerID);
				_currentClip--;

				CheckReload();
			}
		}
	}

	private void Reload()
	{
		if(_currentAmmo > _clipSize)
		{
			_currentClip = _clipSize;
			_currentAmmo -= _clipSize;
		}
		else
		{
			_currentClip = _currentAmmo;
			_currentAmmo = 0;
		}

		_reloading = false;
		Debug.Log ("Reloaded");
		PlaySound(_reloadedClip);
	}

	private void PlaySound(AudioClip clip)
	{
		_audioSource.Stop();
		_audioSource.clip = clip;
		_audioSource.Play();
	}
}