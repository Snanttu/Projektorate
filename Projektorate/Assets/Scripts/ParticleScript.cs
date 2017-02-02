using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour {

    private ParticleSystem _particleSystem;

	// Use this for initialization
	void Start () {
        _particleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!_particleSystem.isPlaying)
        {
            Destroy(gameObject);
        }
	}
}
