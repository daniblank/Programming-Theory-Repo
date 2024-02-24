using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Agent
{
    private GameObject goal;
    NavMeshAgent agent = new NavMeshAgent();
    public override void Move()
    {
    }
    private void Awake()
    {
        Speed = 10;
        Health = 30;
        Damage = 50;
        goal = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.transform.position;
    }
    private void Update()
    {
        goal = GameObject.Find("Player");
        if (SpawnManager.Instance.isGameOver)
        {
            agent.destination = transform.position;
            return;
        }
        agent.destination = goal.transform.position;
    }

}
