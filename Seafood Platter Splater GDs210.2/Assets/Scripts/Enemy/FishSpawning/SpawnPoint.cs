using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawns a specific object at point (currently the object must be a EnemyController.
public class SpawnPoint : MonoBehaviour 
{
	public void SpawnObject(GameObject _objectToSpawn, GameGod gg)
	{
		GameObject spawnedObject = Instantiate(_objectToSpawn, transform.position, transform.rotation);
		spawnedObject.GetComponentInChildren<EnemyController>()._gg = gg;
	}
}
