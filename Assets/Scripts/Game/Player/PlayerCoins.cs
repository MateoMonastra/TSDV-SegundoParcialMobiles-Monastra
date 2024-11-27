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


        private void Start()
        {
            SetCoinsText(coinsData.GetCoins());
        }

        public void SetCoinsText(int coinsCount)
        {
            coinsText.text = coinsCount.ToString();
        }
    }
}
