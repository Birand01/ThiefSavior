using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class MoneyManager : MonoBehaviour
{
    public static event Action<int> OnTotalMoneyAmountHandler;
     public delegate void OnMoneyDropSoundHandler(string name, bool state);
    public static event OnMoneyDropSoundHandler OnMoneyDropSound;
  

    [SerializeField] private List<Transform> moneyList=new List<Transform>();
    private Transform moneyHolder;
    [SerializeField] private int totalMoneyAmount;
    private bool state=false;
  
    private void Awake()
    {
     
        moneyHolder = GameObject.FindGameObjectWithTag("MoneyParent").transform;
        moneyList.Add(moneyHolder);
    }


    private void OnEnable()
    {
        UnlockBuilding.OnPlayerStopDropMoney += OnDropExitHandler;
        BuyAreaInteraction.OnPlayerStopDropMoney += OnDropExitHandler;
        BuyAreaInteraction.OnPlayerStartDropMoney += DropMoney;
        PlayerHealth.OnPlayerRagdollHandler += ClearMoneyList;
        MoneyInteraction.OnTotalMoneyCountHandler += IncreaseMoney;
        MoneyInteraction.OnAddMoneyToListHandler += AddNewItem;
    }
    
    private void IncreaseMoney(int value)
    {
        totalMoneyAmount += value;
        OnTotalMoneyAmountHandler?.Invoke(totalMoneyAmount);
    }
    private void DecreaseMoney(int value)
    {
        totalMoneyAmount -= value;
        OnTotalMoneyAmountHandler?.Invoke(totalMoneyAmount);

    }
    private void AddNewItem(Transform _itemToAdd)
    {
        //_itemToAdd.DOKill(true);
       
        _itemToAdd.DOJump(moneyHolder.position + 
        new Vector3(0, 0.025f * moneyList.Count, 0), 0.5f, 1, 0.1f).OnComplete(
         () =>
         {
             _itemToAdd.DOScale(40, 0.5f);
             _itemToAdd.SetParent(moneyHolder, true);
             _itemToAdd.localPosition = new Vector3(0, 0.2f * moneyList.Count, 0);
             _itemToAdd.localRotation = Quaternion.Euler(90f, 180f, 180f);
             moneyList.Add(_itemToAdd.transform);
         } 
         );
       
           
    }

    private void DropMoney(Transform dropPosition,UnlockBuilding unlockBuilding)
    {
        Debug.Log(dropPosition.transform.name);
        StartCoroutine(DropCorotuine(dropPosition,unlockBuilding));
  
    }

    private IEnumerator DropCorotuine(Transform dropPosition,UnlockBuilding unlockBuilding)
    {
            state = true;      
            int counter = moneyList.Count - 1;
        for (int i = counter; i >= 1; i--)
            {
            OnMoneyDropSound?.Invoke("MoneyDropSound", state);
            moneyList.ElementAt(i).parent = dropPosition;
            moneyList[i].DOLocalJump(new Vector3(dropPosition.localPosition.x, dropPosition.localPosition.y - 0.3f,
            dropPosition.localPosition.z), 2, 1, 0.1f).SetEase(Ease.InOutBounce);
            StartCoroutine(Disable(moneyList[i]));
            moneyList[i].gameObject.GetComponent<BoxCollider>().isTrigger = false;
            moneyList.RemoveAt(i);
            unlockBuilding.UnlockItem(1);
            DecreaseMoney(1);
            if (!state)
                {
                    break;
                }
            
            yield return new WaitForSeconds(0.1f);
        }

    }
   
    private void OnDropExitHandler()
    {
        state = false;
        OnMoneyDropSound?.Invoke("MoneyDropSound", state);

    }

    private IEnumerator Disable(Transform list)
    {
        yield return new WaitForSeconds(0.5f);
        list.gameObject.SetActive(false);
    }
   
  

    private void ClearMoneyList()
    {
        for (int i = 1; i < moneyList.Count; i++)
        {
            moneyList.Clear();
        }
    }
    private void OnDisable()
    {
        UnlockBuilding.OnPlayerStopDropMoney -= OnDropExitHandler;
        BuyAreaInteraction.OnPlayerStopDropMoney -= OnDropExitHandler;
        BuyAreaInteraction.OnPlayerStartDropMoney -= DropMoney;
        PlayerHealth.OnPlayerRagdollHandler -= ClearMoneyList;
        MoneyInteraction.OnTotalMoneyCountHandler -= IncreaseMoney;
        MoneyInteraction.OnAddMoneyToListHandler -= AddNewItem;
    }
}
