using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillB : MonoBehaviour
{
    [SerializeField]
    GameObject obj;

    public void Destory()
    {
        Destroy(obj);
    }
}
