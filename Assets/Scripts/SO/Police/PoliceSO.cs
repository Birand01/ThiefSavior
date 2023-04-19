using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoliceConfiguration", menuName = "ScriptableObjects/PoliceConfiguration", order = 1)]

public class PoliceSO : ScriptableObject
{
    public float health;

    internal void SetUpPolice(PoliceConfiguration policeConfiguration)
    {
        policeConfiguration.GetComponent<PoliceHealth>().Health = health;
        policeConfiguration.GetComponent<PoliceHealth>().healthBarSlider.maxValue = health;
        policeConfiguration.GetComponent<PoliceHealth>().healthBarSlider.value = policeConfiguration.GetComponent<PoliceHealth>().Health;
    }
}
