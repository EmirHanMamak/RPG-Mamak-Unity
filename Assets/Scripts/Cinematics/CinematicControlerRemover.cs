using UnityEngine;
using UnityEngine.Playables;
using RPG.Core;
using RPG.Control;

namespace RPG.Cinematics
{
    public class CinematicControlerRemover : MonoBehaviour
    {
        GameObject player;
        [SerializeField] GameObject[] cinematicobjects;

        void Start()
        {
            player = GameObject.FindWithTag("Player");
            GetComponent<PlayableDirector>().played += DisableControl;
            GetComponent<PlayableDirector>().stopped += EnableControl;
        }

        /**
         * Other Functions
         */

        /*VOID FUNCTIONS*/
        void DisableControl(PlayableDirector playableDirector)
        {
            foreach (GameObject gm in cinematicobjects)
            {
                gm.SetActive(true);
            }
            player.GetComponent<ActionScheduler>().CancelCurrentAction();
            player.GetComponent<PlayerController>().enabled = false;
        }
        void EnableControl(PlayableDirector playableDirector)
        {
            foreach (GameObject gm in cinematicobjects)
            {
                gm.SetActive(false);
            }
            player.GetComponent<PlayerController>().enabled = true;
            Debug.Log("EnableControl");
        }
    }
}