using System;
using RPG.Combat;
using RPG.Core;
using RPG.Movment;
using UnityEngine;
using RPG.Resources;
namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] PatrolPath patrolPath;
        [SerializeField] float chaseDistance = 6f;
        [SerializeField] float suspictionTime = 5f;
        [SerializeField] float wayPointTolerance = 1f;
        [SerializeField] float wayPointDwellTime = 3f;
        [Range(0, 1)]
        [SerializeField] float patrolSpeedFraction = 0.25f;

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

        /**
         * Other Functions
         */

        /*VOID FUNCTIONS*/
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
                mover.StartMoveAction(nextPosition, patrolSpeedFraction);
            }
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

        private void CycleWayPoint()
        {
            currentWayPointIndex = patrolPath.GetNextIndex(currentWayPointIndex);
        }

        /*BOOL FUNCTIONS*/
        private bool AtWayPoint()
        {
            float distanceToWayPoint = Vector3.Distance(transform.position, GetCurrentWayPosition());
            return distanceToWayPoint < wayPointTolerance;
        }

        private bool InAttackRangeOfPlayer(GameObject player)
        {
            float distancetoplayer = Vector3.Distance(gameObject.transform.position, player.transform.position);
            return distancetoplayer < chaseDistance;
        }

        /*VECTOR3 FUNCTIONS*/
        private Vector3 GetCurrentWayPosition()
        {
            return patrolPath.GetWayPoint(currentWayPointIndex);
        }

        /*GIZMOS FUNCTIONS*/
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
