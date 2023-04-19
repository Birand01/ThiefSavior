using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowATMTimer : MonoBehaviour
{
    [SerializeField] private GameObject moneyCounterPanel;
    [SerializeField] private TMP_Text atmTimer;
    private void OnEnable()
    {
        ATMInteraction.OnATMTimerActivation += TimerActivation;
        ATMInteraction.OnATMTimerCounterHandler += TimerCounter;
    }
    private void TimerActivation(bool state)
    {
        if(state)
        {
            moneyCounterPanel.SetActive(true);
        }
        else
            moneyCounterPanel.SetActive(false);
    }

    private void TimerCounter(float timer)
    {
        atmTimer.text =Mathf.FloorToInt(timer).ToString();
    }
    private void OnDisable()
    {
        ATMInteraction.OnATMTimerCounterHandler -= TimerCounter;
        ATMInteraction.OnATMTimerActivation -= TimerActivation;

    }
}
