using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        Fighter fighter;
        GameObject player;
        private void Start() {
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");
        }
        private void Update()
        {

            if (InAttackRangeOfPlayer(player) &&
            fighter.CanAttack(player))
            {
                fighter.Attack(player);

            } else 
            {
                fighter.Cancel();
            }
        }

        private bool InAttackRangeOfPlayer(GameObject player)
        {
            float distancetoplayer = Vector3.Distance(gameObject.transform.position, player.transform.position);
            return distancetoplayer < chaseDistance;
        }
    }
}
