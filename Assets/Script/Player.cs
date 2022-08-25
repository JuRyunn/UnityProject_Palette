using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public VariableJoystick joy;
    public float speed;
    public Button attack_button;
    //public GameObject Attack_Ray;
   // public Button attack_and_shield_button;
   // public Button on_jump;
   // public Button on_jump_attack;
    Rigidbody rigid;
    Animator anim;
    public bool is_attack = false;
    Ray ray;
    Vector3 moveVec;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {

        move();
        attack_button.onClick.AddListener(() => attack_animator(true));
     /*   attack_and_shield_button.onClick.AddListener(() => attack_and_shield_animator(true));
        on_jump.onClick.AddListener(() => jump_animator(true));
        on_jump_attack.onClick.AddListener(() => jump_attack_animator(true));*/

    }


    private void LateUpdate()
    {
        anim.SetFloat("Move", moveVec.sqrMagnitude);
    }

    void move()
    {
        float x = joy.Horizontal;
        float z = joy.Vertical;

        //playerAnimator.OnMovement(x, z);

        moveVec = new Vector3(x, 0, z) * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec); //캐릭터의 움직임 

        if (moveVec.sqrMagnitude == 0)
            return;

        Quaternion dirQuat = Quaternion.LookRotation(moveVec);
        Quaternion moveQuat = Quaternion.Slerp(rigid.rotation, dirQuat, 0.3f);
        rigid.MoveRotation(moveQuat); //캐릭터의 보는 방향 제어

    }
    void attack_animator(bool attack_bool)
    {
        if (attack_bool)
        {
            is_attack = true;
            Debug.Log(attack_bool);
            
            anim.SetTrigger("isattack01");
            //Attack_Ray.GetComponent<RayCast>().attack_raycast();
        }

    }
    
    void attack_and_shield_animator(bool attack_and_shield)
    {
        if (attack_and_shield)
        {

            anim.SetTrigger("isattack02");
        }

    }
    void jump_animator(bool on_jump)
    {
        if (on_jump)
        {

            anim.SetTrigger("OnJump");
        }

    }
    void jump_attack_animator(bool jump_attack)
    {
        if (jump_attack)
        {

            anim.SetTrigger("jump_attack");
        }

    }
}
