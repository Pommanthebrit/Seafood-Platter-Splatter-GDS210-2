using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class simply controls the spawning of fish using a timer. It condensed the amount of code required to do so in one class.
public class FishSpawner
{
	// References.
	private FishSpawnerController _spawnCtrl;

	// Fish Info.
	private int _fishSpawnID;
	private int _fishLeft;

	// Spawning Info.
	private float _spawnFrequency;
	private float _nextSpawn;

	// Calls on initialisation.
	public FishSpawner(float spawnFrequency, int fishSpawnID, int fishSpawnAmount, FishSpawnerController spawnCtrl)
	{
		// Setting up variables.
		_spawnFrequency = spawnFrequency;
		_fishSpawnID = fishSpawnID;
		_fishLeft = fishSpawnAmount;
		_spawnCtrl = spawnCtrl;

		// Ensures _nextSpawn is correct.
		_nextSpawn = Time.time + _spawnFrequency;
	}

	public void Update()
	{
		// If next spawn time has passed and there are fish left to spawn.
		if(_nextSpawn < Time.time && _fishLeft > 0)
		{
			Spawn();
		}
	}

	// Sends Spawn event to spawnController, sets next spawn and takes a fish from spawn count.
	private void Spawn()
	{
		_nextSpawn = Time.time + _spawnFrequency;
		_spawnCtrl.SpawnFish(_fishSpawnID);
		_fishLeft--;
	}
}
