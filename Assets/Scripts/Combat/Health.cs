using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 100f;
        public void TakeDamage(float damage)
        {
            if(health >= damage)
            {
                health -= damage;
                Debug.Log("Yours Health : " + health);

            }
            else if(health < damage)
            {
                health = 0;
                Debug.Log("You dead Health : " + health);
            }
            else {
                health = 0;
                Debug.Log("You dead Health : " + health);
            }
        }
    }
}