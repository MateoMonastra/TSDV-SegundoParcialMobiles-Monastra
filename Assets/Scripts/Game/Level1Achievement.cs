using GoogleServices;
using UnityEngine;

namespace Game
{
    public class Level1Achievement : MonoBehaviour
    {
        [SerializeField] private string achievementName;
        private void OnEnable()
        {
            GameManager.GetInstance().OnFinish += () => {  AchievementController.GetInstance().UnlockAchievement(achievementName);};
        }

        private void OnDisable()
        {
            GameManager.GetInstance().OnFinish -= () => {  AchievementController.GetInstance().UnlockAchievement(achievementName);};
        }
    }
}
