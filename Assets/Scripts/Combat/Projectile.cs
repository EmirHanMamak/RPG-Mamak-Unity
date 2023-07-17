using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float arrowSpeed = 100f;
    [SerializeField] Transform target = null;
    void Start()
    {
        
    }


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
            return target.position;
        }
        return target.position + Vector3.up * capsuleCollider.height / 1.2f;
    }
}
