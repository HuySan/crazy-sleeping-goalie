using System;
using UnityEngine;

namespace Border
{
    class BorderSystem
    {
        private Vector3 _pushDirection;
        public BorderSystem(Vector3 pushDirection)
        {
            _pushDirection = pushDirection;
        }

        //Когда объект прикасается к границе отталкиваем его в противоположном направлении с помощью adForce
        public void Push(GameObject gameObject)
        {
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
            if (!rigidbody)
                return;
            rigidbody.AddForce(_pushDirection * 400, ForceMode.Impulse);
        }
    }
}
