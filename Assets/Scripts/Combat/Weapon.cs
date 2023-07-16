using UnityEngine;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] AnimatorOverrideController weaponAnimationOverride = null;
        [SerializeField] GameObject weaponPrefabs = null;

        public void Spawn(Transform handTransform, Animator animator)
        {
            Instantiate(weaponPrefabs, handTransform);
            animator.runtimeAnimatorController = weaponAnimationOverride;
        }
    }
}