﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuParticles : MonoBehaviour {

	public ParticleSystem initialBubble;

	void Start () {
		Time.timeScale = 1;
		Invoke ("InitialBubbleStop", 0.5f);
	}

	//Stops bubble animation shortly after entering scene
	void InitialBubbleStop () {		
		ParticleSystem.EmissionModule cease = initialBubble.emission;
		cease.enabled = false;
	}
}