using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] private int health=100;
    [SerializeField] private int speed=1;
    [SerializeField] private int damage=10;
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
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Agent>().TakeDamage(Damage);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Agent "+gameObject.name+" took damage: "+damage+" new health:"+(Health - damage));
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log("Agent died:"+ gameObject.name);
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
