using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Weapon")) {
            if (Input.GetKeyDown(KeyCode.C)) {
                other.GetComponent<EquipWeapon>().Equip();
            }   
        }    
    }
}
