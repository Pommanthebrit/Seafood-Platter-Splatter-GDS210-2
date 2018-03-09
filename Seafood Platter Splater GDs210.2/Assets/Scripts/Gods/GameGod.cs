using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGod : MonoBehaviour 
{
	public int _maxAmmo;
	[HideInInspector] public int _totalFish;
	[HideInInspector] public int _currentAmmo;
	[HideInInspector] public int _currentScore;

	private RoundGod _roundGod;
	private AudioSource _audioSource;

	private void Awake()
	{
	}

	private void Start()
	{
		_roundGod = GetComponent<RoundGod>();
		_audioSource = GetComponent<AudioSource>();
		ReplenishAmmo();
	}

	private void Update()
	{
		Debug.Log("Total Fish GG: " + _totalFish);
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

	public void ConfirmFishDeath(int score)
	{
		AddScore(score);
		_totalFish = _totalFish - 1;

		if(_totalFish < 1)
		{
			_roundGod.EndRound();
		}
	}

	public void AddScore(int score)
	{
		_currentScore += score;
	}
}
