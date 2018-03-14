using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls difficulty of rounds and handles round calculations such as how many Fish spawn.
public class RoundGod : MonoBehaviour {
	// TO-DO: Setup first 20 rounds manually
	// TO-DO: Calculate automatic rounds after 20

	[Header("Rounds")]
	[Tooltip("Add Rounds here by first creating a round in the asset menu. (Assets>Create>Rounds>Round)")]
	public Round[] _manualRounds;

	// Round Information.
	[HideInInspector] public int _currentRound;
	[HideInInspector] public int _fishLeftToSpawn;
	private bool _roundInProgress;

	// References.
	private GameGod _gg;



	private void Start()
	{
		// References.
		_gg = GetComponent<GameGod>();

		// Actions.
		StartRound();
	}


	// Reads the amount of fish to be spawned and adds it to the totalFish in GameGod.
	private void AddFishAmountFromSpawnerCtrl(FishSpawnerController spawnerCtrl)
	{
		foreach(Fish fish in spawnerCtrl._fishToSpawn)
			_gg._totalFish += fish._fishSpawnAmount;
	}



	private void Update()
	{
		if(_roundInProgress)
		{
			UpdateFishSpawnerControllers();
		}
	}



	// Sends Update events to all current Spawners.
	private void UpdateFishSpawnerControllers()
	{
		foreach(FishSpawnerController fishSpawnerCtrl in _manualRounds[_currentRound]._fishSpawnerControllers)
		{
			fishSpawnerCtrl.Update();
		}
	}



	public void EndRound()
	{
		_roundInProgress = false;

		if(_gg._fishEscaped == 0)
		{
			_gg.AddPerfectRoundBonus(_manualRounds[_currentRound]._perfectRoundBonus, _manualRounds[_currentRound]._perfectRoundAmmoBonus);
		}

		// Temp. Will need to be replaced with a round end event (eg. Display stat screen, sfx, etc.)
		_currentRound++;
		if (_currentRound < _manualRounds.Length) 
		{
			StartRound ();
		} 
		else
		{
			// Victory Screen.
		}
	}



	private void StartRound()
	{
		_roundInProgress = true;

		InitialiseFishSpawnerControllers();
	}


	// Initialises all FishSpawnerControllers for current round.
	private void InitialiseFishSpawnerControllers()
	{
		foreach(FishSpawnerController fishSpawnerCtrl in _manualRounds[_currentRound]._fishSpawnerControllers)
		{
			fishSpawnerCtrl.Start();
			fishSpawnerCtrl._gg = _gg;
			AddFishAmountFromSpawnerCtrl(fishSpawnerCtrl);
		}
	}
}
