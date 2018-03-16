using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	[SerializeField] private AudioClip _reloadedClip;

	[Header("UI Settings")]
	[SerializeField] private Text _currentAmmoText;
	[SerializeField] private Text _currentClipText;

	private AudioSource _audioSource;
	[HideInInspector] public int _currentClip;
	private bool _reloading;

	private GunController _myGunController;

	private void Start()
	{
		_audioSource = GetComponent<AudioSource>();
		_myGunController = GetComponentInChildren<GunController>();
		gameObject.GetComponent<GunLookAtMouse>()._playerID = _playerID;

		// Ammo UI element references.
		_currentAmmoText = _currentAmmoText.GetComponent<Text>();
		_currentClipText = _currentClipText.GetComponent<Text>();

		_currentClip = _clipSize;
		_reloading = false;
	}

	private void Update()
	{
		if (_playerID == 1)
		{
			//Edit by Aston Olsen. I re-wrote a bunch of the shooting and reloading code to place reload checks in the update function. Previously the gun wasn't checking if the mag was empty until the shoot function was called, meaning you had to click fire again when the mag was empty to reload
			if (Input.GetButtonUp ("Fire1") && _gg._isPaused == false) 
			{
				TryShoot ();
			}

			// On Reload button press make sure: game is not paused, not reloading and not a full clip.
			if(Input.GetButtonUp("Reload_1")  && _gg._isPaused == false && !_reloading && _currentClip < _clipSize)
			{
				Invoke ("Reload", _reloadTime);
				_reloading = true;
			}
		}
		else 
		{
			if (Input.GetButtonUp ("Fire2") && _gg._isPaused == false) 
			{
				TryShoot ();
			}

			// On Reload button press make sure: game is not paused, not reloading and not a full clip.
			if(Input.GetButtonUp("Reload_2")  && _gg._isPaused == false && !_reloading && _currentClip < _clipSize)
			{
				print("What Up");
				Invoke ("Reload", _reloadTime);
				_reloading = true;
			}
		}

		// Sets UI text to show correct values.
		_currentAmmoText.text = _currentAmmo.ToString();
		_currentClipText.text = _currentClip.ToString();
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
				_audioSource.PlayOneShot (_emptyClip);
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
		// If there is more than enough ammo to fill full clip.
		if(_currentAmmo > _clipSize)
		{
			_currentAmmo -= _clipSize - _currentClip; // Gets how much is needed to make a full clip and then substracts it from _currentAmmo.
			_currentClip = _clipSize; // Fills clip.

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