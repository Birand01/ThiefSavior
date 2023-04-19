using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "ScriptableObjects/PlayerConfiguration", order = 0)]
public class PlayerSO : ScriptableObject
{
    public float health;

    internal void SetUpPlayer(PlayerConfiguration playerConfiguration)
    {
        playerConfiguration.GetComponent<PlayerHealth>().Health = health;
        playerConfiguration.GetComponent<PlayerHealth>().healthBarSlider.maxValue = health;
        playerConfiguration.GetComponent<PlayerHealth>().healthBarSlider.value = playerConfiguration.GetComponent<PlayerHealth>().Health;
    }
}
