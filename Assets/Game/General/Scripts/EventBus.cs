using System;
using UnityEngine;
namespace General.Scripts
{
    public static class EventBus
    {
        public static Action<bool, GameObject> onBallDetected;
    }
}
