using Fsm_Mk2;
using UnityEngine;

namespace Game.Player.FSM.States
{
    public class Dead : State
    {
        private Rigidbody _rb = null;
        public Dead(GameObject player)
        {
            _rb = player.GetComponent<Rigidbody>();
        }
        public override void Enter()
        {
            _rb.constraints = RigidbodyConstraints.FreezeAll; 
        }

        public override void Tick(float delta)
        {
        }

        public override void FixedTick(float delta)
        {
        }

        public override void Exit()
        {
        }
    }
}
