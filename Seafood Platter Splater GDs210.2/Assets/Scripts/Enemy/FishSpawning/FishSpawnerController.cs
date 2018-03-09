using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FishSpawnerController
{
	[SerializeField] private SpawnPoint _mySpawnPoint;
	[SerializeField] private Fish[] _fishToSpawn;

	private List<FishSpawner> _fishSpawners;

	void Start()
	{
		_fishSpawners = new List<FishSpawner>();

		for(int index = 0; index < _fishToSpawn.Length; index++)
		{
			FishSpawner fishSpawner = new FishSpawner(_fishToSpawn[index]._spawnFrequency, index, _fishToSpawn[index]._fishSpawnAmount, this);
			_fishSpawners.Add(fishSpawner);
		}
	}

	void Update()
	{
		foreach(FishSpawner fishSpawner in _fishSpawners)
		{
			fishSpawner.Update();
		}
	}

	public void SpawnFish(int fishSpawnID)
	{
		_mySpawnPoint.SpawnObject(_fishToSpawn[fishSpawnID]._fishPrefab);
	}
}
