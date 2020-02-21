using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFlake : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Snow.AddObjectToWaiting(gameObject);
        gameObject.SetActive(false);
    }



}
