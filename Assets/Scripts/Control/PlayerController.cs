using UnityEngine;

public class PlayerController : MonoBehaviour {
    private void Update() {
         if (Input.GetMouseButton(0))
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
            GetComponent<Mover>().MoveTo(hit.point);

        }
    }
}