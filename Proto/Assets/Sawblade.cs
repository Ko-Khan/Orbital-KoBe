using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawblade : MonoBehaviour
{

    public bool trapActive;
    public int trapDamage;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (trapActive) {
                StartCoroutine(damagePlayer(other.gameObject));        
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Player")) {
            if (trapActive) {
                StartCoroutine(damagePlayer(other.gameObject));        
            }
        }
    }

    private IEnumerator damagePlayer(GameObject player) {
        player.GetComponent<Health>().TakeDamage(trapDamage);
        yield return new WaitForSeconds(0.5f);
        if (player.GetComponent<BoxCollider2D>().IsTouching(GetComponent<BoxCollider2D>())) {
            StartCoroutine(damagePlayer(player));
        }
    }
}
