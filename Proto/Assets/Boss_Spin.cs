using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Spin : StateMachineBehaviour
{
    public float speed;

    private GameObject Boss;

    public GameObject spinPoint1;

    public GameObject spinPoint2;

    private bool spin1;

    private bool spin2;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      spinPoint1 = new GameObject();
      spinPoint2 = new GameObject();

       Boss = animator.gameObject;

       spinPoint1.transform.position = Boss.GetComponent<Blacksmith>().spinPoint1.position;

       spinPoint2.transform.position = Boss.GetComponent<Blacksmith>().spinPoint2.position;

       spin1 = false;
       spin2 = false;
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if (!spin1)
       {
        Boss.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(spinPoint1.transform.position, Boss.transform.position, speed * Time.deltaTime);

        if (Boss.transform.position.x <= spinPoint1.transform.position.x) {
         spin1 = true;
        }

       } else if (!spin2)
       {
        Boss.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(spinPoint2.transform.position, Boss.transform.position, speed * Time.deltaTime);

        if (Boss.transform.position.x >= spinPoint2.transform.position.x) {
         spin2 = true;
        }

       } else {
         animator.SetBool("Spin", false);
       }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
