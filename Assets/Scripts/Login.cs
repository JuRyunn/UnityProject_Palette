using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField ID_Input;
    public InputField PW_Input;
    public Text ErrorText;

    private string username;
    private string password;
    
    void Start()
    {
        PlayFabSettings.TitleId= "C710A";
    }

    public void ID_Value_Changed()
    {
        username = ID_Input.text.ToString();
    }

    public void PW_value_Changed()
    {
        password = PW_Input.text.ToString();
    }

    public void Login2()
    {
        var request = new LoginWithPlayFabRequest { Username = username, Password = password };
        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginFailure);

    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Login Success!");
        //SceneManager.LoadScene("");
        ErrorText.text = "Login Success!";
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Login Failed!");
        Debug.LogWarning(error.GenerateErrorReport());
        ErrorText.text = error.GenerateErrorReport();
    }

    public void Register()
    {
        var request = new RegisterPlayFabUserRequest { Username = username, Password = password, };
        PlayFabClientAPI.RegisterPlayFabUser(request, RegisterSuccess, RegisterFailure);
    }

    private void RegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("가입 성공");
        ErrorText.text = "가입 성공";
    }

    private void RegisterFailure(PlayFabError error)
    {
        Debug.LogWarning("가입 실패");
        Debug.LogWarning(error.GenerateErrorReport());
        ErrorText.text = error.GenerateErrorReport();
    }

}
