using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATMMoneyProducer : MonoBehaviour
{
    private Transform moneyPlaceParent;
    [SerializeField] private Transform moneyParent;
    [SerializeField] private float timeToProcuedMoney;
    [SerializeField] private GameObject moneyPrefab;
    [SerializeField] private List<Transform> moneyPlaces = new List<Transform>();
   
    private void OnEnable()
    {
        ATMInteraction.OnProduceMoneyHandler += ProduceMoney;
    }
    private void Awake()
    {
        moneyPlaceParent = GameObject.FindGameObjectWithTag("MoneyLocation").transform;
        for (int i = 0; i < moneyPlaceParent.childCount; i++)
        {
            moneyPlaces.Add(moneyPlaceParent.GetChild(i));
        }
    }


    

    private void ProduceMoney(int index,float yAxis)
    {
        GameObject money = Instantiate(moneyPrefab);
        money.transform.position = this.gameObject.transform.parent.transform.position;
        money.transform.localRotation = Quaternion.Euler(90f, 180f, 180f);
        money.transform.SetParent(moneyParent);
        money.transform.DOJump(new Vector3(moneyPlaces[index].position.x, moneyPlaces[index].position.y + yAxis,
            moneyPlaces[index].position.z), 2f, 1, 0.5f).SetEase(Ease.OutQuad);
       
        
    }
    private void OnDisable()
    {
        ATMInteraction.OnProduceMoneyHandler -= ProduceMoney;
    }

}
