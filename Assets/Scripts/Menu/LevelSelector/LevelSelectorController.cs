using System.Collections.Generic;
using System.Linq;
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
                if (levelsData.levels[i] != 0)
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
            if (levelButtons.Where((t, index) => t == levelButton && levelsData.levels[index] == 1).Any())
            {
                return;
            }

            if (levelButton.priceValue > coinsData.GetCoins() ) return;
            
            coinsData.RemoveCoins(levelButton.priceValue);
            levelButton.ActivateLevel();
            
            for (var index = 0; index < levelButtons.Count; index++)
            {
                if (levelButtons[index] == levelButton)
                {
                    levelsData.levels[index] = 1;
                }
            }


            levelsData.AreAllLevelsUnlocked();
            levelsData.SaveLevelsData();
        }
        
        
    }
}