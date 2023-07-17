using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Core;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float arrowSpeed = 100f;
    Health target = null;
    void Update()
    {
        if(target == null) return;
        transform.LookAt(GetAimLocation());
        transform.Translate(Vector3.forward * Time.deltaTime * arrowSpeed);
    }

    private Vector3 GetAimLocation()
    {
        CapsuleCollider capsuleCollider = target.GetComponent<CapsuleCollider>();
        
        if(capsuleCollider == null)
        {
            return target.transform.position;
        }
        return target.transform.position + Vector3.up * capsuleCollider.height / 1.2f;
    }
    public void SetTarget(Health target)
    {
        this.target = target;
    }
}
