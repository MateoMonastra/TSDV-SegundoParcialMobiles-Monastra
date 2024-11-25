using Game.Player;
using UnityEngine;

namespace Game
{
    public class Obstacle : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.GetInstance().LoseGame();
                other.gameObject.GetComponent<PlayerAgent>().SetDeadState();
            }
        }
    }
}
