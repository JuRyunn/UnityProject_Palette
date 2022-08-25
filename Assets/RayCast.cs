using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour

{
    public bool Attacked = false;


    public Player player;
    RaycastHit hit;
    float MaxDistance = 1; // Ray의 거리(길이)
    public GameObject Enemy_attack;
    // Start is called before the first frame update

    public GameObject _player;

    public LayerMask WhatIsTarget;
    float duration = 5;
    float smoothness = 0.02f;

    public void Start()
    {
        player = _player.GetComponent<Player>();
//StartCoroutine("Lerp_isAttack");
    }


    public void Update()
    {

        //Debug.Log(player.is_attack);

        //Player_script.GetComponent<Player>().   (10);

        player.is_attack = true;

        //플레이어가 공격할시 ( is_attack = true 일시 )
        if (player.is_attack) 
        {
          //  Debug.Log("공격!");
            //레이캐스트 출력 ( 공격범위 )
            Debug.DrawRay(transform.position, transform.up * MaxDistance, Color.blue, 1f);

            // if (Physics.Raycast(transform.position, transform.forward, MaxDistance,WhatIsTarget))

            if (Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance))
            {
                //레이캐스트에 걸린 오브젝트
                GameObject onHitTarget = hit.collider.gameObject;

                if( onHitTarget.tag == "Enemy")
                {
                    Attacked = true;
                    Debug.Log(" 적 태그에 닿음 !");

                    //레이캐스트에 닿은 대상의 Material 접근하여 색상변경 ( 쉐이더 material접근방식 )
                    Material onHitTarget_color = onHitTarget.GetComponentInChildren<SkinnedMeshRenderer>().material;

                    // 아래와 같이 스크립트상에서 Material의 Color값을 설정할때는 인스펙터상에서의 원하는 RGB 값에 각 나누기 255한
                    // 값을 넣어주어야 똑같이 나온다. ( ex. new Color(1,1,1) -> 실제 인스펙터상에서 ( 255,255,255 )
                    onHitTarget_color.SetColor("_Color", new Color(0.8f, 0.3f, 0.3f));

                   // onHitTarget.GetComponent<EnemyController>().TakeDamage();


                    //Enemy가 가진 TakeDamage() 에 현재 Player의 Damage값을 넣어 함수 실행시킴
                    //_EnemyController.TakeDamage(Damage);
                }
                Attacked = false;
            }

           
        }

        /*IEnumerator Lerp_isAttack()
        {
            float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
            float increment = smoothness/duration // The amount of change to apply
                while(progress < 1)
            {
                onHitTarget_color

            }
        }*/



    }
    /*public void attack_raycast(int damage)
    {



        //Debug.Log("Attack");

        //Enemy_attack.GetComponent<EnemyController>().TakeDamage(10);

        // 적스크립트 호출 attack = true

        // true 면 적이 뎀지입게
    }*/

}







