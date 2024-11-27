using System;
using TMPro;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class ResultPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI scoreText;

        public void SetTitle(string title)
        {
            titleText.text = title;
        }

        public void SetScore(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}
