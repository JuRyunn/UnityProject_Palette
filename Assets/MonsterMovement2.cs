using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement2 : MonoBehaviour
{
    public NavMeshAgent monster;
    public Transform player;

    void Start()
    {

    }

    void Update()
    {
        monster.SetDestination(player.position);
    }
}
