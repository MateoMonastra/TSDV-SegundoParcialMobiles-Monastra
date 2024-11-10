using UnityEngine.Events;

namespace Game.Player
{
    public class Player
    {
        public UnityEvent<bool> OnDeath;


        private bool _isDead = false;


        public void SetDead(bool value)
        {
            _isDead = value;

            OnDeath?.Invoke(_isDead);
        }
    }
}