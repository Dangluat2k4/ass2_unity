using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting_game1 : MonoBehaviour
{
    public GameObject SettingGame;
     public void setTing()
    {
        Debug.Log("click");
        SettingGame.SetActive(true);
        Time.timeScale = 0;
    }
    public void setTing2()
    {
        Debug.Log("click");
        SettingGame.SetActive(true);
        Time.timeScale = 0;
    }
    public void ExitGame()
    {
        SettingGame.SetActive(false);
        Time.timeScale = 1;
    }
}
