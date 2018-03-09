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

	public int _currentRound;
	public Round[] _manualRounds;

	private int _fishToSpawn;
	private bool _roundInProgress;


	private void Start()
	{
	}
}
