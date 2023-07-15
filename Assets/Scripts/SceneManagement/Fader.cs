using System.Collections;
using UnityEngine;

namespace RPG.SceneManagement
{
    public class Fader : MonoBehaviour
    {
        CanvasGroup canvasGroup;
        private void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            StartCoroutine(FadeOutIn());
        }

        public IEnumerator FadeOut(float time)
        {
            while (canvasGroup.alpha < 1f)
            {
                canvasGroup.alpha += Time.deltaTime / time;
                yield return null;
            }

        }
        public IEnumerator FadeOutIn()
        {
            yield return FadeOut(0.8f);
            print("Faded out");
            yield return FadeIn(0.4f);
            print("Faded in");


        }
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