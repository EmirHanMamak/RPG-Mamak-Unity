using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Combat;
using RPG.Core;

namespace RPG.Movment
{
    public class Mover : MonoBehaviour
{
    NavMeshAgent navmeshAgent;
    void Start() 
    {
        navmeshAgent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        UpdateAnimator();
    }
    public void StartMoveAction(Vector3 destination)
    {
        GetComponent<ActionScheduler>().StartAction(this);
        GetComponent<Fighter>().Cancel();
        MoveTo(destination);
    }
    
    public void MoveTo(Vector3 destination)
    {
        navmeshAgent.destination = destination;
        navmeshAgent.isStopped = false;
    }
    
    public void Stop()
    {
        navmeshAgent.isStopped = true;
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = navmeshAgent.velocity;
        Vector3 localvelocity = transform.InverseTransformDirection(velocity);
        float speed = localvelocity.z;
        GetComponent<Animator>().SetFloat("fowardSpeed",speed);
    }
}

}