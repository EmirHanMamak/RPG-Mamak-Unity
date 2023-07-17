using System;
using RPG.Core;
using UnityEngine;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] AnimatorOverrideController weaponAnimationOverride = null;
        [SerializeField] GameObject equippedWeaponPrefabs = null;
        [SerializeField] float weaponDamage = 0f;
        [Range(2f, 50)]
        [SerializeField] float weaponRange = 0f;
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] bool isRightHanded = true;
        [SerializeField] Projectile projectile = null;
        const string weaponName = "Weapon";

        public void Spawn(Transform rightHandTransform, Transform leftHandTransform, Animator animator)
        {
            DetstroyOldWeapon(rightHandTransform, leftHandTransform);
            if (equippedWeaponPrefabs != null)
            {
                Transform handTransform = GetTransform(rightHandTransform, leftHandTransform);

                GameObject weapon = Instantiate(equippedWeaponPrefabs, handTransform);
                weapon.name = weaponName;
            }
            if (weaponAnimationOverride != null)
            {
                animator.runtimeAnimatorController = weaponAnimationOverride;
            }
        }

        private void DetstroyOldWeapon(Transform rightHandTransform, Transform leftHandTransform)
        {
            Transform oldWeapon = rightHandTransform.Find(weaponName);
            if(oldWeapon == null)
            {
               oldWeapon = leftHandTransform.Find(weaponName);
            }
            if(oldWeapon == null) return;
            oldWeapon.name = "DESTROYING";
            Destroy(oldWeapon.gameObject);
        }

        private Transform GetTransform(Transform rightHandTransform, Transform leftHandTransform)
        {
            Transform handTransform;
            if (isRightHanded)
            {
                handTransform = rightHandTransform;
            }
            else
            {
                handTransform = leftHandTransform;
            }
            return handTransform;
        }

        public bool HasProjectile()
        {
            return projectile != null;
        }
        public void LaunchProjectile(Transform rightHand, Transform leftHand, Health target)
        {
            Projectile projectileInstance = Instantiate(projectile, GetTransform(rightHand, leftHand).position, Quaternion.identity);
            projectileInstance.SetTarget(target, weaponDamage);
        }
        public float GetTimeBeweenAttack()
        {
            return timeBetweenAttacks;
        }
        public float GetWeaponDamage()
        {
            return weaponDamage;
        }
        public float GetWeaponRange()
        {
            return weaponRange;
        }
    }
}