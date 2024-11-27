using EventSystems.EventSoundManager;
using UnityEngine;

namespace Game.Player
{
    public class PlayerSfx : MonoBehaviour
    {
        [SerializeField] private EventChannelSoundManager soundChannel;
        [SerializeField] private AudioClip deadSound;

        public void PlayDeadSound()
        {
            if (deadSound)
            {
                soundChannel?.PlaySound(deadSound);
            }
        }
    }
}