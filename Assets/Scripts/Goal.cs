using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : Agent
{

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Debug.Log("FINISHED!");
            GameManager.Instance.IsGameOver = true;
            return;

        }
    }
}
