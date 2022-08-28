using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Walk(bool walk)
    {
        animator.SetBool("Walk", walk);
    }

    public void Basic_Attack(bool attack)
    {
        animator.Play("Basic_Attack");
    }
}
