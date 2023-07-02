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
    [SerializeField] float weaponDamage = 44f;
    float timeSinceAttack = 0;
    Health target;
    void Update()
    {
        timeSinceAttack += Time.deltaTime;
        if(target == null ) return;
        if(target.IsDead()) return;
        if(!IsInRange())
        {
        GetComponent<Mover>().MoveTo(target.transform.position);
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
           target.TakeDamage(weaponDamage);
        }

        private bool IsInRange()
    {
        bool isInRange = Vector3.Distance(transform.position, target.transform.position) < weaponRange;
        return isInRange;
    }
    public void Attack(CombatTarget combatTarget)
    {

        GetComponent<ActionScheduler>().StartAction(this);
        target = combatTarget.GetComponent<Health>();
        Debug.Log("Attacks");
    }
    public void Cancel()
    {                
        GetComponent<Animator>().SetTrigger("stopAttack");                
        target = null;
    }
}
}

