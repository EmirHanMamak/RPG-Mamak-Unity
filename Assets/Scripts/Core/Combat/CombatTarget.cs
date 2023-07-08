using UnityEngine;
using RPG.Core;

namespace RPG.Combat
{
    [RequireComponent(typeof(Health))]
    public class CombatTarget : MonoBehaviour
    {
        float anca = 1f;
        private void Awake()
        {
//ilk calis 1 kere
        }
        void Start()
        {

//awakeden sonra calis 1 kere
        }
        private void FixedUpdate()
        {
        damla();
        emir();
//startdan sonra calis oyun kapanana kadar
        }
        private void Update()
        {
//FixedUpdate sonra calis oyun kapanana kadar
        }
        private void LateUpdate()
        {
//Update sonra calis oyun kapanana kadar
        }
        public void damla()
        {
            anca++;
        }
        void emir()
        {
            float a = 1f;
        }
    }
}