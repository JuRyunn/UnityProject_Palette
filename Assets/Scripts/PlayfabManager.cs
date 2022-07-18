using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;


public class PlayfabManager : MonoBehaviour
{
    public TMP_InputField NicknameInput;

    public void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId)) PlayFabSettings.TitleId = "144";
            var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuides", CreateAccount = true };
            PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("로그인 성공");
    }

    void OnLoginFailure(PlayFabError error)
    {
        Debug.Log("로그인 실패");
    }
}
