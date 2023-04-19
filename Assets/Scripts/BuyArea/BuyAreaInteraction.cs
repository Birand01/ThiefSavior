using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyAreaInteraction : InteractionBase
{
    public delegate void OnPlayerStartDropMoneyHandler(Transform transform,UnlockBuilding unlockBuilding);
    public static event OnPlayerStartDropMoneyHandler OnPlayerStartDropMoney;

    public delegate void OnPlayerFinishDropMoneyHandler();
    public static event OnPlayerFinishDropMoneyHandler OnPlayerStopDropMoney;

   
   
    
    protected override void OnTriggerEnterAction(Collider collider)
    {
        OnPlayerStartDropMoney?.Invoke(this.transform,this.gameObject.GetComponentInParent<UnlockBuilding>());
    }
    protected override void OnTriggerStayAction(Collider other)
    {
        
    }



    protected override void OnTriggerExitAction(Collider other)
    {
        OnPlayerStopDropMoney?.Invoke();
    }
}
