using System;
using System.Collections;
using System.Collections.Generic;
using Game.Player;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.GetInstance().LoseGame();
            other.gameObject.GetComponent<Player>().SetDead(true);
        }
    }
}
