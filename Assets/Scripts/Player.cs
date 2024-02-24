using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Agent
{
    private Vector2 inputVector;
    public override void Move()
    {
        if (inputVector != Vector2.zero)
        {
             transform.Translate(new Vector3(inputVector.x, 0, inputVector.y) * Speed * Time.deltaTime);
        }
    }

    private void Awake()
    {
        inputVector = Vector2.zero;
        Speed = 10;
        Health = 1000;
        Damage = 1;
    }


    public void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }


    
}
