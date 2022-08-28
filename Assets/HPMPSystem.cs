using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HPMPSystem : MonoBehaviour
{
    private Stats stats;
    public PlayerMovemnet target;

    public float HP 
    {
        // 체력이 0 ~ MAX HP 사이의 값을 넘을 수 없음.
        set => stats.HP = Mathf.Clamp(value, 0, MaxHP);
        get => stats.HP;
    }

    public float MP
    {
        // 마나가 0 ~ MAX HP 사이의 값을 넘을 수 없음.
        set => stats.MP = Mathf.Clamp(value, 0, MaxMP);
        get => stats.MP; 
    }

    
    public abstract float MaxHP { get; } // 최대체력
    public abstract float HPRecovery { get; } // 초당 체력 회복량
    public abstract float MaxMP { get; } // 최대마나
    public abstract float MPRecovery { get; } // 초당 마나 회복량

    protected void Setup()
    {
        HP = MaxHP;
        MP = MaxMP;

        StartCoroutine("Recovery"); // 체력마나를 회복하는 Recovery 호출
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

    // 상대방을 공격하면 적의 TakeDamage 호출
    // damage는 player의 공격력
    public abstract void TakeDamage(float damage);

    [System.Serializable]
    public struct Stats
    {

        // 스탯 구조체 정의 (체력, 마나, 이름, 레벨, 힘/지능 등...)
        [HideInInspector]
        public float HP;
        [HideInInspector]
        public float MP;

    }
}
