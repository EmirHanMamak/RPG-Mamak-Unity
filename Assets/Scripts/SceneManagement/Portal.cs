using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Portal : MonoBehaviour
{
    enum DestinationIdentifier
    {
		A, B, C, D, E
    }
    [SerializeField] int sceneToLoad = -1;
    [SerializeField] Transform spawnPoint;
	[SerializeField] DestinationIdentifier destinationIdentifier;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Transition());
        }
    }

    private IEnumerator Transition()
    {
        DontDestroyOnLoad(gameObject);
        yield return SceneManager.LoadSceneAsync(sceneToLoad);
        Portal otherPortal = GetOtherPortal();
        UpdatePlayer(otherPortal);
        Destroy(gameObject);
    }

    private void UpdatePlayer(Portal otherPortal)
    {
        GameObject player = GameObject.FindWithTag("Player");
        print("logg");
        player.GetComponent<NavMeshAgent>().Warp(otherPortal.spawnPoint.position);
        player.transform.rotation = otherPortal.spawnPoint.rotation;
    }

    private Portal GetOtherPortal()
    {
        foreach (Portal portal in FindObjectsOfType<Portal>())
        {
            if (portal == this) continue;
			if (portal.destinationIdentifier != destinationIdentifier) continue;
            return portal;
        }

        return null;
    }
}