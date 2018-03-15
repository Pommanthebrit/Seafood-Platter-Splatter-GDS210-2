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
	private int _currentClip;
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
				if(_currentAmmo > 0)
				{
					Invoke ("Reload", _reloadTime);
					_reloading = true;
//					PlaySound(_reloadingClip);
					Debug.Log ("Reloading");
				}
				else
				{
//					PlaySound(_emptyClip);
				}
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