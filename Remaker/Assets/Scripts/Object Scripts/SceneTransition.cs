using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [Header("New Scene Variables")]
    [SerializeField] private string sceneToLoad;
    [SerializeField] private bool playerPositionNeeded;
    [SerializeField] private Vector2 playerPosition;
    [SerializeField] private VectorValue playerStorage;

    [Header("Transition Variables")]
    [SerializeField] private GameObject fadeInPanel;
    [SerializeField] private GameObject fadeOutPanel;
    [SerializeField] private float fadeWait;

    private void Awake()
    {
        if(fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            if(playerPositionNeeded)
            {
                playerStorage.value = playerPosition;
            }
            StartCoroutine(FadeCo());
            //SceneManager.LoadScene(sceneToLoad);      //Replaced by Line 44
        }
    }

    public IEnumerator FadeCo()
    {
        if(fadeOutPanel != null)
        {
           Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while(!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
