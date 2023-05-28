using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBox : MonoBehaviour {

    public Transform respawnPoint;

    public void OnTriggerEnter2D(Collider2D other) {

        if (other.GetComponent<BoxCollider2D>().tag == "Box") {

            other.GetComponent<BoxCollider2D>().gameObject.GetComponent<Respawn>().RespawnGameObject(respawnPoint);

        }        

    }

}
