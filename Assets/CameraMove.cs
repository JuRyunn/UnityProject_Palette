using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public Vector3 offset; 



    void Update()
    {
        //카메라의 position을 타겟의 위치에서 아래 해당고정값만큼 띄워줌
        transform.position = target.position + offset;
    }
}
