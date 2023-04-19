using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class UnlockBuilding : MonoBehaviour
{
    public delegate void OnPlayerStopDropMoneyHandler();
    public static event OnPlayerStopDropMoneyHandler OnPlayerStopDropMoney;
    
    [SerializeField] private TMP_Text unlockText;
    [SerializeField] private int moneyAdded, totalMoney,gunScaleFactor;
    [SerializeField] private GameObject buildingPrefab,artPrefab;
    private void Awake()
    {
        moneyAdded = 0;
        unlockText.text = string.Format("{0}/{1}", moneyAdded, totalMoney);
    }
    private void Update()
    {
        buildingPrefab.transform.Rotate(Vector3.up * 200 * Time.deltaTime);

    }

    internal void UnlockItem(int num)
    {
        
            moneyAdded++;
       
        unlockText.text = string.Format("{0}/{1}", moneyAdded, totalMoney);
        unlockText.DOBlendableColor(Color.green, 0.5f).OnComplete(() =>
        unlockText.DOColor(Color.white,0.2f));
        if(moneyAdded>=totalMoney && !buildingPrefab.activeInHierarchy)
        {
            OnPlayerStopDropMoney?.Invoke();
            this.gameObject.GetComponentInChildren<SphereCollider>().enabled = false;
            StartCoroutine(ScaleUpBuilding());
            artPrefab.SetActive(false);
        }
       
         
    }

    private IEnumerator ScaleUpBuilding()
    {
        yield return null;
        buildingPrefab.SetActive(true);
        buildingPrefab.transform.DOScale(gunScaleFactor, 1).OnComplete(()=>
        buildingPrefab.transform.DOLocalJump(buildingPrefab.transform.localPosition,2,2,1));
    }

}
