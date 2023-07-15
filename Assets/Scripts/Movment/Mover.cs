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
        // Update is called once per frame
        void Update()
        {
            navmeshAgent.enabled = !health.IsDead();
            NevMashAnimator();
        }

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

        public bool MoveTo(Vector3 destination, float speedFraction)
        {
            navmeshAgent.destination = destination;
            navmeshAgent.speed = maxSpeed * Mathf.Clamp01(speedFraction);
            navmeshAgent.isStopped = false;
            return false;
        }

        public void Cancel()
        {
            navmeshAgent.isStopped = true;
        }

        private void UpdateAnimator()
        {

        }

        public object CaptureState()
        {
            return new SerializableVector3(transform.position);
        }

        public void RestoreState(object state)
        {
            SerializableVector3 position = (SerializableVector3)state;
            GetComponent<NavMeshAgent>().enabled = false;
            transform.position = position.ToVector();
            GetComponent<NavMeshAgent>().enabled = true;    
        }
    }

}