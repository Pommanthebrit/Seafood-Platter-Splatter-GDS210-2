using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contains all data for a specific round.
[CreateAssetMenu(fileName = "Round", menuName = "Rounds/Round", order = 1)] // Creates a menu item.
public class Round : ScriptableObject 
{
	[Header("Round Options")]
	[Tooltip("Perfect round bonus will add a specfied score to the players total score if there is a perfect round.")]
	public int _perfectRoundBonus;

	[Header("Fish Spawning")]
	[Tooltip("Add a certain amount of fish spawner controllers and edit the values in them to your liking to control: " +
		"The amount of fish to spawn, the type of fish, and the spawn point of which you want them to spawn at")]
	public FishSpawnerController[] _fishSpawnerControllers;
}
