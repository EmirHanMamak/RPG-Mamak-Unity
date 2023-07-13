using System.Collections;
using System.Collections.Generic;
using RPG.Movment;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
public class CinematicTrigger : MonoBehaviour
{
    bool isAlreadyTrigger = false;
    [SerializeField] Mover mover;
    private void OnTriggerEnter(Collider other) {
        if(!isAlreadyTrigger && other.CompareTag("Player"))
        {
        GetComponent<PlayableDirector>().Play();
        mover.Cancel();
        isAlreadyTrigger = true;
        }
    }
}
}