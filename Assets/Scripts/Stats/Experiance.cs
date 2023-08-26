using RPG.Saving;
using UnityEngine;
namespace RPG.Stats
{
    public class Experiance : MonoBehaviour, ISaveable
    {
        [SerializeField] float experiancePoint = 0;

        public void GainExperiance(float experiance)
        {
            experiancePoint += experiance;
        }

        public float GetExperiancePoint()
        {
            return experiancePoint;
        }
        public object CaptureState()
        {
            return experiancePoint;
        }

        public void RestoreState(object state)
        {
            experiancePoint = (float)state;
        }
    }
}