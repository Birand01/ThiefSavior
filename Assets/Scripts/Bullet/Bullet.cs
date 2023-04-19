using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletSO bulletSO;
    internal float speed, maxDistance;
    private Vector3 startPosition;
    private float conquaredDistance;
    private Rigidbody _rb;
    private void OnEnable()
    {
        bulletSO.SetUpBullet(this);
    }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        conquaredDistance = Vector3.Distance(transform.position, startPosition);
        if(conquaredDistance>maxDistance)
        {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        _rb.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
      
    public void Inýtýalize()
    {
        startPosition = transform.position;
        _rb.velocity = transform.forward * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        DisableObject();
    }
}
