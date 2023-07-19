using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        IAction currentAction;

        /**
         * Other Functions
         */
         
        /*VOID FUNCTIONS*/
        public void StartAction(IAction action)
        {
            if(currentAction == action) return;
            if(currentAction != null)
            {
            currentAction.Cancel();
            }
            currentAction = action;
        }

        public void CancelCurrentAction() 
        {
            StartAction(null);
        }
    }
}