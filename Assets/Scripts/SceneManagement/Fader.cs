using System.Collections;
using UnityEngine;

namespace RPG.SceneManagement
{
    public class Fader : MonoBehaviour
    {
        CanvasGroup canvasGroup;
        void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        /**
         * Other Functions
         */

        /*VOID FUNCTIONS*/
        public void FadeOutImmediate()
        {
            canvasGroup.alpha = 1f;
        }

        public IEnumerator FadeOut(float time)
        {
            while (canvasGroup.alpha < 1f)
            {
                canvasGroup.alpha += Time.deltaTime / time;
                yield return null;
            }

        }

        /*IENUMERATOR FUNCTIONS*/
        public IEnumerator FadeIn(float time)
        {
            while (canvasGroup.alpha > 0f)
            {
                canvasGroup.alpha -= Time.deltaTime / time;
                yield return null;
            }
        }
    }
}