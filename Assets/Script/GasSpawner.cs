using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasSpawner : MonoBehaviour {
    private bool isInGameArea;
    public bool isSpawning = true;
    [SerializeField] private float spawnTimer = 5f;
    [SerializeField] private GameObject gas;
    private void Start() {
        StartCoroutine(SpawnGasses());
    }

    private IEnumerator SpawnGasses() {
        while (isSpawning) {
            Instantiate(this.gas, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(this.spawnTimer);
        }
    }
}
