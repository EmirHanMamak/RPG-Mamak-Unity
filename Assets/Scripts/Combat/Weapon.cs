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

        public void Spawn(Transform rightHandTransform, Transform leftHandTransform, Animator animator)
        {
            if(equippedWeaponPrefabs != null)
            {
                Transform handTransform;
                if(isRightHanded) handTransform = rightHandTransform;
                else handTransform = leftHandTransform;

            Instantiate(equippedWeaponPrefabs, handTransform);
            }
            if(weaponAnimationOverride != null)
            {
            animator.runtimeAnimatorController = weaponAnimationOverride;
            }
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