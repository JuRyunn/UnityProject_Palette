using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray_attack : StateMachineBehaviour
{
    RaycastHit hit;
    float MaxDistance = 15f; // Ray�� �Ÿ�(����)
    //public GameObject Enemy_attack;
    // Start is called before the first frame update
    public void attack_raycast()
    {
        Debug.Log("attack_raycast");
        Debug.Log("attack_raycastattack_raycastattack_raycastattack_raycast");

       // Debug.DrawRay(transform.position, transform.up * MaxDistance, Color.blue, 1f);



       // if (Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance))
       // {
            //hit.transform.GetComponent<SpriteRenderer>().color = Color.red; // ������ �� ���� 
        //    hit.transform.GetComponent<MeshRenderer>().material.color = Color.red; // ť�� �� ����
       // }


        //Enemy_attack.GetComponent<EnemyController>().TakeDamage(10);

        // ����ũ��Ʈ ȣ�� attack = true

        // true �� ���� �����԰�
    }
}
