using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Agent
{
    private Vector2 inputVector = Vector2.zero;
    public override void Move()
    {
        if (inputVector != Vector2.zero)
        {
             transform.Translate(new Vector3(inputVector.x, 0, inputVector.y) * Speed * Time.deltaTime);
        }
    }

     public void OnMove(InputValue value)
    {
        if (GameManager.Instance.IsGameOver)
        {
            inputVector = Vector2.zero;
            return;
        }
        inputVector = value.Get<Vector2>();
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
    public override void Die()
    {
        Debug.Log("Player died:" + gameObject.name);
        GameManager.Instance.IsGameOver = true;
        Destroy(gameObject);
    }


}
