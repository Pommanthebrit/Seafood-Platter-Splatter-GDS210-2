using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner
{
	private FishSpawnerController _spawnCtrl;
	private int _fishSpawnID;
	private float _spawnFrequency;
	private float _nextSpawn;
	private int _fishLeft;

	public FishSpawner(float spawnFrequency, int fishSpawnID, int fishSpawnAmount, FishSpawnerController spawnCtrl)
	{
		_spawnFrequency = spawnFrequency;
		_fishSpawnID = fishSpawnID;
		_fishLeft = fishSpawnAmount;
		_spawnCtrl = spawnCtrl;
		_nextSpawn = Time.time + _spawnFrequency;
	}

	public void Update()
	{
		if(_nextSpawn < Time.time && _fishLeft > 0)
		{
			_nextSpawn = Time.time + _spawnFrequency;
			_spawnCtrl.SpawnFish(_fishSpawnID);
			_fishLeft--;
		}
	}
}
