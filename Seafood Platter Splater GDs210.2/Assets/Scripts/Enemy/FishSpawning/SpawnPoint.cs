using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawns a specific object at point
public class SpawnPoint : MonoBehaviour 
{
	public void SpawnObject(GameObject _objectToSpawn, GameGod gg)
	{
		print("SP _gg: " + gg);
		GameObject spawnedObject = Instantiate(_objectToSpawn, transform.position, transform.rotation);
		spawnedObject.GetComponentInChildren<EnemyController>()._gg = gg;
	}
}
