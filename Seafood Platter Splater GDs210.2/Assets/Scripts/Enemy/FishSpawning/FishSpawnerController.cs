using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FishSpawnerController
{
	[HideInInspector] public GameGod _gg;
	[SerializeField] private SpawnPoint _mySpawnPoint;
	public Fish[] _fishToSpawn;

	private Round _round;
	private List<FishSpawner> _fishSpawners;

	public void Start()
	{
		_fishSpawners = new List<FishSpawner>();

		for(int index = 0; index < _fishToSpawn.Length; index++)
		{
			FishSpawner fishSpawner = new FishSpawner(_fishToSpawn[index]._spawnFrequency, index, _fishToSpawn[index]._fishSpawnAmount, this);
			_fishSpawners.Add(fishSpawner);
			_gg._totalFish += _fishToSpawn[index]._fishSpawnAmount;

			Debug.Log("Total Fish: " + _gg._totalFish);
		}
	}

	public void Update()
	{
		foreach(FishSpawner fishSpawner in _fishSpawners)
		{
			fishSpawner.Update();
		}
	}

	public void SpawnFish(int fishSpawnID)
	{
		Debug.Log("CRTL _gg: " + _gg);
		_mySpawnPoint.SpawnObject(_fishToSpawn[fishSpawnID]._fishPrefab, _gg);
	}
}
