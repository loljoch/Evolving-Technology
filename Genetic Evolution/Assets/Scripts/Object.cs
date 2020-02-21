using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Object : MonoBehaviour
{
    public float energy;
    public float movementSpeed;
    public float burningTime;
    public int generation;

    private Animator animator;
    private Breeder breeder;

    public void Initialize()
    {
        animator = GetComponent<Animator>();
        breeder = FindObjectOfType<Breeder>();
        ConnectStats();
        StartCoroutine(BurningEnergy());
    }

    public void SwitchToChasing(Transform target)
    {
        animator.SetBool("Chasing", true);
        animator.GetBehaviour<ChasingBehaviour>().target = target;
    }

    public void SwitchToIdle()
    {
        animator.SetBool("Idle", true);

    }

    public void SwitchToWandering()
    {
        animator.SetBool("Chasing", false);
        animator.SetBool("Idle", false);

    }

    private void ConnectStats()
    {
        GetComponent<NavMeshAgent>().speed = movementSpeed;
    }

    public void EatFood(Transform target)
    {
        energy += target.GetComponent<Food>().energy;
        Destroy(target.gameObject);
        animator.SetBool("Chasing", false);
    }

    public IEnumerator Breed()
    {
        SwitchToIdle();
        energy -= 5;
        breeder.AddBreed(this);
        yield return new WaitForSeconds(0.6f);
        SwitchToWandering();
    }

    private IEnumerator BurningEnergy()
    {
        yield return new WaitForSeconds(2f);
        energy -= burningTime;
        TestForDeath();
        StartCoroutine(BurningEnergy());
    }

    private void TestForDeath()
    {
        if(energy <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

  
}
