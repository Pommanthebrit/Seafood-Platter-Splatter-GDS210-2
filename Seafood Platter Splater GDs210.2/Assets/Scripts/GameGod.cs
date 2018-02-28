using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGod : MonoBehaviour 
{
	public int _maxAmmo;
	public int _currentAmmo;

	private AudioSource _audioSource;

	private void Start()
	{
		_audioSource = GetComponent<AudioSource>();
		ReplenishAmmo();
	}

	private void ReplenishAmmo()
	{
		_currentAmmo = _maxAmmo;
	}

	public void PlayGlobal2DSound(AudioClip audioClip)
	{
		_audioSource.Stop();
		_audioSource.clip = audioClip;
		_audioSource.Play();
	}
}
