using Fsm_Mk2;
using UnityEngine;

namespace Game.Player.FSM.States
{
    public class Running : State
    {
        RunningModel _model;

        private Rigidbody _rb;
        private GameObject _player;

        public Running(GameObject player, RunningModel model)
        {
            _rb = player.gameObject.GetComponent<Rigidbody>();
            _player = player;
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
            if (_rb.velocity.magnitude < _model.MaxSpeed)
            {
                _rb.AddForce(_player.transform.forward * _model.ForwardForce, ForceMode.Acceleration);
            }

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
            float gyroInput = Input.gyro.rotationRateUnbiased.y;
            
            float newRotationY = _player.transform.eulerAngles.y + gyroInput * _model.RotationSpeed * Time.deltaTime;
            
            if (newRotationY > 180f) newRotationY -= 360f;
            if (newRotationY < -180f) newRotationY += 360f;
            
            newRotationY = Mathf.Clamp(newRotationY, -_model.MaxRotationAngle, _model.MaxRotationAngle);
            
            _player.transform.eulerAngles = new Vector3(_player.transform.eulerAngles.x, newRotationY, _player.transform.eulerAngles.z);
        }
    }
}