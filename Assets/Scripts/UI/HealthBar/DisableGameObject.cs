using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObject : MonoBehaviour
{
    private void OnEnable()
    {
        PoliceSpawner.OnLevelSuccessfullyEnd += DisableJoystick;
        PlayerHealth.OnPlayerRagdollHandler += DisableJoystick;
    }
    private void OnDisable()
    {
        PoliceSpawner.OnLevelSuccessfullyEnd -= DisableJoystick;
        PlayerHealth.OnPlayerRagdollHandler -= DisableJoystick;
    }

    private void DisableJoystick()
    {
        this.gameObject.SetActive(false);
    }
}
