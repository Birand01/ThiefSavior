using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyInteraction : InteractionBase
{
    public static event Action<Transform> OnAddMoneyToListHandler;
    public static event Action<int> OnTotalMoneyCountHandler;
    public delegate void OnPlayerCollectMoneySoundHandler(string name, bool state);
    public static event OnPlayerCollectMoneySoundHandler OnPlayerCollectMoneySound;
   
    [SerializeField] private int moneyValue=1;
    private void OnEnable()
    {
        PlayerHealth.OnPlayerRagdollHandler += DisableTrigger;
    }
    protected override void OnTriggerEnterAction(Collider collider)
    {
        OnPlayerCollectMoneySound?.Invoke("MoneyCollectSound", true);
        OnTotalMoneyCountHandler?.Invoke(moneyValue);
        OnAddMoneyToListHandler?.Invoke(this.transform);
      
    }
    
    protected override void OnTriggerExitAction(Collider other)
    {
        base.OnTriggerExitAction(other);
        OnPlayerCollectMoneySound?.Invoke("MoneyCollectSound", false);

    }

    private void DisableTrigger()
    {
        this._collider.isTrigger = false;
        this.gameObject.AddComponent<Rigidbody>();
    }
   
    private void OnDisable()
    {
        PlayerHealth.OnPlayerRagdollHandler -= DisableTrigger;

    }

}
