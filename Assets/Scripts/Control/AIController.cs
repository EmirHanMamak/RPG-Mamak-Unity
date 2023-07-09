using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using RPG.Core;
using RPG.Movment;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        Fighter fighter;
        GameObject player;
        Health health;
        Mover mover;
        Vector3 guardPosition;

        private void Start() {
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");
            health = GetComponent<Health>();
            mover = GetComponent<Mover>();
            guardPosition = transform.position;
        }
        private void Update()
        {
            if(health.IsDead()) return;

            if (InAttackRangeOfPlayer(player) &&
            fighter.CanAttack(player))
            {
                fighter.Attack(player);

            } else 
            {
                mover.StartMoveAction(guardPosition);
            }
        }

        private bool InAttackRangeOfPlayer(GameObject player)
        {
            float distancetoplayer = Vector3.Distance(gameObject.transform.position, player.transform.position);
            return distancetoplayer < chaseDistance;
        }
        //Called by Unity
        private void OnDrawGizmos() {
            
        }
        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.blue; 
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}
