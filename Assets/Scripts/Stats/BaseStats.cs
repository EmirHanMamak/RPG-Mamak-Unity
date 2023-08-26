using System.Collections;
using System.Collections.Generic;
using RPG.Resources;
using UnityEngine;

namespace RPG.Stats
{
    public class BaseStats : MonoBehaviour
    {
        [SerializeField] CharacterClass characterClass;
        [SerializeField] Progression progression = null;
        [Range(1, 99)]
        [SerializeField] int startingLevel = 1;

        /**
         * Other Functions
         */
        private void Update()
        {
            if (gameObject.tag == "Player")
            {
                print(GetLevel());
            }
        }
        /*VOID FUNCTIONS*/
        public float GetStat(Stat stat)
        {
            return progression.GetStat(stat, characterClass, GetLevel());
        }
        public int GetLevel()
        {
            Experiance experiance = GetComponent<Experiance>();
            if (experiance == null) return startingLevel;
            float currentXp = experiance.GetExperiancePoint();
            int penultimateLevel = progression.GetLevels(Stat.ExperianceToLevelUp, characterClass);
            for (int level = 1; level <= penultimateLevel; level++)
            {
                float XpToLevelUp = progression.GetStat(Stat.ExperianceToLevelUp, characterClass, level);
                if (XpToLevelUp > currentXp)
                {
                    return level;
                }
            }
            return penultimateLevel + 1;
        }
    }
}