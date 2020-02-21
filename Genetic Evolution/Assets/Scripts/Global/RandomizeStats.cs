using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeStats : MonoBehaviour
{
    [SerializeField] private float minMovementSpeed, maxMovementSpeed;
    [SerializeField] private float minBurningTime, maxBurningTime;
    [SerializeField] private float minEnergyToProcriate, maxEnergyToProcriate;

    private void Awake()
    {
        Object[] tempArray = FindObjectsOfType<Object>();

        for (int i = 0; i < tempArray.Length; i++)
        {
            tempArray[i].movementSpeed = Random.Range(minMovementSpeed, maxMovementSpeed);
            tempArray[i].burningTime = Random.Range(minBurningTime, maxBurningTime);
            tempArray[i].GetComponent<FieldOfView>().energyToProcriate = (int)Random.Range(minEnergyToProcriate, maxEnergyToProcriate);
            tempArray[i].Initialize();
        }
    }

}
