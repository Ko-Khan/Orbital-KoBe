using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blacksmith : MonoBehaviour
{
    public GameObject hammer;

    public float speed;

    public Transform jump;

    public Transform spinPoint1;

    public Transform spinPoint2;

    private Animator animator;

    private Vector3 landingDirection;

    private bool landing = false;

    private GameObject Player;

    public float special1Cooldown;

    public float special2Cooldown;
    
    private float timeSinceLastSpinTrigger = 0.0f;

    private float timeSinceLastLeapTrigger = 0.0f; 

    public GameObject SceneTransition;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        Player = GameObject.FindWithTag("Player");

        

        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        timeSinceLastSpinTrigger += Time.deltaTime;

        if (timeSinceLastSpinTrigger  >= special1Cooldown)
        {
            animator.SetBool("Spin", true);

            timeSinceLastSpinTrigger = 0.0f;

        }

        timeSinceLastLeapTrigger += Time.deltaTime;

        if (timeSinceLastLeapTrigger >= special2Cooldown)
        {
            animator.SetTrigger("Launch");
            
            timeSinceLastLeapTrigger = 0.0f;
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
    }
 
    public IEnumerator MakeLandingIn(float airTime) {
        yield return new WaitForSeconds(airTime);
        GetComponent<Rigidbody2D>().WakeUp();
    }

    public void Land(float airTime) {
        StartCoroutine(MakeLandingIn(airTime));
    }

    void SpawnNextSceneTransition() {
        SceneTransition.SetActive(true);
    }
}
