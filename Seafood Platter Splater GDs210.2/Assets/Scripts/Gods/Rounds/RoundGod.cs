using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls difficulty of rounds and handles round calculations such as how many Fish spawn
public class RoundGod : MonoBehaviour {
	// Set fish spawn amount per round
	// Have reference to spawners
	// Setup first 20 rounds manually
	// Setup how many fish FishSpawner can spawn
	// Calculate automatic rounds after 20

	public Round[] _manualRounds;
	[HideInInspector] public int _currentRound;


	[HideInInspector] public int _fishLeftToSpawn;
	private bool _roundInProgress;
	private GameGod _gg;

	private void Start()
	{
		_roundInProgress = true;
		_gg = GetComponent<GameGod>();

		Debug.Log("GOD _gg: " + _gg);
		foreach(FishSpawnerController fishSpawnerCtrl in _manualRounds[0]._fishSpawnerControllers)
		{
			fishSpawnerCtrl.Start();
			fishSpawnerCtrl._gg = _gg;
			foreach(Fish fish in fishSpawnerCtrl._fishToSpawn)
			{
				_gg._totalFish += fish._fishSpawnAmount;
				Debug.Log("AddingFish:" + fish._fishSpawnAmount);
				Debug.Log("TotalFish RG: " + _gg._totalFish);
			}
		}
	}

	private void Update()
	{
		if(_roundInProgress)
		{
			foreach(FishSpawnerController fishSpawnerCtrl in _manualRounds[_currentRound]._fishSpawnerControllers)
			{
				fishSpawnerCtrl.Update();
			}
		}
	}

	public void EndRound()
	{
		_currentRound++;
		_roundInProgress = false;
		if(_currentRound < _manualRounds.Length)
		{
			StartRound();
		}
	}

	private void StartRound()
	{
		_roundInProgress = true;

		foreach(FishSpawnerController fishSpawnerCtrl in _manualRounds[_currentRound]._fishSpawnerControllers)
		{
			fishSpawnerCtrl.Start();
			fishSpawnerCtrl._gg = _gg;
			foreach(Fish fish in fishSpawnerCtrl._fishToSpawn)
				_gg._totalFish += fish._fishSpawnAmount;
		}
	}
}
