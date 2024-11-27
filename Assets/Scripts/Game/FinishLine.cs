using EventSystems.EventSoundManager;
using Game.Player;
using UnityEngine;

namespace Game
{
    public class FinishLine : MonoBehaviour
    {
        [SerializeField] private FinishLineColision finishLineColision;

        [SerializeField] private EventChannelSoundManager soundChannel;
        [SerializeField] private AudioClip celebrationSound;

        void Start()
        {
            finishLineColision.OnPlayerColision += PlayerWin;
        }

        private void PlayerWin(GameObject player)
        {
            player.GetComponent<PlayerAgent>().SetWinState();
            GameManager.GetInstance().WinGame();
            if (celebrationSound)
            {
                soundChannel?.PlaySound(celebrationSound);
            }
        }
    }
}