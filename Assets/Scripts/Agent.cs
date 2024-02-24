using Codice.CM.Client.Differences;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] private int health=100;
    [SerializeField] private int speed=1;
    [SerializeField] private int damage=0;

    public int Health { get => health; set => health = value; }
    public int Speed { get => speed; set => speed = value; }
    public int Damage { get => damage; set => damage = value; }

    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        Debug.Log("Agent is moving");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Agent collided with: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().TakeDamage(Damage);
            Die();

        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Agent took damage");
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Agent died:"+ gameObject.name);
        Destroy(gameObject);
    }
}
