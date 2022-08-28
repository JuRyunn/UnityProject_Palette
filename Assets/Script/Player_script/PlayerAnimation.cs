using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Walk(bool walk)
    {
        animator.SetBool("Walk", walk);
    }

    public void Basic_Attack(bool attack)
    {
        Debug.Log(attack);
        animator.SetBool("Basic_Attack", attack);

    }

   

}
