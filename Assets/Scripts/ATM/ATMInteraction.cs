using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ATMInteraction : InteractionBase
{
    [SerializeField] private float timer, totalCount;
    [SerializeField] private int moneyIndex;
    private float yAxis;
    public static event Action<bool> OnATMTimerActivation;
    public static event Action<int,float> OnProduceMoneyHandler;
    public static event Action<float> OnATMTimerCounterHandler;
    public delegate void OnPlayerATMEnteranceHandler(string name,bool state);
    public static event OnPlayerATMEnteranceHandler OnPlayerATMEnteranceSound;
    private void OnEnable()
    {
        PlayerHealth.OnPlayerRagdollHandler += DisableCollider;
    }
    protected override void OnTriggerEnterAction(Collider collider)
    {
        OnPlayerATMEnteranceSound?.Invoke("ATMEnterance", true);
        Debug.Log("ATM ENTERANCE");        
    }
     
    protected override void OnTriggerStayAction(Collider other)
    {
        timer += Time.deltaTime;
        OnATMTimerCounterHandler?.Invoke(timer);
        OnATMTimerActivation?.Invoke(true);
        if(timer>=totalCount)
        {
           
            OnProduceMoneyHandler?.Invoke(moneyIndex,yAxis);
            moneyIndex++;
            if(moneyIndex>=8)
            {
                moneyIndex = 0;
                yAxis += 0.3f;
            }
            OnATMTimerActivation?.Invoke(false);
            timer = 0;
        }
      
    }

    private void DisableCollider()
    {
        this._collider.enabled = false;
    }
  

    protected override void OnTriggerExitAction(Collider other)
    {
        Debug.Log("ATM EXIT");
        yAxis =0f;
        timer = 0f;
        moneyIndex = 0;
        OnATMTimerActivation?.Invoke(false);
        OnPlayerATMEnteranceSound?.Invoke("ATMEnterance", false);

    }
    private void OnDisable()
    {
        PlayerHealth.OnPlayerRagdollHandler -= DisableCollider;

    }
}
 