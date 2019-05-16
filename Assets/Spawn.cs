using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawn : MonoBehaviour {

	public GameObject Pear;
    public int pearInterval = 30;
    private int pearTimer = 0;
	public Vector3 pearSpawnOffset = new Vector3(-255f, 1f, 0);
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        pearTimer = (pearTimer + 1) % pearInterval;
        if (pearTimer == 0) {
            SpawnRandomPear();
        }
	}

    void SpawnRandomPear() {
        GameObject pear = Instantiate(Pear);
        pear.transform.position = UnityEngine.Random.insideUnitCircle * 1.5f;
        pear.transform.position += pearSpawnOffset;
    }
}
