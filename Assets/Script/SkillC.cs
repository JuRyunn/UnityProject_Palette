using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillC : MonoBehaviour
{
    [SerializeField]
    GameObject obj;

    public void Destory()
    {
        Destroy(obj);
    }
}
