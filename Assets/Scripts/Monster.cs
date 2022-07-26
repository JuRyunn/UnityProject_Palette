using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    private Transform monstertr;
    private Transform Playertr;
    private NavMeshAgent nvAgent;

    // Start is called before the first frame update
    void Start()
    {
        monstertr = gameObject.GetComponent<Transform>();
        Playertr = GameObject.FindWithTag("Player").GetComponent<Transform>();

        nvAgent = gameObject.GetComponent<NavMeshAgent>();
        nvAgent.destination = Playertr.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
