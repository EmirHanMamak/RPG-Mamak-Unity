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
        [SerializeField] float chaseDistance = 6f;
        [SerializeField] float suspictionTime = 5f;
        Fighter fighter;
        GameObject player;
        Health health;
        Mover mover;
        Vector3 guardPosition;

        float timeSinceLastSawPlayer = Mathf.Infinity;

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
                timeSinceLastSawPlayer = 0;
                AttackBehaviour();
            }
            else if(timeSinceLastSawPlayer < suspictionTime)
            {
                SuspicionBehaviour();
            }
            else
            {
                GuardBehaviour();
            }
            timeSinceLastSawPlayer += Time.deltaTime;
        }

        private void GuardBehaviour()
        {
            mover.StartMoveAction(guardPosition);
        }

        private void SuspicionBehaviour()
        {
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        private void AttackBehaviour()
        {
            fighter.Attack(player);
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
