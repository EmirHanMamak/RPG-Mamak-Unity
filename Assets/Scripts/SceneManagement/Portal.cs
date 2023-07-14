using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {
    [SerializeField] int loadSceneIndex = -1;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(loadSceneIndex);
        }
    }
}