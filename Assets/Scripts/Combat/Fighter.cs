using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movment;

namespace RPG.Combat
{
public class Fighter : MonoBehaviour
{
    [SerializeField] float weaponRange = 2f;
    Transform target;
    void Update()
    {
        if(target != null && !IsInRange())
        {
        GetComponent<Mover>().MoveTo(target.position);
        }
        else
        {
            GetComponent<Mover>().Stop();
        }
    }
    private bool IsInRange()
    {
        bool isInRange = Vector3.Distance(transform.position, target.position) < weaponRange;
        return isInRange;
    }
    public void Attack(CombatTarget combatTarget)
    {
        target = combatTarget.transform;
    }
}
}

