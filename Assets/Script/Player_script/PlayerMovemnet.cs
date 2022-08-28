using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovemnet : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 5f;
    private bl_Joystick joystick;
    private PlayerAnimation anim;
   

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        joystick = GameObject.FindWithTag("JoyStick").GetComponent<bl_Joystick>();
        anim = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        rb.velocity = new Vector3(joystick.Vertical * moveSpeed * -1, rb.velocity.y, joystick.Horizontal * moveSpeed);

        if(joystick.Vertical != 0f || joystick.Vertical != 0f)
        {
            anim.Walk(true);
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
        else
        {
            anim.Walk(false);
        }
        InputUiBtn(-1);
    }

    public void InputUiBtn(int btn) 
    {
        if (btn == 0)
        {
            
            anim.Basic_Attack(true);
        }
        else
        {
            anim.Basic_Attack(false);
        }
           
    }
   




}
