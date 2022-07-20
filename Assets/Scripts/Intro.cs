using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public Button startBtn;

    public void ClickStart()
    {
        Debug.Log(PlayerPrefs.GetString("Nickname"));
        if(PlayerPrefs.GetString("Nickname") == "")
        {
            SceneManager.LoadScene("NicknameScene");
        }
        else
        {
            SceneManager.LoadScene("Palette game");
        }
    }
}
