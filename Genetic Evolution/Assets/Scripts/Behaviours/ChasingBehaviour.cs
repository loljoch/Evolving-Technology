using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingBehaviour : StateMachineBehaviour
{

    public Transform target;
    private Animator animator;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.GetComponent<FieldOfView>().enabled = false;
        animator = animator;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (target != null)
        {
            animator.GetComponent<NavMeshAgent>().SetDestination(target.position);
            if (animator.GetComponent<NavMeshAgent>().remainingDistance < 3.6f)
            {
                if (target.GetComponent<Food>() != null)
                {
                    animator.GetComponent<Object>().EatFood(target);
                } else if (target.GetComponent<Object>() != null)
                {
                    animator.GetComponent<Object>().StartCoroutine(animator.GetComponent<Object>().Breed());
                }
            }
        } else
        {
            animator.GetComponent<Object>().SwitchToWandering();
        }
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    animator.GetComponent<FieldOfView>().enabled = true;
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
