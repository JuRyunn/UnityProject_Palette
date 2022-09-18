using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillA : MonoBehaviour
{
    [SerializeField]
    GameObject obj;

    public void Destory()
    {
        Destroy(obj);
    }
}
