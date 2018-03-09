using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawns a specific object at point
public class SpawnPoint : MonoBehaviour 
{
	public void SpawnObject(GameObject _objectToSpawn)
	{
		Instantiate(_objectToSpawn, transform.position, transform.rotation);
	}
}
