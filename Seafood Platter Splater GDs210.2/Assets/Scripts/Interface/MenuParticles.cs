using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuParticles : MonoBehaviour {

	public ParticleSystem initialBubble;

	void Start () {
		Invoke ("InitialBubbleStop", 0.5f);
	}

	void InitialBubbleStop () {		
		ParticleSystem.EmissionModule cease = initialBubble.emission;
		cease.enabled = false;
	}
}