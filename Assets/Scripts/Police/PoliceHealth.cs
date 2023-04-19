using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceHealth : HealthBase
{
    public delegate void OnPoliceDeadAnimationHandler(GameObject gameObject, string animationName);
    public static event OnPoliceDeadAnimationHandler OnPoliceDeadAnimation;

    public delegate void DecreasePoliceAmountHandler(int a);
    public static event DecreasePoliceAmountHandler OnDecreasePoliceAmount;
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    protected override void CheckIfDead()
    {
       if(Health<=0)
        {
            StartCoroutine(DisableCoroutine());
          
        }
    }

    private IEnumerator DisableCoroutine()
    {
        OnDecreasePoliceAmount?.Invoke(1);
        OnPoliceDeadAnimation?.Invoke(this.gameObject, "Dead");
        this.gameObject.GetComponent<PoliceManager>().agent.isStopped = true;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }
   

}
