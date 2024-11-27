using Fsm_Mk2;
using UnityEngine;

namespace Game.Player.FSM.States
{
    public class Running : State
    {
        RunningModel _model;
        
        private GameObject _player;

        public Running(GameObject player, RunningModel model)
        {
            _player = player;
            _model = model;
        }
        public override void Enter()
        {
            if (SystemInfo.supportsAccelerometer)
            {
                Input.gyro.enabled = true;
            }
            else
            {
                Debug.LogWarning("No accelerometer support detected");
            }
        }

        public override void Tick(float delta)
        {
        }

        public override void FixedTick(float delta)
        {
            if (_player.transform.position.z < _model.MaxSpeed)
            {
                _player.transform.Translate(Vector3.forward * (_model.ForwardForce * Time.deltaTime));
            }

            if (SystemInfo.supportsAccelerometer)
            {
                RotateWithGyroscope();
            }
        }

        public override void Exit()
        {

        }

        void RotateWithGyroscope()
        {
            float accelerationZ = Input.acceleration.z;
            float newRotationY = _player.transform.eulerAngles.y + accelerationZ * _model.RotationSpeed * Time.deltaTime;

            if (newRotationY > 180f) newRotationY -= 360f;
            if (newRotationY < -180f) newRotationY += 360f;

            newRotationY = Mathf.Clamp(newRotationY, -_model.MaxRotationAngle, _model.MaxRotationAngle);

            _player.transform.eulerAngles = new Vector3(_player.transform.eulerAngles.x, newRotationY, _player.transform.eulerAngles.z);

        }
    }
}