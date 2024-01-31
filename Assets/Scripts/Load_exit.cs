using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_exit : MonoBehaviour
{
    [SerializeField] float leverLoadDelay = 1f;
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }


    }
    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(leverLoadDelay);
        // lay vi tri Scenes
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // load qia Scenes tiep theo
        int nextSceneIndex = currentSceneIndex + 1;
        // neu Scenes la cuoi cung next ve Scene dau tien
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        FindObjectOfType<ScenePersist>().ResetScenesOerSist();
        // bat dau load Scene
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void startPlay1()
    {
        StartCoroutine(LoadNextLevel());
    }
}
