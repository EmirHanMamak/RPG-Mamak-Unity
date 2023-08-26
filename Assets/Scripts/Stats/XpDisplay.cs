using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Stats
{
    public class XpDisplay : MonoBehaviour
    {
        Experiance experiance;

        private void Awake()
        {
            experiance = GameObject.FindWithTag("Player").GetComponent<Experiance>();
        }

        private void Update()
        {
            GetComponent<Text>().text = experiance.GetExperiancePoint().ToString();
        }
    }
}