using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public Vector3 offset; 



    void Update()
    {
        //ī�޶��� position�� Ÿ���� ��ġ���� �Ʒ� �ش��������ŭ �����
        transform.position = target.position + offset;
    }
}
