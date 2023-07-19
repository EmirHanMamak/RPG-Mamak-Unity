using RPG.Saving;
using UnityEngine;

namespace RPG.Core
{
    public class Health : MonoBehaviour, ISaveable
    {
        [SerializeField] float healthPoints;
        bool isDead = false;

        private void Start()
        {
        }

        /**
         * Other Functions
         */

        /*VOID FUNCTIONS*/
        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            if (healthPoints == 0)
            {
                Die();
            }
            print(healthPoints);
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