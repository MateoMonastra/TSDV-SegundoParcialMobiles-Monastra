using Fsm_Mk2;
using UnityEngine;

namespace Game.Player.FSM.States
{
    public class Running : State
    {
        RunningModel _model;

        private Rigidbody _rb;
        private Transform _position;

        public Running(GameObject player, RunningModel model)
        {
            _rb = player.gameObject.GetComponent<Rigidbody>();
            _position = player.gameObject.transform;
            _model = model;
        }
        public override void Enter()
        {
            if (SystemInfo.supportsGyroscope)
            {
                Input.gyro.enabled = true;
            }
            else
            {
                Debug.LogWarning("No gyro support detected");
            }
        }

        public override void Tick(float delta)
        {
        }

        public override void FixedTick(float delta)
        {
            _rb.AddForce(_position.forward * _model.ForwardForce);
            
            if (SystemInfo.supportsGyroscope)
            {
                RotateWithGyroscope();
            }
        }

        public override void Exit()
        {

        }

        void RotateWithGyroscope()
        {
            float gyroInput = Input.gyro.rotationRateUnbiased.x;
            
            float newRotationX = Mathf.Clamp(_position.eulerAngles.x + gyroInput * _model.RotationSpeed * Time.deltaTime, -_model.MaxRotationAngle, _model.MaxRotationAngle);
            
            _position.eulerAngles = new Vector3(newRotationX, _position.eulerAngles.y, _position.eulerAngles.z);
        }
    }
}