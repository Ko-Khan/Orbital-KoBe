using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blacksmith : MonoBehaviour
{
    public GameObject hammer;

    public float speed;

    public Transform jump;

    public Transform spinPoint1;

    public Transform spinPoint2l;

    private Animator animator;

    private Vector3 landingDirection;

    private bool landing = false;

    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player");
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (landing) 
        {
              transform.Translate(landingDirection * Time.deltaTime * speed);

        }

        
        
    }

    void leap()
    {

        transform.position = jump.position;
        animator.SetTrigger("Launch");


    }

    void Throw()
    {


        Instantiate(hammer, transform.position, Quaternion.identity);
        landingDirection = Player.transform.position - transform.position;
        Invoke("land", 1.0f);
        
        
    }

    public void land()
    {
        landing = true;
        animator.SetTrigger("Land");
        

    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (landing)
        {
            landing = false;
            animator.SetTrigger("Touchdown");
        }

        landing = false;


    }

    void SpinDash()
    {
        animator.SetBool("Spin", true);
    }
}