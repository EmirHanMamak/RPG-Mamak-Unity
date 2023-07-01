using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        MonoBehaviour currentAction;
        public void StartAction(MonoBehaviour action)
        {
            if(currentAction == action) return;
            if(currentAction != null)
            {
            Debug.Log("Cancelling" + currentAction);
            }
            currentAction = action;
        }
    }
}