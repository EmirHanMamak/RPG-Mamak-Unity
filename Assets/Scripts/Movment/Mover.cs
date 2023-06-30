using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            MoveToCursor();
        }
        UpdateAnimator();
    }
    private void MoveToCursor()
    {
        Ray Ray;
        RaycastHit hit;
        bool hasHit;

        Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hasHit = Physics.Raycast(Ray, out hit);

        if (hasHit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }
    }
    private void UpdateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localvelocity = transform.InverseTransformDirection(velocity);
        float speed = localvelocity.z;
        GetComponent<Animator>().SetFloat("fowardSpeed",speed);
    }
}
