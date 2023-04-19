using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceAnimation : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        PoliceHealth.OnPoliceDeadAnimation += AnimationTrigger;
        PoliceAnimationEvents.OnPoliceWinAnimation += AnimationTrigger;
        PoliceAnimationEvents.OnPoliceAttackAnimation += AnimationState;
        PoliceAnimationEvents.OnPoliceChaseAnimation += AnimationState;
    }
    private void AnimationState(GameObject gameObject, string name, bool state)
    {
        gameObject.GetComponent<Animator>().SetBool(name, state);
    }
    private void AnimationTrigger(GameObject gameObject, string name)
    {
        gameObject.GetComponent<Animator>().SetTrigger(name);
    }

    private void OnDisable()
    {
        PoliceHealth.OnPoliceDeadAnimation -= AnimationTrigger;
        PoliceAnimationEvents.OnPoliceAttackAnimation -= AnimationState;
        PoliceAnimationEvents.OnPoliceChaseAnimation -= AnimationState;
        PoliceAnimationEvents.OnPoliceChaseAnimation -= AnimationState;
    }
}
