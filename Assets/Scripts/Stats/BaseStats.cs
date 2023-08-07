using System.Collections;
using System.Collections.Generic;
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

        /*VOID FUNCTIONS*/
        public float GetHealth()
        {
            return progression.GetHealth(characterClass, startingLevel);
        }
    }
} 