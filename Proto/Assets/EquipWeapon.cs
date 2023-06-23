using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{
    public Transform weaponHolder;
    private Vector3 newScale = new Vector3(2.0f, 0.7f, 1.0f);
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
           Equip();
        }    
    }

    public void Equip() {
        this.transform.parent = weaponHolder.transform;
        this.transform.position = weaponHolder.transform.position;
        this.transform.localScale = newScale;
        //GetComponent<SpriteRenderer>().enabled = false;
    }
}
