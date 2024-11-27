using GoogleServices;
using UnityEngine;

namespace Game.Collectables
{
    public class SecretAchievement : Collectable
    {
        [SerializeField] private float rotationSpeed = 100f;
        [SerializeField] private string achievementName;

        private void Update()
        {
            if (gameObject.activeInHierarchy)
            {
                transform.Rotate(Vector3.up * (Time.deltaTime * rotationSpeed));
            }
        }
        public override void InCollection()
        {
            AchievementController.GetInstance().UnlockAchievement(achievementName);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                InCollection();
                gameObject.SetActive(false);
            }
        }
    }
}
