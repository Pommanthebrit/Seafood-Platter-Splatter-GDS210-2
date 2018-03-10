using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGod : MonoBehaviour 
{
	public int _maxAmmo;
	[HideInInspector] public int _totalFish;
	[HideInInspector] public int _currentAmmo;
	[HideInInspector] public int _currentScore;

	public GameObject _ammoHUD;
	public GameObject _fishHUD;

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

		_ammoHUD.GetComponent<Text> ().text = "x" + _currentAmmo.ToString ();
		_fishHUD.GetComponent<Text> ().text = "x" + _totalFish.ToString ();
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
