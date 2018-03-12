using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Fish
{
	[Header("Fish Options")]

	[Tooltip("Every 'x' seconds a fish of this type spawns.")]
	public float _spawnFrequency;

	[Tooltip("The amount of fish of this type that will spawn")]
	public int _fishSpawnAmount;

	[Tooltip("The prefab of the fish to spawn")]
	public GameObject _fishPrefab;
}
