using UnityEngine;
using RPG.Movment;
using RPG.Combat;
using System;
using RPG.Core;
namespace RPG.Control
{
    public class PlayerController : MonoBehaviour {
    private void Update()
        {
            if(InteractWithCombat()) return;
            if(InteractWithMovment()) return;
           // Debug.Log("Nothing to do");
        }
 
        private bool InteractWithCombat()
        {
           RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
           foreach (RaycastHit hit in hits)
           {
               CombatTarget target = hit.transform.GetComponent<CombatTarget>();
               if(target == null) continue;
               if(Input.GetMouseButtonDown(0))
               {
                GetComponent<Fighter>().Attack(target);
               }
               return true;
           }
           return false;
        }
        private bool InteractWithMovment()
        {
            RaycastHit hit;
            bool hasHit;
            hasHit = Physics.Raycast(GetMouseRay(), out hit);

            if (hasHit)
            {
                if(Input.GetMouseButton(0))
                {
                GetComponent<Mover>().StartMoveAction(hit.point);
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}