using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public VariableJoystick joy;
    public float speed;
    
    private PlayerAnimator playerAnimator;

    Rigidbody rigid;
    Animator anim;
    Vector3 moveVec;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    private void FixedUpdate()
    {
        float x = joy.Horizontal;
        float z = joy.Vertical;

        //playerAnimator.OnMovement(x, z);

        moveVec = new Vector3(x, 0, z) * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec);

        if (moveVec.sqrMagnitude == 0)
            return;

        Quaternion dirQuat = Quaternion.LookRotation(moveVec);
        Quaternion moveQuat = Quaternion.Slerp(rigid.rotation, dirQuat, 0.3f);
        rigid.MoveRotation(moveQuat);

    }

    private void LateUpdate()
    {
        anim.SetFloat("Move", moveVec.sqrMagnitude);
    }
}
