﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGod : MonoBehaviour 
{
	public int _maxAmmo;
	[HideInInspector] public int _totalFish;
	[HideInInspector] public int _currentAmmo;
	[HideInInspector] public int _currentScore;

	//UI Elements
	public GameObject _ammoHUD;
	public GameObject _fishHUD;
	public Transform _pauseMenu, _soloHUD;
	[HideInInspector] public bool _isPaused = false;
	public ParticleSystem _pauseBubble;

	private RoundGod _roundGod;
	private AudioSource _audioSource;

	private List<PlayerController> _playerControllers;
	private PlayerController[] _playerControllersArray;

	private void Start()
	{
		_playerControllers = new List<PlayerController>();

		// Automatically retrieves active players.
		// Ensures that player 1 is in the list [0] slot and player 2 is in the list [1] slot.
		// NOTE: Use _playerControllers[0]._ammo for player 1 ammo and
		// NOTE: Use _playerControllers[1]._ammo for player 2 ammo etc.
		while(_playerControllers.Count < 2)
		{
			foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
			{
				PlayerController playerController = player.GetComponent<PlayerController>();

				if(playerController._playerID == _playerControllers.Count + 1)
				{
					_playerControllers.Add(playerController);
				}

				if(_playerControllers.Count > 1)
				{
					break;
				}
			}
		}

		print(_playerControllers.Count);
		Debug.Log(_playerControllers[0]._playerID);
		Debug.Log(_playerControllers[1]._playerID);

		//Ensure HUDs show correctly during initialisation
		Time.timeScale = 1;
		_pauseMenu.gameObject.SetActive (false);
		_soloHUD.gameObject.SetActive (true);
		_isPaused = false;

		_roundGod = GetComponent<RoundGod>();
		_audioSource = GetComponent<AudioSource>();
		ReplenishAmmo();
	}

	private void Update()
	{
		//Debug.Log("Total Fish GG: " + _totalFish);

		_ammoHUD.GetComponent<Text> ().text = "x" + _currentAmmo.ToString ();
		_fishHUD.GetComponent<Text> ().text = "x" + _totalFish.ToString ();

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Pause ();
		}
	}

	//******Check this script to solve unpause error, it fires a shot when clicking resume******
	//Toggles pause menu and HUD
	public void Pause ()
	{
		if (_pauseMenu.gameObject.activeInHierarchy == false) {
			_isPaused = true; //GunController script checks to see if game is paused or not before firing
			Time.timeScale = 0;
			_pauseMenu.gameObject.SetActive (true);
			_soloHUD.gameObject.SetActive (false);
			_pauseBubble.Emit (30);
		} else {
			_isPaused = false;
			Time.timeScale = 1;
			_pauseMenu.gameObject.SetActive (false);
			_soloHUD.gameObject.SetActive (true);
		}
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