using System.Collections;
using System.Collections.Generic;
using CoinsSystem;
using Menu.LevelSelector;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerPrefSetter : MonoBehaviour
{
    [SerializeField] private CoinsData coinsData;
    [SerializeField] private LevelsData levelsData;
    
    void Start()
    {
        coinsData.SetCoins(PlayerPrefs.GetInt("Coins", 0));
        levelsData.levels[0] = PlayerPrefs.GetInt("Level1", 1);
        levelsData.levels[1] = PlayerPrefs.GetInt("Level2", 0);
        levelsData.levels[2] = PlayerPrefs.GetInt("Level3", 0);
        levelsData.levels[3] = PlayerPrefs.GetInt("Level4", 0);
    }

}
