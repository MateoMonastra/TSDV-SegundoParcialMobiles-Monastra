using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Animator playerAnimation;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.GetInstance().LoseGame();

            if (playerAnimation)
            {
                playerAnimation.SetBool("IsDead", true);
            }
        }
    }
}
