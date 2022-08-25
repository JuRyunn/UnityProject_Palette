using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    Animator GoblinAni;

    public Transform target; // �i�ư� Ÿ��
    public float GoblinSpeed;
    bool enableAct; // �׼ǽ���ġ
    int atkStep; // ���ݴܰ�

    private void Start()
    {
        GoblinAni = GetComponent<Animator>();
        enableAct = true;
    }

    
    void RotateGoblin() // ���Ͱ� Ÿ���� �ٶ󺸰��ϴ� �ڵ�
    {
        Vector3 dir = target.position - transform.position;

        transform.localRotation =
            Quaternion.Slerp(transform.localRotation,
                Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }

    void MoveGoblin() // ���Ͱ� Ÿ���� ���� �̵��ϴ� �ڵ�
    {
        // Ÿ�ٰ��� �Ÿ��� 10�̻��� ��� �̵�
        if((target.position - transform.position).magnitude >= 10)
        {
            GoblinAni.SetBool("Walk", true);
            transform.Translate(Vector3.forward * GoblinSpeed * Time.deltaTime, Space.Self);
        }

        // 10������ ��� ����
        if((target.position - transform.position).magnitude < 10)
        {
            GoblinAni.SetBool("Walk", false);
        }
    }

    private void Update()
    {
        if (enableAct)
        {
            // ��� ����
            RotateGoblin();
            MoveGoblin();
        }
    }

    void GoblinAtk() // ���� ��� �ڵ�
    {
        // �Ÿ��� 10 ������ ���
        if((target.position - transform.position).magnitude < 10)
        {
            // �ΰ��� ���� ����
            switch (atkStep)
            {
                case 0:
                    atkStep += 1;
                    GoblinAni.Play("Attack 01");
                    break;

                case 1:
                    atkStep += 1;
                    GoblinAni.Play("Attack 02");
                    break;
            }
        }
    }

    // ���� ����߿� �̵�, ȸ�� x 
    void FreezeGoblin()
    {
        enableAct = false;
    }
    void UnFreezeGoblin()
    {
        enableAct = true;
    }
}
