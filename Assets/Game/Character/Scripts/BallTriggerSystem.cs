using System;
using General.Scripts;
using Flags;
using UnityEngine;

namespace Character
{
    class BallTriggerSystem
    {
        private BallFlag _ballFlag;
        private BombFlag _bombFlag;
       /* public BallTriggerSystem(BallFlag ballFlag, BombFlag bombFlag)
        {
            _ballFlag = ballFlag;
            _bombFlag = bombFlag;
        }*/

        public void OnTrigger(GameObject triggerObject)
        {
            if (triggerObject.GetComponent<BallFlag>() != null) BallTrigger(triggerObject);

            if (triggerObject.GetComponent<BombFlag>() != null) BombTrigger(triggerObject);
        }

        private void BallTrigger(GameObject gameObject)
        {
            EventBus.onBallDetected?.Invoke(true, gameObject);
        }

        private void BombTrigger(GameObject gameObject)
        {
            EventBus.onBallDetected?.Invoke(false, gameObject);
        }
    }
}
