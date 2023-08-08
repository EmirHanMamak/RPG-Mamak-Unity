using UnityEngine;
namespace RPG.Resources
{
    public class Experiance : MonoBehaviour
    {
        [SerializeField] float experiancePoint = 0;

        public void GainExperiance(float experiance)
        {
            experiancePoint += experiance;
        }
    }
}