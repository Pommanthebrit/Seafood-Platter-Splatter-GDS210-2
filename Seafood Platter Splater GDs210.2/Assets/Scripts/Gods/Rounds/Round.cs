using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contains all data for a specific round.
[CreateAssetMenu(fileName = "Round", menuName = "Rounds/Round", order = 1)] // Creates a menu item.
public class Round : ScriptableObject 
{
	public int _perfectRoundBonus;
	public FishSpawnerController[] _fishSpawnerControllers;
}
