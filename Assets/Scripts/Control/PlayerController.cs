using UnityEngine;
using RPG.Movment;
using RPG.Combat;
using System;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour {
    private void Update()
        {
            InteractWithCombat();
            InteractWithMovment();
        }
 
        private void InteractWithCombat()
        {
            //14.34
           RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
           foreach (RaycastHit hit in hits)
           {
               CombatTarget target = hit.transform.GetComponent<CombatTarget>();
               if(target == null) continue;
               if(Input.GetMouseButtonDown(0))
               {
                GetComponent<Fighter>().Attack(target);
               }
           }
        }

        private void InteractWithMovment()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
            RaycastHit hit;
            bool hasHit;
            hasHit = Physics.Raycast(GetMouseRay(), out hit);

            if (hasHit)
            {
                GetComponent<Mover>().MoveTo(hit.point);

            }
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}