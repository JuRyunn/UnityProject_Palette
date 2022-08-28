using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HPMPSystem : MonoBehaviour
{
    private Stats stats;
    public PlayerMovemnet target;

    public float HP 
    {
        // ü���� 0 ~ MAX HP ������ ���� ���� �� ����.
        set => stats.HP = Mathf.Clamp(value, 0, MaxHP);
        get => stats.HP;
    }

    public float MP
    {
        // ������ 0 ~ MAX HP ������ ���� ���� �� ����.
        set => stats.MP = Mathf.Clamp(value, 0, MaxMP);
        get => stats.MP; 
    }

    
    public abstract float MaxHP { get; } // �ִ�ü��
    public abstract float HPRecovery { get; } // �ʴ� ü�� ȸ����
    public abstract float MaxMP { get; } // �ִ븶��
    public abstract float MPRecovery { get; } // �ʴ� ���� ȸ����

    protected void Setup()
    {
        HP = MaxHP;
        MP = MaxMP;

        StartCoroutine("Recovery"); // ü�¸����� ȸ���ϴ� Recovery ȣ��
    }

    protected IEnumerator Recovery()
    {
        while (true)
        {
            if (HP < MaxHP) HP += HPRecovery;
            if (MP < MaxMP) MP += MPRecovery;

            yield return new WaitForSeconds(1);
        }
    }

    // ������ �����ϸ� ���� TakeDamage ȣ��
    // damage�� player�� ���ݷ�
    public abstract void TakeDamage(float damage);

    [System.Serializable]
    public struct Stats
    {

        // ���� ����ü ���� (ü��, ����, �̸�, ����, ��/���� ��...)
        [HideInInspector]
        public float HP;
        [HideInInspector]
        public float MP;

    }
}
