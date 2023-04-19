using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagdoll : RagdollBase
{
    private void OnEnable()
    {
        PlayerHealth.OnPlayerRagdollHandler += EnableRagdoll;
    }
    private void OnDisable()
    {
        PlayerHealth.OnPlayerRagdollHandler -= EnableRagdoll;
    }
}
