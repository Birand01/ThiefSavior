using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunBase : MonoBehaviour
{
    [SerializeField] protected List<Transform> firePoints;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected float reloadDelay;
    [SerializeField] protected bool canShoot = true;
    [SerializeField] protected float currentDelay = 0;

    public delegate void OnPlayerShootSoundHandler(string name, bool state);
    public static event OnPlayerShootSoundHandler OnPlayerShootSound;

 
   
    protected virtual void Update()
    {
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
            {
                canShoot = true;

            }
        }
    }
    protected virtual void OnEnable()
    {
        PlayerDistance.OnPlayerAttack += Shoot;
    }

    protected virtual void OnDisable()
    {
        PlayerDistance.OnPlayerAttack -= Shoot;

    }
    public virtual void Shoot()
    {
        if(canShoot)
        {
            canShoot = false;
            OnPlayerShootSound?.Invoke("BulletSound", false);
            currentDelay = reloadDelay;
            foreach (var firePoint in firePoints)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = firePoint.position;
                bullet.transform.localRotation= firePoint.rotation;
                bullet.GetComponent<Bullet>().Inýtýalize();
                OnPlayerShootSound?.Invoke("BulletSound", true);

            }
        }
    }
  

}
