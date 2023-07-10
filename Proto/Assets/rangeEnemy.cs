using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeEnemy : MonoBehaviour
{

    private GameObject target;

    public GameObject projectile;

    public float reloadTime;

    private float shootTime;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (target.GetComponent<Transform>().position.x > transform.x ) 
        {
           projectile.GetComponent<projectile>()
        } */

        if (Time.time > shootTime)
        {
            projectile.GetComponent<Projectile>().setDirection(transform.localScale.x * -1f);
            animator.SetTrigger("Shoot");
            shootTime = Time.time + reloadTime;
        }
    }

    void Shoot() 
    {
    Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
