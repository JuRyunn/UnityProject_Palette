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
    private Animator animator;
    Vector3 moveVec;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // JHCODE
        //base.Setup(); // JHCODE
    }
    void Update()
    {
        moveVec = new Vector3(joy.Vertical * -1, 0, joy.Horizontal);
      
        
        moveVec.Normalize();

        rigid.MovePosition(rigid.position + moveVec); 
        if (moveVec.sqrMagnitude == 0)
            return;
        Quaternion dirQuat = Quaternion.LookRotation(moveVec);
        Quaternion moveQuat = Quaternion.Slerp(rigid.rotation, dirQuat, 0.3f);
        rigid.MoveRotation(moveQuat);
        transform.position += moveVec * speed * Time.deltaTime;
        attack_button.onClick.AddListener(() => attack_animator(true));
       
    }


  

    
    void attack_animator(bool attack_bool)
    {
        Debug.Log(attack_bool);
        if (attack_bool)
        {
            animator.SetTrigger("Basic_attack");
          
        }

    }
    
}
