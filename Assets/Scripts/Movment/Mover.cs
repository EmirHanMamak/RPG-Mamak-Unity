using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;
using RPG.Saving;

namespace RPG.Movment
{
    public class Mover : MonoBehaviour, IAction, ISaveable
    {
        [SerializeField] float maxSpeed = 6f;
        NavMeshAgent navmeshAgent;
        Health health;

        void Start()
        {
            health = GetComponent<Health>();
            navmeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            navmeshAgent.enabled = !health.IsDead();
            NevMashAnimator();
        }
        /**
        * Other Functions
        */

        /*VOID FUNCTIONS*/
        private void NevMashAnimator()
        {
            Vector3 velocity = navmeshAgent.velocity;
            Vector3 localvelocity = transform.InverseTransformDirection(velocity);
            float speed = localvelocity.z;
            GetComponent<Animator>().SetFloat("fowardSpeed", speed);
        }

        public void StartMoveAction(Vector3 destination, float speedFraction)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            GetComponent<Animator>().SetTrigger("stopAttack");

            MoveTo(destination, speedFraction);
        }

        public void Cancel()
        {
            navmeshAgent.isStopped = true;
        }

        private void UpdateAnimator()
        {
        }

        public void RestoreState(object state)
        {
            Dictionary<string, object> data = (Dictionary<string, object>)state;
            GetComponent<NavMeshAgent>().enabled = false;
            transform.position = ((SerializableVector3)data["position"]).ToVector();
            transform.eulerAngles = ((SerializableVector3)data["rotation"]).ToVector();
            GetComponent<NavMeshAgent>().enabled = true;
        }

        /*BOOL FUNCTIONS*/
        public bool MoveTo(Vector3 destination, float speedFraction)
        {
            navmeshAgent.destination = destination;
            navmeshAgent.speed = maxSpeed * Mathf.Clamp01(speedFraction);
            navmeshAgent.isStopped = false;
            return false;
        }

        /*OBJECT FUNCTIONS*/
        public object CaptureState()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["position"] = new SerializableVector3(transform.position);
            data["rotation"] = new SerializableVector3(transform.eulerAngles);
            return data;
        }
    }

}