using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movment
{
    public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;
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