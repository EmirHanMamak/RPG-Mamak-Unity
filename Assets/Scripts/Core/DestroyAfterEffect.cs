using UnityEngine;

namespace RPG.Core
{
    public class DestroyAfterEffect : MonoBehaviour
    {
        void LateUpdate()
        {
            if (!GetComponent<ParticleSystem>().IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
