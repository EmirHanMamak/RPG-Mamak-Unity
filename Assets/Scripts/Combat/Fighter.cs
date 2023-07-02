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
    Transform target;
    void Update()
    {
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
            GetComponent<Animator>().SetTrigger("attack");
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

