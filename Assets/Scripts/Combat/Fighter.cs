using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movment;
using RPG.Core;

namespace RPG.Combat
{
public class Fighter : MonoBehaviour, IAction
{
    [SerializeField] float weaponRange = 2f;
    [SerializeField] float timeBetweenAttacks = 1f;
    [SerializeField] float weaponDamage = 16f;
    float timeSinceAttack = 0;
    Transform target;
    void Update()
    {
        timeSinceAttack += Time.deltaTime;
        if(target == null ) return;
        if(!IsInRange())
        {
        GetComponent<Mover>().MoveTo(target.position);
        }
        else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            if(timeSinceAttack > timeBetweenAttacks)
            {
                //This is trigger Hit() func
            GetComponent<Animator>().SetTrigger("attack");
            timeSinceAttack = 0f;
            }
        }
         void Hit()
        {
            Health healthComponent = target.GetComponent<Health>();
            healthComponent.TakeDamage(weaponDamage);
        }

        private bool IsInRange()
    {
        bool isInRange = Vector3.Distance(transform.position, target.position) < weaponRange;
        return isInRange;
    }
    public void Attack(CombatTarget combatTarget)
    {

        GetComponent<ActionScheduler>().StartAction(this);
        target = combatTarget.transform;
        Debug.Log("Attacks");
    }
    public void Cancel()
    {
        target = null;
    }
}
}

