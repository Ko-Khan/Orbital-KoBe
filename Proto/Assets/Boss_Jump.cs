using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Jump : StateMachineBehaviour
{

    [SerializeField] private float speed1;
    [SerializeField] private float speed2;
    [SerializeField] private float duration;

    private Transform jump1;

    private Transform jump2;

    private Transform jump3;

    private Vector3 jumpTo;

    private GameObject Boss;

    private GameObject Player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss = animator.gameObject;
        Player = GameObject.FindWithTag("Player");

        jump1 = Boss.GetComponent<Blacksmith>().jump1;
        jump2 = Boss.GetComponent<Blacksmith>().jump2;
        jump3 = Boss.GetComponent<Blacksmith>().jump3;
        jumpTo = Vector3.zero;
       
    //    Boss.GetComponent<Rigidbody2D>().Sleep();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jump1 = Boss.GetComponent<Blacksmith>().jump1;
        jump2 = Boss.GetComponent<Blacksmith>().jump2;

        if (Boss.transform.position.y >= jump2.transform.position.y - 0.1f || Boss.transform.position.y >= jumpTo.y - 0.1f) 
        {
            animator.SetTrigger("Hover");
        }

        if (Vector2.Distance(Boss.transform.position, Player.transform.position) <= 3) {
            Blacksmith.jumpUp = true;
            jumpTo = jump3.position;
        }

        if (Blacksmith.jumpUp) {
            Boss.GetComponent<Blacksmith>().Jump(duration, jumpTo, speed2);
        } else {

            if (Boss.transform.localScale.x > 0) {
                Boss.GetComponent<Blacksmith>().Jump(duration, jump1.position, speed1);
            } else {
                Boss.GetComponent<Blacksmith>().Jump(duration, jump2.position, speed1);
            }
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
