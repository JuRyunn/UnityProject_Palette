using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour

{
    public Player player;
    RaycastHit hit;
    float MaxDistance = 1; // Ray의 거리(길이)
    public GameObject Enemy_attack;
    // Start is called before the first frame update

    public void Update()
    {
        Debug.Log(player.is_attack);

        //Player_script.GetComponent<Player>().   (10);




        if (player.is_attack) // <- true
        {
            Debug.DrawRay(transform.position, transform.up * MaxDistance, Color.blue, 1f);
            if (Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance))
            {
                //hit.transform.GetComponent<SpriteRenderer>().color = Color.red; // 젤랑이 색 변경 
                Debug.Log("ddd");
            }
         


        }
        player.is_attack = false;



    }
    public void attack_raycast()
    {



        Debug.Log("Attack");

        //Enemy_attack.GetComponent<EnemyController>().TakeDamage(10);

        // 적스크립트 호출 attack = true

        // true 면 적이 뎀지입게
    }

}







