using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class WeaponPickUp : MonoBehaviour
    {
        [SerializeField] Weapon weapon;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                //Debug.Log("Girdi");
                other.GetComponent<Fighter>().EquipWeapon(weapon);
                Destroy(gameObject);
            }

        }
    }
}