using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawnerController : MonoBehaviour 
{
	[SerializeField] private Fish[] _fishToSpawn;
	private List<FishSpawner> _fishSpawners;

	void Start()
	{
		_fishSpawners = new List<FishSpawner>();

		for(int index = 0; index < _fishToSpawn.Length; index++)
		{
			FishSpawner fishSpawner = new FishSpawner(_fishToSpawn[index]._spawnFrequency, index, this);
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
		Instantiate(_fishToSpawn[fishSpawnID]._fishPrefab, transform.position, transform.rotation);
	}
}
