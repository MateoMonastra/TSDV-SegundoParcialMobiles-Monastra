using System.Collections.Generic;
using GoogleServices;
using UnityEngine;

namespace Menu.LevelSelector
{
    [CreateAssetMenu(fileName = "LevelsData", menuName = "LevelsData")]
    public class LevelsData : ScriptableObject
    {
        public List<bool> levels;
        [SerializeField] private string achievementName;

        public void AreAllLevelsUnlocked()
        {
            foreach (var level in levels)
            {
                if (level)
                    return;
            }

            AchievementController.GetInstance().UnlockAchievement(achievementName);
        }
    }
}