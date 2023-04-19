using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceConfiguration : MonoBehaviour
{
    [SerializeField] private PoliceSO policeSO;
    private void Awake()
    {
        policeSO.SetUpPolice(this);
    }
}
