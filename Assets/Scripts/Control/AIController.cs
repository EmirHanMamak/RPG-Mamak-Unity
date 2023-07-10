using System;
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
        [SerializeField] PatrolPath patrolPath;
        [SerializeField] float wayPointTolerance = 1f;
        [SerializeField] float wayPointDwellTime = 3f;

        Fighter fighter;
        GameObject player;
        Health health;
        Mover mover;
        Vector3 guardPosition;
        int currentWayPointIndex = 0;

        float timeSinceLastSawPlayer = Mathf.Infinity;
        float timeSinceArivedAtWayPoint = Mathf.Infinity;


        private void Start()
        {
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");
            health = GetComponent<Health>();
            mover = GetComponent<Mover>();
            guardPosition = transform.position;
        }
        private void Update()
        {
            if (health.IsDead()) return;

            if (InAttackRangeOfPlayer(player) &&
            fighter.CanAttack(player))
            {
                AttackBehaviour();
            }
            else if (timeSinceLastSawPlayer < suspictionTime)
            {
                SuspicionBehaviour();
            }
            else
            {
                PatrolBehaviour();
            }
            UpdateTimers();

        }

        private void UpdateTimers()
        {
            timeSinceLastSawPlayer += Time.deltaTime;
            timeSinceArivedAtWayPoint += Time.deltaTime;
        }

        private void PatrolBehaviour()
        {
            Vector3 nextPosition = guardPosition;
            if (patrolPath != null)
            {

                if (AtWayPoint())
                {
                    timeSinceArivedAtWayPoint = 0;
                    CycleWayPoint();
                }

                nextPosition = GetCurrentWayPosition();
            }
            if (timeSinceArivedAtWayPoint > wayPointDwellTime)
            {
                mover.StartMoveAction(nextPosition);
            }

        }

        private bool AtWayPoint()
        {
            float distanceToWayPoint = Vector3.Distance(transform.position, GetCurrentWayPosition());
            return distanceToWayPoint < wayPointTolerance;
        }

        private void CycleWayPoint()
        {
            currentWayPointIndex = patrolPath.GetNextIndex(currentWayPointIndex);
        }

        private Vector3 GetCurrentWayPosition()
        {
            return patrolPath.GetWayPoint(currentWayPointIndex);
        }

        private void SuspicionBehaviour()
        {
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        private void AttackBehaviour()
        {
            timeSinceLastSawPlayer = 0;
            fighter.Attack(player);
        }

        private bool InAttackRangeOfPlayer(GameObject player)
        {
            float distancetoplayer = Vector3.Distance(gameObject.transform.position, player.transform.position);
            return distancetoplayer < chaseDistance;
        }
        //Called by Unity
        private void OnDrawGizmos()
        {

        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}
