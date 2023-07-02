using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;
using RPG.Combat;
namespace RPG.Movment
{
    public class Mover : MonoBehaviour, IAction
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
        GetComponent<Animator>().SetTrigger("stopAttack");

        MoveTo(destination);
    }
    
    public void MoveTo(Vector3 destination)
    {
        navmeshAgent.destination = destination;
        navmeshAgent.isStopped = false;
    }
    
    public void Cancel()
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