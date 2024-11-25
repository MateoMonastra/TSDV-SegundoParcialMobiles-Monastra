using System;
using UnityEngine;

namespace Game
{
    public class FinishLineColision : MonoBehaviour
    {
        public Action<GameObject> OnPlayerColision;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnPlayerColision.Invoke(other.gameObject);
            }
        }
    }
}
