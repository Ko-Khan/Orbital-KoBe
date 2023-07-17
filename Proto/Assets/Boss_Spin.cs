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
       spinPoint1 = GameObject.FindWithTag("Spin1").transform;
       spinPoint2 = GameObject.FindWithTag("Spin2").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if (!spin1)
       {
        Boss.transform.position = Vector3.MoveTowards(spinPoint1.position, Boss.transform.position, speed * Time.deltaTime);
       } else if (!spin2)
       {
        Boss.transform.position = Vector3.MoveTowards(spinPoint2.position, Boss.transform.position, speed * Time.deltaTime);
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
