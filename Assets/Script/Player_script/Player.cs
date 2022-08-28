using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private SpriteRenderer spriteRenderer; // JHCODE

    public bl_Joystick joy;
    public float speed;
    public Button attack_button;

    Rigidbody rigid;
    Animator anim;


    Vector3 moveVec;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>(); // JHCODE
        //base.Setup(); // JHCODE
    }
    private void FixedUpdate()
    {

        move();
        attack_button.onClick.AddListener(() => attack_animator(true));
     

    }



    private void LateUpdate()
    {
        anim.SetFloat("isWalking", moveVec.sqrMagnitude);

    }

    void move()
    {
       /* float x = joy.Horizontal;
        float z = joy.Vertical;

        //playerAnimator.OnMovement(x, z);

        moveVec = new Vector3(x, 0, z) * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec); //ĳ������ ������ 

        if (moveVec.sqrMagnitude == 0)
            return;

        Quaternion dirQuat = Quaternion.LookRotation(moveVec);
        Quaternion moveQuat = Quaternion.Slerp(rigid.rotation, dirQuat, 0.3f);
        rigid.MoveRotation(moveQuat); //ĳ������ ���� ���� ����*/

        Vector3 dir = new Vector3(joy.Vertical * -1, 0, joy.Horizontal);
        Quaternion dirQuat = Quaternion.LookRotation(moveVec);
        Quaternion moveQuat = Quaternion.Slerp(rigid.rotation, dirQuat, 0.3f);
        // Vector�� ������ ���������� ũ�⸦ 1�� ���δ�. ���̰� ����ȭ ���� ������ 0���� ����.
        dir.Normalize();
        rigid.MoveRotation(moveQuat); //ĳ������ ���� ���� ����
        // ������Ʈ�� ��ġ�� dir �������� �̵���Ų��.
        transform.position += dir * speed * Time.deltaTime; 


    }
    void attack_animator(bool attack_bool)
    {
        if (attack_bool)
        {  
            anim.SetTrigger("isattack01");
          
        }

    }
    
}
