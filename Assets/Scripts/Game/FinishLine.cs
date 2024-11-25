using Game.Player;
using UnityEngine;

namespace Game
{
    public class FinishLine : MonoBehaviour
    {
        [SerializeField] private FinishLineColision finishLineColision;
        
        void Start()
        {
            finishLineColision.OnPlayerColision += PlayerWin;
        }

        private void PlayerWin(GameObject player)
        {
            player.GetComponent<PlayerAgent>().SetWinState();
            GameManager.GetInstance().WinGame();
        }
    }
}
