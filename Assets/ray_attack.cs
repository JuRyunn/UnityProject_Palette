using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray_attack : StateMachineBehaviour
{
    RaycastHit hit;
    float MaxDistance = 15f; // Ray의 거리(길이)
    //public GameObject Enemy_attack;
    // Start is called before the first frame update
    public void attack_raycast()
    {
        Debug.Log("attack_raycast");
        Debug.Log("attack_raycastattack_raycastattack_raycastattack_raycast");

       // Debug.DrawRay(transform.position, transform.up * MaxDistance, Color.blue, 1f);



       // if (Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance))
       // {
            //hit.transform.GetComponent<SpriteRenderer>().color = Color.red; // 젤랑이 색 변경 
        //    hit.transform.GetComponent<MeshRenderer>().material.color = Color.red; // 큐브 색 변경
       // }


        //Enemy_attack.GetComponent<EnemyController>().TakeDamage(10);

        // 적스크립트 호출 attack = true

        // true 면 적이 뎀지입게
    }
}
