using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderingBehaviour : StateMachineBehaviour
{

    public float wanderRadius;
    public float wanderTimer;

    private float timer;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = wanderTimer;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = SetRandomPosition(animator.transform.position, wanderRadius, -1);
            animator.GetComponent<NavMeshAgent>().SetDestination(newPos);
            timer = 0;
        } else if (animator.GetComponent<NavMeshAgent>().remainingDistance < 0.4f)
        {
            Vector3 newPos = SetRandomPosition(animator.transform.position, wanderRadius, -1);
            animator.GetComponent<NavMeshAgent>().SetDestination(newPos);
            timer = 0;
        }
    }

    private Vector3 SetRandomPosition(Vector3 origin, float dist, int layerMask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * dist;

        randomDirection += origin;
        NavMeshHit navMeshHit;

        NavMesh.SamplePosition(randomDirection, out navMeshHit, dist, layerMask);

        return navMeshHit.position;
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
