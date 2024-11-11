using GoogleServices;
using UnityEngine;

namespace Menu.MenuButton
{
    [CreateAssetMenu(fileName = "AchievementHandler", menuName = "Models/ButtonHandler/AchievementHandler")]
    public class AchievementHandler : ButtonHandler
    {
        enum AchievementState
        {
            Unlock = 0,
            Reset = 1
        }

        [SerializeField] private string achievementName;
        [SerializeField] private AchievementState state;

        /// <summary>
        /// Handles the action of exiting the application.
        /// </summary>
        /// <param name="args">Optional arguments for the exit handler.</param>
        public override void Handle(params object[] args)
        {
            switch (state)
            {
                case AchievementState.Unlock:
                    AchievementController.GetInstance().UnlockAchievement(achievementName);
                    break;
                case AchievementState.Reset:
                    AchievementController.GetInstance().ResetAchievement(achievementName);
                    break;
            }
        }
    }
}