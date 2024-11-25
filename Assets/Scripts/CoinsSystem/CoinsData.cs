using UnityEngine;
using UnityEngine.Serialization;

namespace CoinsSystem
{
    [CreateAssetMenu(fileName = "CoinsData", menuName = "CoinsData")]
    public class CoinsData : ScriptableObject
    {
        public bool logsAreActive;
        private int _coins;

        public int GetCoins()
        {
            return _coins;
        }

        public void AddCoins(int coinsToAdd)
        {
            _coins += coinsToAdd;
            if (logsAreActive)
                Debug.Log(_coins);
        }

        public void RemoveCoins(int coinsToRemove)
        {
            _coins -= coinsToRemove;
            if (logsAreActive)
                Debug.Log(_coins);
        }

        public void CheatCoins()
        {
            _coins = 50;
            if (logsAreActive)
                Debug.Log(_coins);
        }

        public void ClearCoins()
        {
            _coins = 0;
            if (logsAreActive)
                Debug.Log(_coins);
        }
    }
}