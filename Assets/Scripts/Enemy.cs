using UnityEngine;
using UnityEngine.AI;

public class Enemy : Agent
{
    private GameObject player;
    NavMeshAgent agent = new NavMeshAgent();
    public override void Move()
    {
    }
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        player = GameObject.Find("Player");
        if (GameManager.Instance.IsGameOver)
        {
            agent.destination = transform.position;
            return;
        }
        if (player != null)
            agent.destination = player.transform.position;
    }

}
