using System;
using CoinsSystem;
using TMPro;
using UnityEngine;

namespace Game.Player
{
    public class PlayerCoins : MonoBehaviour
    {
        [SerializeField] private CoinsData coinsData;
    
        [SerializeField] private TextMeshProUGUI coinsText;

        private void OnEnable()
        {
            SetCoinsText(coinsData.GetCoins());
            coinsData.OnChange += SetCoinsText;
        }

        private void SetCoinsText(int coinsCount)
        {
            coinsText.text = coinsCount.ToString();
        }
    }
}
