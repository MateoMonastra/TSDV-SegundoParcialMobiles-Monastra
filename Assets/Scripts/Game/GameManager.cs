using System.Collections;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
    
        [SerializeField] private ResultPanel resultPanel;
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
            // _resultPanel.SetScore();
            resultPanel.SetTitle("You Lose :(");
        }
    
        public void WinGame()
        {
            resultPanel.gameObject.SetActive(true);
            // _resultPanel.SetScore();
            resultPanel.SetTitle("You Win!!");
        }

    }
}
