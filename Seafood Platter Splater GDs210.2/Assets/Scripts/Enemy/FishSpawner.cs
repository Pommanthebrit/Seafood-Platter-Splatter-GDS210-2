using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner
{
	private FishSpawnerController _spawnCtrl;
	private int _fishSpawnID;
	private float _spawnFrequency;
	private float _nextSpawn;

	public FishSpawner(float spawnFrequency, int fishSpawnID, FishSpawnerController spawnCtrl)
	{
		_spawnFrequency = spawnFrequency;
		_fishSpawnID = fishSpawnID;
		_spawnCtrl = spawnCtrl;
		_nextSpawn = Time.time + _spawnFrequency;
		Debug.Log("Test");
	}

	public void Update()
	{
		if(_nextSpawn < Time.time)
		{
			_nextSpawn = Time.time + _spawnFrequency;
			_spawnCtrl.SpawnFish(_fishSpawnID);
		}
	}
}
