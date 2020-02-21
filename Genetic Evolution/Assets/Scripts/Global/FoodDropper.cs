using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoodDropper : MonoBehaviour
{

    [SerializeField] private float foodTimer;
    [SerializeField] private float positionDistance;
    [SerializeField] private GameObject food;

    private void Start()
    {
        StartCoroutine(FoodTimer());
    }

    IEnumerator FoodTimer()
    {
        yield return new WaitForSeconds(foodTimer);
        GameObject newFood = Instantiate(food,  SetRandomPosition(transform.position, positionDistance, -1) + Vector3.up * 13, Quaternion.identity);
        StartCoroutine(FoodTimer());
    }

    private Vector3 SetRandomPosition(Vector3 origin, float dist, int layerMask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * dist;

        randomDirection += origin;
        NavMeshHit navMeshHit;

        NavMesh.SamplePosition(randomDirection, out navMeshHit, dist, layerMask);

        return navMeshHit.position;
    }
}
