using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Login : MonoBehaviour
{

    public InputField Nickname;

    public void Save()
    {
      
    }

    public void Load()
    {
        PlayerPrefs.SetString("Nickname", Nickname.text);
        Debug.Log(PlayerPrefs.GetString("Nickname"));
      
    }
}