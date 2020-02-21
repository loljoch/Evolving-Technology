using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breeder : MonoBehaviour
{
    private static Breeder instance;
    public static Breeder Instance
    {
        get { return instance; }
        set { instance = value; }
    }

    private void Awake()
    {
        Instance = null;
        if (Instance == null)
        {
            Instance = this;
        } else if (Instance != null)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    private Object breed1, breed2;
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int statDivider = 2;

    public void AddBreed(Object newBreed)
    {
        if(breed1 == null)
        {
            breed1 = newBreed;
        } else
        {
            breed2 = newBreed;
            BreedTogether();
        }
    }

    private void BreedTogether()
    {
        GameObject newBreed = Instantiate(objectPrefab, breed1.transform.position, Quaternion.identity);
        Object newObject = newBreed.GetComponent<Object>();
        newObject.movementSpeed = CalculateGeneticStat(breed1.movementSpeed, breed2.movementSpeed);
        newObject.burningTime = CalculateGeneticStat(breed1.burningTime, breed2.burningTime);
        newObject.GetComponent<FieldOfView>().energyToProcriate = (int)CalculateGeneticStat(breed1.GetComponent<FieldOfView>().energyToProcriate, breed2.GetComponent<FieldOfView>().energyToProcriate);
        newObject.generation = breed1.generation > breed2.generation ? breed1.generation + 1 : breed2.generation + 1;
        newObject.Initialize();
        breed1 = null;
        breed2 = null;
    }

    private float CalculateGeneticStat(float numberOne, float numberTwo)
    {
        float midpoint = (numberOne + numberTwo) / 2;
        float midToNumber = Mathf.Abs(midpoint - numberOne);
        bool randomNumber = (Random.value >= 0.5f) ? true : false;

        float geneticStat = (randomNumber) ? midpoint - (Random.Range(0, midToNumber) / statDivider) : midpoint + (Random.Range(0, midToNumber) / statDivider);

        return geneticStat;

    }
}
