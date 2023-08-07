using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Resources;
using UnityEngine;

namespace RPG.Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] GameObject hitEffect = null;
        [SerializeField] float speed = 100f;
        [SerializeField] float maxLifeTime = 10f;
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
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        /**
         * Other Functions
         */

        /*VOID FUNCTIONS*/
        public void SetTarget(Health target, float damage)
        {
            this.target = target;
            this.damage = damage;
            Destroy(gameObject, maxLifeTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Health>() != target) return;
            if (target.IsDead()) return;
            target.TakeDamage(damage);
            speed = 0f;
            if (hitEffect != null)
            {
                Instantiate(hitEffect, GetAimLocation(), transform.rotation);
            }
            Destroy(gameObject);
            //Destroy(hitEffect, 1f);
        }
        
        /*VECTOR3 FUNCTIONS*/
        private Vector3 GetAimLocation()
        {
            CapsuleCollider capsuleCollider = target.GetComponent<CapsuleCollider>();

            if (capsuleCollider == null)
            {
                return target.transform.position;
            }
            return target.transform.position + Vector3.up * capsuleCollider.height / 1.2f;
        }
    }
}