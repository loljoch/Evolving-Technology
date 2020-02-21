using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{

    private WaitForSeconds snowFallTime;
    [SerializeField] private float snowDelay;
    [SerializeField] private GameObject snowFlake;
    private static List<GameObject> fallingSnowFlakes = new List<GameObject>();
    private static List<GameObject> waitingSnowFlakes = new List<GameObject>();
    private Bounds colliderBounds;

    private void Start()
    {
        snowFallTime = new WaitForSeconds(snowDelay);
        colliderBounds = GetComponent<BoxCollider>().bounds;
        StartCoroutine(CreateSnow());
    }

    private Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z));
    }

    IEnumerator CreateSnow()
    {
        yield return snowFallTime;
        if (NeedMoreSnow())
        {
            SpawnSnow();
        }

        waitingSnowFlakes[waitingSnowFlakes.Count -1].transform.position = RandomPointInBounds(colliderBounds);
        waitingSnowFlakes[waitingSnowFlakes.Count - 1].SetActive(true);
        fallingSnowFlakes.Add(waitingSnowFlakes[waitingSnowFlakes.Count - 1]);
        waitingSnowFlakes.RemoveAt(waitingSnowFlakes.Count - 1);
        StartCoroutine(CreateSnow());
    }

    private bool NeedMoreSnow()
    {
        if(waitingSnowFlakes.Count == 0)
        {
            return true;
        }

        return false;
    }

    private void SpawnSnow()
    {
        waitingSnowFlakes.Add(Instantiate(snowFlake, transform));
    }

    public static void AddObjectToWaiting(GameObject snowflake)
    {
        fallingSnowFlakes.Remove(snowflake);
        waitingSnowFlakes.Add(snowflake);
    }
}
