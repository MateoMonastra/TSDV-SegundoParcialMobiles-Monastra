using System;
using EventSystems.EventSoundManager;
using Game.Player;
using UnityEngine;

namespace Game.Collectables
{
    public class Coin : Collectable
    {
        [SerializeField] private float rotationSpeed = 100f;
        [SerializeField] private int value;
        [SerializeField] private PlayerScore playerScore;
        [SerializeField] private EventChannelSoundManager soundChannel;
        [SerializeField] private AudioClip coinSound;

        private void Update()
        {
            if (gameObject.activeInHierarchy)
            {
                transform.Rotate(Vector3.up * (Time.deltaTime * rotationSpeed));
            }
        }

        public override void InCollection()
        {
            playerScore.AddScore(value);
            gameObject.SetActive(false);
            if (coinSound)
            {
                soundChannel?.OnPlaySound(coinSound);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                InCollection();
            }
        }
    }
}