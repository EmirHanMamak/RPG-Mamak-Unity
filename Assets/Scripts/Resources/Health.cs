using System;
using RPG.Core;
using RPG.Saving;
using RPG.Stats;
using UnityEngine;

namespace RPG.Resources
{
    public class Health : MonoBehaviour, ISaveable
    {
        [SerializeField] float healthPoints;
        bool isDead = false;

        private void Start()
        {
            healthPoints = GetComponent<BaseStats>().GetStat(Stat.Health);
        }

        /**
         * Other Functions
         */

        /*VOID FUNCTIONS*/
        public void TakeDamage(GameObject instigator, float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            if (healthPoints == 0)
            {
                Die();
                AwardExperiance(instigator);
            }
            print(healthPoints);
        }
        public float GetPercentage()
        {
            return 100 * (healthPoints / GetComponent<BaseStats>().GetStat(Stat.Health));
        }
        private void AwardExperiance(GameObject instigator)
        {
            Experiance experiance = instigator.GetComponent<Experiance>();
            if(experiance == null) return;
            experiance.GainExperiance(GetComponent<BaseStats>().GetStat(Stat.ExperianceReward));
        }
        private void Die()
        {
            if (isDead) return;
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        public void RestoreState(object state)
        {
            healthPoints = (float)state;
            if (healthPoints == 0)
            {
                Die();
            }
        }

        /*BOOL FUNCTIONS*/
        public bool IsDead()
        {
            return isDead;
        }

        /*OBJECT FUNCTIONS*/
        public object CaptureState()
        {
            return healthPoints;
        }
    }
}