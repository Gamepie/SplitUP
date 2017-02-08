using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour {
	public GameObject Particle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void activate_particle_effect () {
			Particle.GetComponent<ParticleSystem>().enableEmission = true;
}
}
