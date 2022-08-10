using System;
using UnityEngine;
using Character;

namespace Flags
{
    public abstract class BaseFlag : MonoBehaviour
    {
        [SerializeField]
        private const string PLAYER = "Player";
        private BallTriggerSystem _ballTriggerSystem;

        private void Start()
        {
            _ballTriggerSystem = new BallTriggerSystem();
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == PLAYER)
            {
                _ballTriggerSystem.OnTrigger(this.gameObject);
                return;
            }
        }

    }
}
