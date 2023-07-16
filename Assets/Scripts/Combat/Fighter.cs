using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RPG.Movment;
using RPG.Core;
using System;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [Header("WEAPON")]
        [SerializeField] GameObject weaponPrefabs = null;
        [SerializeField] Transform handTransform = null;
        [SerializeField] float weaponDamage = 44f;
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] AnimatorOverrideController weaponAnimationOverride = null;
        [Header("OTHERS")]
        float timeSinceAttack = Mathf.Infinity;
        Health target;
        private void Start()
        {
            SpawnWeapon();
        }

        private void SpawnWeapon()
        {
            Instantiate(weaponPrefabs, handTransform);
            Animator animator = GetComponent<Animator>();
            animator.runtimeAnimatorController = weaponAnimationOverride;
        }

        void Update()
        {
            timeSinceAttack += Time.deltaTime;
            if (target == null) return;
            if (target.IsDead()) return;
            if (!IsInRange())
            {
                GetComponent<Mover>().MoveTo(target.transform.position, 1f);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            transform.LookAt(target.transform);
            if (timeSinceAttack > timeBetweenAttacks)
            {
                //This is trigger Hit() func
                TriggerAttack();
                timeSinceAttack = 0f;
            }
        }

        private void TriggerAttack()
        {
            GetComponent<Animator>().ResetTrigger("stopAttack");
            GetComponent<Animator>().SetTrigger("attack");
        }

        void Hit()
        {
            if (target == null) return;
            target.TakeDamage(weaponDamage);
        }

        private bool IsInRange()
        {
            bool isInRange = Vector3.Distance(transform.position, target.transform.position) < weaponRange;
            return isInRange;
        }
        public void Attack(GameObject combatTarget)
        {

            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.GetComponent<Health>();
            Debug.Log("Attacks");
        }
        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null) { return false; }
            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead();
        }
        public void Cancel()
        {
            StopAttack();
            target = null;
            GetComponent<Mover>().Cancel();

        }

        private void StopAttack()
        {
            GetComponent<Animator>().ResetTrigger("attack");
            GetComponent<Animator>().SetTrigger("stopAttack");
        }
    }
}

