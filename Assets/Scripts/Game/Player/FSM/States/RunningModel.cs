using UnityEngine;

namespace Game.Player.FSM.States
{
    [CreateAssetMenu(fileName = "RunningModel", menuName = "Player/States/RunningModel")]
    public class RunningModel : ScriptableObject
    {
        [SerializeField] private float forwardForce = 10f;
        [SerializeField] private float rotationSpeed = 100f;
        [SerializeField] private float maxRotationAngle = 60f;

        public float ForwardForce
        {
            get => forwardForce;
            set => forwardForce = value;
        }

        public float RotationSpeed
        {
            get => rotationSpeed;
            set => rotationSpeed = value;
        }

        public float MaxRotationAngle
        {
            get => maxRotationAngle;
            set => maxRotationAngle = value;
        }
    }
}