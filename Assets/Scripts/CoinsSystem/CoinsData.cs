using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CoinsSystem
{
    public interface ICoinsObserver
    {
        void OnCoinsChanged(int newCoinAmount);
    }

    [CreateAssetMenu(fileName = "CoinsData", menuName = "ScriptableObjects/CoinsData", order = 1)]
    public class CoinsData : ScriptableObject
    {
        public bool logsAreActive;

        private int _coins;
        private List<ICoinsObserver> _observers = new List<ICoinsObserver>();

        public int GetCoins()
        {
            return _coins;
        }

        public void AddCoins(int coinsToAdd)
        {
            _coins += coinsToAdd;
            SaveCoins();
            NotifyObservers();
            LogCoins();
        }
        
        public void SetCoins(int coinsToAdd)
        {
            _coins = coinsToAdd;
            SaveCoins();
            NotifyObservers();
            LogCoins();
        }

        public void RemoveCoins(int coinsToRemove)
        {
            _coins -= coinsToRemove;
            SaveCoins();
            NotifyObservers();
            LogCoins();
        }

        public void CheatCoins()
        {
            _coins = 50;
            SaveCoins();
            NotifyObservers();
            LogCoins();
        }

        public void ClearCoins()
        {
            _coins = 0;
            SaveCoins();
            NotifyObservers();
            LogCoins();
        }

        public void Subscribe(ICoinsObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void Unsubscribe(ICoinsObserver observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }

        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.OnCoinsChanged(_coins);
            }
        }

        private void LogCoins()
        {
            if (logsAreActive)
            {
                Debug.Log($"Coins: {_coins}");
            }
        }

        private void SaveCoins()
        {
            PlayerPrefs.SetInt("Coins", _coins);
        }
    }
}