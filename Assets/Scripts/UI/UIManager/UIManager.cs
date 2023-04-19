using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public delegate void OnLevelEndEventHandler();
    public static event OnLevelEndEventHandler OnLevelEnd;
    [SerializeField] private TMP_Text moneyCounterText,policeCounterText,levelEndText;
    [SerializeField] private GameObject levelEndUI,levelFailUI;
  
    private void OnEnable()
    {
        PlayerHealth.OnPlayerRagdollHandler += ShowLevelFailUI;
        SceneManagement.OnSceneCounter += LevelEndTextContext;
        PoliceSpawner.OnLevelSuccessfullyEnd += ShowLevelEndUI;
        PoliceSpawner.OnPoliceCounterText += ShowPoliceNumber;
        MoneyManager.OnTotalMoneyAmountHandler += TotalMoney;
       
    }

   

    private void ShowPoliceNumber(int spawnedPolice)
    {
        policeCounterText.text = spawnedPolice.ToString();
    }

    private void LevelEndTextContext(int levelIndex)
    {
        levelEndText.text = "LEVEL " + levelIndex.ToString() + " COMPLETED";
    }

    private void ShowLevelEndUI()
    {
        ShowLevelUI(levelEndUI, true);
    }
   
    private void ShowLevelFailUI()
    {
        ShowLevelUI(levelFailUI, true);

    }
    private void ShowLevelUI(GameObject gameObject,bool state)
    {
        gameObject.SetActive(state);
    }
   
    private void TotalMoney(int value)
    {
        moneyCounterText.text =value.ToString();
    }
    private void OnDisable()
    {
        PlayerHealth.OnPlayerRagdollHandler -= ShowLevelFailUI;
        SceneManagement.OnSceneCounter -= LevelEndTextContext;
        PoliceSpawner.OnLevelSuccessfullyEnd -= ShowLevelEndUI;
        PoliceSpawner.OnPoliceCounterText -= ShowPoliceNumber;
        MoneyManager.OnTotalMoneyAmountHandler -= TotalMoney;     
    }

}
