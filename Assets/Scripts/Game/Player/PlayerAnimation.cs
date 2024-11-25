using UnityEngine;

namespace Game.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private static readonly int IsDead = Animator.StringToHash("IsDead");
        private static readonly int HasWon = Animator.StringToHash("HasWon");
    
        [SerializeField] private Animator animator;
    
        public void SetIsDead(bool state)
        {
            animator.SetBool(IsDead, state);
        }
    
        public void SetHasWon(bool state)
        {
            animator.SetBool(HasWon, state);
        }
    }
}