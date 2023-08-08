using System;
using UnityEngine;
using RPG.Resources;
namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        const string weaponName = "Weapon";
        [SerializeField] AnimatorOverrideController weaponAnimationOverride = null;
        [SerializeField] GameObject equippedWeaponPrefabs = null;
        [SerializeField] Projectile projectile = null;
        [SerializeField] float weaponDamage = 0f;
        [Range(2f, 50)]
        [SerializeField] float weaponRange = 0f;
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] bool isRightHanded = true;

        /**
         * Other Functions
         */
         
        /*GETTER FUNCTIONS*/
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

        /*VOID FUNCTIONS*/
        public void Spawn(Transform rightHandTransform, Transform leftHandTransform, Animator animator)
        {
            DetstroyOldWeapon(rightHandTransform, leftHandTransform);
            if (equippedWeaponPrefabs != null)
            {
                Transform handTransform = GetTransform(rightHandTransform, leftHandTransform);

                GameObject weapon = Instantiate(equippedWeaponPrefabs, handTransform);
                weapon.name = weaponName;
            }
            var overrideController = animator.runtimeAnimatorController as AnimatorOverrideController;
            if (weaponAnimationOverride != null)
            {
                animator.runtimeAnimatorController = weaponAnimationOverride;
            }
            else if (overrideController != null)
            {
                animator.runtimeAnimatorController = overrideController.runtimeAnimatorController;
            }
        }

        private void DetstroyOldWeapon(Transform rightHandTransform, Transform leftHandTransform)
        {
            Transform oldWeapon = rightHandTransform.Find(weaponName);
            if (oldWeapon == null)
            {
                oldWeapon = leftHandTransform.Find(weaponName);
            }
            if (oldWeapon == null) return;
            oldWeapon.name = "DESTROYING";
            Destroy(oldWeapon.gameObject);
        }

        public void LaunchProjectile(Transform rightHand, Transform leftHand, Health target, GameObject instigator)
        {
            Projectile projectileInstance = Instantiate(projectile, GetTransform(rightHand, leftHand).position, Quaternion.identity);
            projectileInstance.SetTarget(target, instigator, weaponDamage);
        }

        /*BOOL FUNCTIONS*/
        public bool HasProjectile()
        {
            return projectile != null;
        }
    }
}