using UnityEngine;

namespace RPG.Core
{
    public class PersistentObjectSpawner : MonoBehaviour
    {
        [SerializeField] GameObject persistentObjectPrefab;
        static bool hasSpawned = false;

        private void Awake()
        {
            if (hasSpawned) return;
            SpawnPresistentObjects();
            hasSpawned = true;
        }

        /**
         * Other Functions
         */

        /*VOID FUNCTIONS*/
        private void SpawnPresistentObjects()
        {
            GameObject persistentObject = Instantiate(persistentObjectPrefab);
            DontDestroyOnLoad(persistentObject);
        }
    }
}