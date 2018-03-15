using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class GameGod : MonoBehaviour 
{
	[HideInInspector] public int _totalFish;
	[HideInInspector] public int _currentAmmo;
	[HideInInspector] public int _currentScore;
	[HideInInspector] public int _fishEscaped;
	[HideInInspector] public int _maxFish;

	[Header("Sounds")]
	[SerializeField] private AudioClip _perfectRoundAudio;

	//UI Elements
	[Header("UI Elements")]
	[SerializeField] private GameObject _ammoHUD;
	[SerializeField] private GameObject _clipHUD;
	[SerializeField] private GameObject _fishHUD;
	[SerializeField] private GameObject _ammoHUD_2;
	[SerializeField] private GameObject _fishHUD_2;
	public Transform _pauseMenu, _soloHUD;
	public Button PlayBtn;
	[HideInInspector] public bool _isPaused = false;
	public ParticleSystem _pauseBubble;
	public GameObject deathEffect;
	public GameObject Player;
	private RoundGod _roundGod;
	private AudioSource _audioSource;

	private List<PlayerController> _playerControllers;
	private PlayerController[] _playerControllersArray;

	private void Start()
	{
		_playerControllers = new List<PlayerController>();

		// Automatically retrieves active players. Will need changing if instantiating players.
		// Ensures that player 1 is in the list [0] slot and player 2 is in the list [1] slot.
		// NOTE: Use _playerControllers[0]._ammo for player 1 ammo and
		// NOTE: Use _playerControllers[1]._ammo for player 2 ammo etc.
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		while(_playerControllers.Count < players.Length)
		{
			foreach(GameObject player in players)
			{
				PlayerController playerController = player.GetComponent<PlayerController>();

				if(playerController._playerID == _playerControllers.Count + 1)
				{
					_playerControllers.Add(playerController);
					playerController._gg = this;
				}

				if(_playerControllers.Count > 1)
				{
					break;
				}
			}
		}

		//Ensure HUDs show correctly during initialisation
		Time.timeScale = 1;
		_pauseMenu.gameObject.SetActive (false);
		_soloHUD.gameObject.SetActive (true);
		_isPaused = false;

		_roundGod = GetComponent<RoundGod>();
		_audioSource = GetComponent<AudioSource>();
	}

	private void Update()
	{
		//Debug.Log("Total Fish GG: " + _totalFish);

		_ammoHUD.GetComponent<Text> ().text = "x" + _playerControllers[0]._currentAmmo.ToString (); // Player one current ammo
		_clipHUD.GetComponent<Text> ().text = "x" + _playerControllers[0]._currentClip.ToString (); // Player one current clip
		_fishHUD.GetComponent<Text> ().text = "x" + _totalFish.ToString ();

		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonUp("Start"))
		{
			Pause ();
		}
	}

	//Toggles pause menu and HUD
	public void Pause ()
	{
		if (_pauseMenu.gameObject.activeInHierarchy == false) { //Checks to see if game is paused or not
			_isPaused = true; 
			Time.timeScale = 0;
			_pauseMenu.gameObject.SetActive (true);
			PlayBtn.Select (); //Selects the Resume button
			PlayBtn.OnSelect (null); //Highlights the Resume button
			_soloHUD.gameObject.SetActive (false);
			_pauseBubble.Emit (30);
			Player.GetComponent<PlayerController>().enabled= false; //disables player controller
		} else {
			_isPaused = false;
			Time.timeScale = 1;
			_pauseMenu.gameObject.SetActive (false);
			_soloHUD.gameObject.SetActive (true);
			StartCoroutine("TogglePlayerController"); //calls Coroutine
		}
	}

	IEnumerator TogglePlayerController() //function for enabling or disabling player controller (to disable input while paused)
	{
		yield return new WaitForSeconds (0.3f); //wait time
		Player.GetComponent<PlayerController>().enabled= true; //enables player controller
	}

	public void PlayGlobal2DSound(AudioClip audioClip)
	{
		_audioSource.Stop();
		_audioSource.clip = audioClip;
		_audioSource.Play();
	}

	public void ConfirmFishDeath(int score, int playerID)
	{
		AddScore(score, playerID);

		_totalFish = _totalFish - 1;

		if(_totalFish < 1)
		{
			_roundGod.EndRound();
		}
	}

	public void ConfirmFishEscape()
	{
		_fishEscaped++;
		_totalFish--;
		print("Current Fish Escaped: " + _fishEscaped);

		if(_totalFish < 1)
		{
			_roundGod.EndRound();
		}
	}

	public void AddScore(int score, int playerID)
	{
		_playerControllers[playerID - 1]._currentScore += score;
		print("Player " + playerID + ": " + _playerControllers[playerID - 1]._currentScore);
//		_currentScore += score;
	}

	public void AddPerfectRoundBonus(int scoreBonus, int ammoBonus)
	{
		foreach(PlayerController playerCtrl in _playerControllers)
		{
			playerCtrl._currentScore += scoreBonus;
			playerCtrl._currentAmmo += ammoBonus;
//			PlayGlobal2DSound(_perfectRoundAudio);
			Debug.Log(playerCtrl._playerID + "_Current Score: " + playerCtrl._currentScore);
		}
	}


	public void LoseGame()
	{
		Debug.Log("Game Lost");
		GameOver();
	}

	public void WinGame()
	{
		Debug.Log("Game Won");
		GameOver();
	}
		
	public void GameOver()
	{
		PlayerPrefs.SetInt("Score", _currentScore); //stores score in player prefs
		//PlayerPrefs.SetInt("Score", _playerControllers[playerID - 1]._currentScore); //stores score in player prefs
		StartCoroutine("Load");
	}

	IEnumerator Load() { //coroutine for loading a scene
		yield return new WaitForSeconds (0.5f); //wait time
		SceneManager.LoadScene ("Scoreboard"); //Loads the scene
	}

}