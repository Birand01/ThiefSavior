using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletConfiguration", menuName = "ScriptableObjects/BulletConfiguration", order = 3)]

public class BulletSO : ScriptableObject
{
    public float maxDistance, speed,damage;
    
    public void SetUpBullet(Bullet bullet)
    {
        bullet.maxDistance = maxDistance;
        bullet.speed = speed;
        bullet.gameObject.GetComponent<BulletInteraction>().damage = damage;
    }
}
