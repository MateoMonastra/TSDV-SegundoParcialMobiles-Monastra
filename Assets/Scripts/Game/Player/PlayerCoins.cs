using CoinsSystem;
using TMPro;
using UnityEngine;

namespace Game.Player
{
    public class PlayerCoins : MonoBehaviour, ICoinsObserver
    {
        [SerializeField] private CoinsData coinsData;
    
        [SerializeField] private TextMeshProUGUI coinsText;

        private void OnEnable()
        {
            SetCoinsText(coinsData.GetCoins());
            coinsData.Subscribe(this);
        }

        private void OnDisable()
        {
            coinsData.Unsubscribe(this);
        }

        private void SetCoinsText(int coinsCount)
        {
            coinsText.text = coinsCount.ToString();
        }

        public void OnCoinsChanged(int newCoinAmount)
        {
            SetCoinsText(newCoinAmount);
        }
    }
}
