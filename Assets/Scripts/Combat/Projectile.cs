using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Core;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject hitEffect = null;
    [SerializeField] float arrowSpeed = 100f;
    [SerializeField] bool isHoimg = false;
    Health target = null;
    float damage = 0f;
    void Start()
    {
        transform.LookAt(GetAimLocation());

    }
    void Update()
    {
        if (target == null) return;
        if (isHoimg && !target.IsDead())
        {
            transform.LookAt(GetAimLocation());
        }
        transform.Translate(Vector3.forward * Time.deltaTime * arrowSpeed);
    }

    private Vector3 GetAimLocation()
    {
        CapsuleCollider capsuleCollider = target.GetComponent<CapsuleCollider>();

        if (capsuleCollider == null)
        {
            return target.transform.position;
        }
        return target.transform.position + Vector3.up * capsuleCollider.height / 1.2f;
    }
    public void SetTarget(Health target, float damage)
    {
        this.target = target;
        this.damage = damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>() != target) return;
        if (target.IsDead()) return;
        if(hitEffect != null)
        {
        Instantiate(hitEffect, GetAimLocation(), transform.rotation);
        }
        target.TakeDamage(damage);
        Destroy(gameObject);
    }
}
