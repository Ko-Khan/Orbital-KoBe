using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public void RespawnGameObject(Transform respawnPoint) {

        this.GetComponent<Animator>().SetBool("IsDead", false);

        this.transform.position = respawnPoint.position;

        this.transform.rotation = respawnPoint.rotation;
        
    }
}
