using System.Collections;
using CoinsSystem;
using Game.Player;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
    
        [SerializeField] private ResultPanel resultPanel;
        [SerializeField] private PlayerScore playerScore;
        [SerializeField] private CoinsData coinsData;
        IEnumerator Start()
        {
            yield return null;

            if (_instance == null)
            {
                _instance = this;
            }
            else if (_instance != this)
            {
                // Si ya existe una instancia y no es esta, se destruye el objeto duplicado
                Destroy(gameObject);
            }
        
        }
    
        private void OnDestroy()
        {
            if (_instance == this)
                _instance = null;
        }
    
        public static GameManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }

            return _instance;
        }

        public void LoseGame()
        {
            resultPanel.gameObject.SetActive(true);
            resultPanel.SetScore(playerScore.GetScore());
            resultPanel.SetTitle("You Lose :(");
        }
    
        public void WinGame()
        {
            resultPanel.gameObject.SetActive(true);
            resultPanel.SetScore(playerScore.GetScore());
            coinsData.AddCoins(playerScore.GetScore());
            resultPanel.SetTitle("You Win!!");
        }

    }
}
