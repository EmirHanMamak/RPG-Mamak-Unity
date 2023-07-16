using UnityEngine;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] AnimatorOverrideController weaponAnimationOverride = null;
        [SerializeField] GameObject equippedWeaponPrefabs = null;
        [SerializeField] float weaponDamage = 0f;
        [Range(2f, 6f)]
        [SerializeField] float weaponRange = 0f;
        [SerializeField] float timeBetweenAttacks = 1f;

        public void Spawn(Transform handTransform, Animator animator)
        {
            if(equippedWeaponPrefabs != null)
            {
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