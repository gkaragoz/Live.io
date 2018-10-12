using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour {

    public float lifeTime;

    private ParticleSystem FX;

	void Start () {
        FX = GetComponent<ParticleSystem>();

        lifeTime = FX.main.startLifetime.constant;

        DestroyItself();
	}
	
    private void DestroyItself() {
        Destroy(gameObject, lifeTime);
    }
}
