using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdventureSceneChange : MonoBehaviour
{
    public void ToAdventureScene()
    {
        SceneManager.LoadScene("Adventure");
    }
}
