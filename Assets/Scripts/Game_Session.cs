using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Game_Session : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI liveText;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] int countCoin = 0;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        liveText.text = "Live : " + playerLives.ToString();
        coinText.text = "Poin : " + countCoin.ToString();
    }
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        // dem xem co bao nhieu phien ban game
        int numGameSessions = FindObjectsOfType<Game_Session>().Length;
        if (numGameSessions > 1)
        {
            // loai bo game Object
            Destroy(gameObject);
        }
        else
        {
            /// giu lai canh xung quanh
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ProcessPlayDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {

            StartCoroutine(RestartAfterDelay(3f));
        //    FindObjectOfType<Pain_game>().Loadgame();
        }
    }
    void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenesOerSist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    void TakeLife()
    {
        playerLives--;
        // lay Scene hien tai va load laij Scene do
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        liveText.text = "Live : " + playerLives.ToString();

    }
    public void AddToScore(int coin)
    {
        countCoin += coin;
        coinText.text = "Poin : " + countCoin.ToString();
    }
    private IEnumerator RestartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Chờ 3 giây

        ResetGameSession();
     //   FindObjectOfType<Pain_game>().Loadgame();
    }

}
