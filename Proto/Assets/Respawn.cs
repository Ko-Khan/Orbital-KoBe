using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    // Update is called once per frame
    public void RespawnGameObject(Transform respawnPoint) {

        this.transform.position = respawnPoint.position;
        
    }
}
