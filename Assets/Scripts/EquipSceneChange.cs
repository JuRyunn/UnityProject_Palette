using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EquipSceneChange : MonoBehaviour
{
    public void ToEquipScene()
    {
        SceneManager.LoadScene("Equip");
    }
}
