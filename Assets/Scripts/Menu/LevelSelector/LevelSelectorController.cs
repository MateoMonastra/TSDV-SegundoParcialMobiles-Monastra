using System.Collections.Generic;
using CoinsSystem;
using UnityEngine;

namespace Menu.LevelSelector
{
    public class LevelSelectorController : MonoBehaviour
    {
        [SerializeField] private List<LevelButton> levelButtons;
        [SerializeField] private LevelsData levelsData;
        [SerializeField] private CoinsData coinsData;

        private void Start()
        {
            for (int i = 0; i < levelButtons.Count; i++)
            {
                if (levelsData.levels[i])
                {
                    levelButtons[i].ActivateLevel();
                }
                else
                {
                    levelButtons[i].DeactivateLevel();
                }
            }
        }

        public void TryPurchase(LevelButton levelButton)
        {
            if (levelButton.priceValue > coinsData.GetCoins()) return;
            
            coinsData.RemoveCoins(levelButton.priceValue);
            levelButton.ActivateLevel();
            
            levelsData.AreAllLevelsUnlocked();
        }
        
        
    }
}