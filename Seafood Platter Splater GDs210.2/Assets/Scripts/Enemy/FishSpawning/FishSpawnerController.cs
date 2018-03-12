using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FishSpawnerController
{
	[HideInInspector] public GameGod _gg;

	[Header("Spawning Options")]
	[SerializeField] private SpawnPoint _mySpawnPoint;

	[Header("Fish Types")]
	public Fish[] _fishToSpawn;

	private List<FishSpawner> _fishSpawners;

	public void Start()
	{
		// References.
		_fishSpawners = new List<FishSpawner>();

		// Actions.
		InstanstiateFishSpawners();
	}

	public void Update()
	{
		foreach(FishSpawner fishSpawner in _fishSpawners)
		{
			fishSpawner.Update();
		}
	}

	//Creates FishSpawners from Fish data and stores them in a list (_fishSpawners).
	private void InstanstiateFishSpawners()
	{
		for(int index = 0; index < _fishToSpawn.Length; index++)
		{
			FishSpawner fishSpawner = new FishSpawner(_fishToSpawn[index]._spawnFrequency, index, _fishToSpawn[index]._fishSpawnAmount, this);
			_fishSpawners.Add(fishSpawner);
		}
	}

	// Spawns a fish prefab at this controllers spawn point.
	public void SpawnFish(int fishSpawnID)
	{
		_mySpawnPoint.SpawnObject(_fishToSpawn[fishSpawnID]._fishPrefab, _gg);
	}
}
