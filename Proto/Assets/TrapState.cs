using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapState : MonoBehaviour
{
    public float activeDuration;
    public bool trapActive;
    public int trapDamage;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        trapActive = false;
        animator.SetBool("TrapActive", false);
        StartCoroutine(trapPattern(activeDuration));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator trapPattern(float activeDuration) {
        animator.SetBool("TrapActive", true);
        trapActive = true;
        yield return new WaitForSeconds(activeDuration);
        trapActive = false;
        animator.SetBool("TrapActive", false);
        yield return new WaitForSeconds(1f);
        StartCoroutine(trapPattern(activeDuration));
    }

    
    private void OnTriggerEnter2D(Collider2D other) {
        if (trapActive) {
            if (other.CompareTag("Player")) {
            other.gameObject.GetComponent<Health>().TakeDamage(trapDamage);        
            }
        }
    }
}
