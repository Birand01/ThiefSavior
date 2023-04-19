using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timeCounterText;
    [SerializeField] private GameObject moneyStealPrefab;
    private void OnEnable()
    {
        ATMInteraction.OnATMTimerCounterHandler += IncreaseTimer;
        ATMInteraction.OnATMTimerActivation += MoneyPanelActivation;
    }

    private void IncreaseTimer(float timer)
    {
        timeCounterText.text = Mathf.FloorToInt(timer).ToString();
    }
    private void MoneyPanelActivation(bool state)
    {
        if (state)
        {
            moneyStealPrefab.gameObject.SetActive(true);
        }
        else
            moneyStealPrefab.gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        ATMInteraction.OnATMTimerCounterHandler -= IncreaseTimer;
        ATMInteraction.OnATMTimerActivation -= MoneyPanelActivation;
    }
}
