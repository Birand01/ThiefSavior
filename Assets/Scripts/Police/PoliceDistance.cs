using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceDistance : DistanceBase
{
    protected override void Awake()
    {
        base.Awake();
        attackableObjectName = "Player";
    }
    protected override void Start()
    {
        attackableObject = GameObject.FindGameObjectWithTag(attackableObjectName).transform;

    }
}
