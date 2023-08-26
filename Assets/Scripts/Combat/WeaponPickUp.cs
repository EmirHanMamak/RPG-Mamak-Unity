using System;
using System.Collections;
using RPG.Control;
using UnityEngine;

namespace RPG.Combat
{
    public class WeaponPickUp : MonoBehaviour, IRaycastable
    {
        [SerializeField] Weapon weapon;
        [SerializeField] float respawnSecondTime = 5f;
        Collider pickUpCollider;

        private void Start()
        {
            pickUpCollider = GetComponent<Collider>();
        }

        /**
         * Other Functions
         */

        /*VOID FUNCTIONS*/
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                //Debug.Log("Girdi");
                Pickup(other.GetComponent<Fighter>());
            }
        }

        private void Pickup(Fighter fighter)
        {
            fighter.EquipWeapon(weapon);
            StartCoroutine(HideForSeconds(respawnSecondTime));
        }

        private void HidePickUp()
        {
            pickUpCollider.enabled = false;
            foreach (Transform eachChild in transform)
            {
                eachChild.gameObject.SetActive(false);
            }
        }

        private void ShowPickUp()
        {
            pickUpCollider.enabled = true;
            foreach (Transform eachChild in transform)
            {
                eachChild.gameObject.SetActive(true);
            }
        }
        
        /*IEnumerator FUNCTIONS*/
        private IEnumerator HideForSeconds(float seconds)
        {
            HidePickUp();
            yield return new WaitForSeconds(seconds);
            ShowPickUp();
        }

        public bool HandleRaycast(PlayerController callingController)
        {
            if(Input.GetMouseButtonDown(0))
            {
            Pickup(callingController.GetComponent<Fighter>());
            }
            return true;
        }
    }
}
