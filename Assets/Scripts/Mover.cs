using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToCursor();
        }
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
}
