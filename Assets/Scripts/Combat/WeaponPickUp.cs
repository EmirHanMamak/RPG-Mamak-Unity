using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class WeaponPickUp : MonoBehaviour
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
                other.GetComponent<Fighter>().EquipWeapon(weapon);
                StartCoroutine(HideForSeconds(respawnSecondTime));
            }
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
    }
}
