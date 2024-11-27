using TMPro;
using UnityEngine;

namespace Game.Player
{
    public class PlayerScore : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI scoreText;
        
        private int _score = 0;
        private void Start()
        {
            SetScoreText(_score);
        }

        public void AddScore(int scoreToAdd)
        {
            _score += scoreToAdd;
            SetScoreText(_score);
        }

        private void SetScoreText(int text)
        {
            scoreText.text = text.ToString();
        }

        public int GetScore()
        {
            return _score;
        }
    }
}