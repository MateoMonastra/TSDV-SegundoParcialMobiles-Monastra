using System.Collections.Generic;
using Fsm_Mk2;
using Game.Player.FSM.States;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Player
{
    public class PlayerAgent : MonoBehaviour
    {
        public UnityEvent OnDeath;
        public UnityEvent OnWin;
        
        [SerializeField] private RunningModel runningModel;
        
        private List<State> _states = new List<State>();

        private Fsm _fsm;

        private Transition _runningToDead;
        private Transition _runningToWin;

        private void Start()
        {
            State running = new Running(this.gameObject, runningModel);
            _states.Add(running);

            State dead = new Dead();
            State win = new Win();

            _runningToDead = new Transition(){ From = running, To = dead };;
            running.transitions.Add(_runningToDead);
            
            _runningToWin = new Transition(){ From = running, To = win };
            running.transitions.Add(_runningToWin);
        }

        public void SetDeadState()
        {
            _fsm?.ApplyTransition(_runningToDead);
            OnDeath?.Invoke();
        }
        
        public void SetWinState()
        {
            _fsm?.ApplyTransition(_runningToWin);
            OnWin?.Invoke();
        }
        
        private void Update()
        {
            _fsm.Update();
        }

        private void FixedUpdate()
        {
            _fsm.FixedUpdate();
        }
    }
}