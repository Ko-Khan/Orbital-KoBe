using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blacksmith : MonoBehaviour
{
    public GameObject hammer;

    public float speed;

    public Transform jump1;

    public Transform jump2;

    public Transform jump3;

    public static bool jumpUp;

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

        jumpUp = false;

        GetComponent<Rigidbody2D>().isKinematic = false;
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

    // void leap(Vector3 jumpPosition)
    // {
    //     transform.position = jumpPosition;
    //     animator.SetTrigger("Launch");
    // }

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

    public IEnumerator JumpFor(float duration, Vector3 jumpPosition, float speed) {
        transform.position = Vector2.MoveTowards(transform.position, jumpPosition, speed * Time.deltaTime);
        yield return new WaitForSeconds(duration);

        if (jumpUp) {
            jumpUp = false;
        }
    }

    public void Jump(float duration, Vector3 jumpPosition, float speed) {
        StartCoroutine(JumpFor(duration, jumpPosition, speed));
    }

    void SpawnNextSceneTransition() {
        SceneTransition.SetActive(true);
    }
}
