using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceAnimationEvents : MonoBehaviour
{
    public delegate void OnPoliceChaseAnimationHandler(GameObject game, string name, bool state);
    public static event OnPoliceChaseAnimationHandler OnPoliceChaseAnimation;
    public delegate void OnPoliceAttackAnimationHandler(GameObject game, string name, bool state);
    public static event OnPoliceAttackAnimationHandler OnPoliceAttackAnimation;

    public delegate void OnPoliceWinAnimationHandler(GameObject game, string name);
    public static event OnPoliceWinAnimationHandler OnPoliceWinAnimation;
    internal void AttackAnimationEvent(bool state)
    {
        OnPoliceAttackAnimation?.Invoke(this.gameObject, "Attack", state);
    }
    internal void ChaseAnimationEvent(bool state)
    {
        OnPoliceChaseAnimation?.Invoke(this.gameObject, "Chase", state);
    }

    internal void WinAnimation()
    {
        OnPoliceWinAnimation?.Invoke(this.gameObject, "Idle");
    }

}
