using UnityEngine;

namespace RPG.Control
{
    public class PatrolPath : MonoBehaviour
    {
        const float wayPointGizmosRadius = 0.4f;

        /**
         * Other Functions
         */

        /*VOID FUNCTIONS*/
        private void OnDrawGizmos()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                int j = GetNextIndex(i);
                Gizmos.DrawSphere(GetWayPoint(i), wayPointGizmosRadius);
                Gizmos.DrawLine(GetWayPoint(i), GetWayPoint(j));
            }
        }

        /*VECTOR3 FUNCTIONS*/
        public Vector3 GetWayPoint(int i)
        {
            return transform.GetChild(i).position;
        }

        /*INT FUNCTIONS*/
        public int GetNextIndex(int i)
        {
            if (i + 1 == transform.childCount)
            {
                return 0;
            }
            return i + 1;
        }
    }
}