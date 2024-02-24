using Codice.CM.Client.Differences;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int speed;
    [SerializeField] private int damage;

    public int Health { get => health; set => health = value; }
    public int Speed { get => speed; set => speed = value; }
    public int Damage { get => damage; set => damage = value; }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public virtual void Move()
    {
        Debug.Log("Agent is moving");
    }
}
