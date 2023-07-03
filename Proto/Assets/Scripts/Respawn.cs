using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public Vector3 spawnPoint;
    public Vector3 respawnPoint;

    private void Awake() {
        spawnPoint = this.transform.position;
    }

    private void Start() {
        if (respawnPoint == Vector3.zero) {
            respawnPoint = spawnPoint;
        } 
    }

    public void updateRespawnPoint(Vector3 checkpoint) {
        respawnPoint = checkpoint;
    }
}
