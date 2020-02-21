using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Description : MonoBehaviour
{
    public Object currentTerraBot;
    [SerializeField] private TextMeshProUGUI generation, speed, burningSpeed, energyLeft;

    public void AssignBot(Object terraBot)
    {
        currentTerraBot = terraBot;
        generation.SetText("Generation: " + terraBot.generation.ToString());
        speed.SetText("Speed: " + terraBot.movementSpeed.ToString());
        burningSpeed.SetText("Burning Time: " + terraBot.burningTime.ToString());
        energyLeft.SetText("Energy left: " + terraBot.energy.ToString());
    }

    private void Update()
    {
        energyLeft.SetText("Energy left: " + currentTerraBot.energy.ToString());
    }

}
