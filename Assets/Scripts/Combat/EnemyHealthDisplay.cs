using System;
using RPG.Resources;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Combat
{
    public class EnemyHealthDisplay : MonoBehaviour
    {
        Fighter fighter;

        private void Awake()
        {
            fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();
        }

        private void Update()
        {
            if (fighter.GetTarget() == null)
            {
                GetComponent<Text>().text = "N/A";
                return;
            }
            Health health = fighter.GetTarget();
            if(fighter.GetTarget().IsDead())
            {
                GetComponent<Text>().text = "Dead";
            }
            else
            {
            GetComponent<Text>().text = String.Format("{0:0}%", health.GetPercentage());
            }
        }
    }
}