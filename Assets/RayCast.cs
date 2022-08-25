using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour

{
    public bool Attacked = false;


    public Player player;
    RaycastHit hit;
    float MaxDistance = 1; // Ray�� �Ÿ�(����)
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

        //�÷��̾ �����ҽ� ( is_attack = true �Ͻ� )
        if (player.is_attack) 
        {
          //  Debug.Log("����!");
            //����ĳ��Ʈ ��� ( ���ݹ��� )
            Debug.DrawRay(transform.position, transform.up * MaxDistance, Color.blue, 1f);

            // if (Physics.Raycast(transform.position, transform.forward, MaxDistance,WhatIsTarget))

            if (Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance))
            {
                //����ĳ��Ʈ�� �ɸ� ������Ʈ
                GameObject onHitTarget = hit.collider.gameObject;

                if( onHitTarget.tag == "Enemy")
                {
                    Attacked = true;
                    Debug.Log(" �� �±׿� ���� !");

                    //����ĳ��Ʈ�� ���� ����� Material �����Ͽ� ���󺯰� ( ���̴� material���ٹ�� )
                    Material onHitTarget_color = onHitTarget.GetComponentInChildren<SkinnedMeshRenderer>().material;

                    // �Ʒ��� ���� ��ũ��Ʈ�󿡼� Material�� Color���� �����Ҷ��� �ν����ͻ󿡼��� ���ϴ� RGB ���� �� ������ 255��
                    // ���� �־��־�� �Ȱ��� ���´�. ( ex. new Color(1,1,1) -> ���� �ν����ͻ󿡼� ( 255,255,255 )
                    onHitTarget_color.SetColor("_Color", new Color(0.8f, 0.3f, 0.3f));

                   // onHitTarget.GetComponent<EnemyController>().TakeDamage();


                    //Enemy�� ���� TakeDamage() �� ���� Player�� Damage���� �־� �Լ� �����Ŵ
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

        // ����ũ��Ʈ ȣ�� attack = true

        // true �� ���� �����԰�
    }*/

}







