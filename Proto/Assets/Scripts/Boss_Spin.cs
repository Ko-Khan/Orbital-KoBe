using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Spin : StateMachineBehaviour
{
    public float speed;

    private GameObject Boss;

    public Transform spinPoint1;

    public Transform spinPoint2;

    private bool spin1;

    private bool spin2;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       Boss = animator.gameObject;

       spinPoint1 = Boss.GetComponent<Blacksmith>().spinPoint1;

       spinPoint2 = Boss.GetComponent<Blacksmith>().spinPoint2;

       spin1 = false;
       spin2 = false;
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      spinPoint1 = Boss.GetComponent<Blacksmith>().spinPoint1;
      spinPoint2 = Boss.GetComponent<Blacksmith>().spinPoint2;

       if (!spin1)
       {
        Boss.transform.position = Vector2.MoveTowards(Boss.transform.position, spinPoint1.position, speed * Time.deltaTime);

        if (Boss.transform.position.x <= spinPoint1.position.x) {
         spin1 = true;
        }

       } else if (!spin2)
       {
        Boss.transform.position = Vector2.MoveTowards(Boss.transform.position, spinPoint2.position, speed * Time.deltaTime);

        if (Boss.transform.position.x >= spinPoint2.position.x) {
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
