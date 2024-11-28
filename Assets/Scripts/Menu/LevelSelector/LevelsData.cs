using System.Collections.Generic;
using GoogleServices;
using UnityEngine;

namespace Menu.LevelSelector
{
    [CreateAssetMenu(fileName = "LevelsData", menuName = "LevelsData")]
    public class LevelsData : ScriptableObject
    {
        public List<int> levels;
        [SerializeField] private string achievementName;

        public void AreAllLevelsUnlocked()
        {
            foreach (var level in levels)
            {
                if (level != 0)
                    return;
            }

            AchievementController.GetInstance().UnlockAchievement(achievementName);
        }

        public void SaveLevelsData()
        {
            PlayerPrefs.SetInt("Level1",levels[0] );
            PlayerPrefs.SetInt("Level2",levels[1] );
            PlayerPrefs.SetInt("Level3",levels[2] );
            PlayerPrefs.SetInt("Level4",levels[3] );
        }
    }
}