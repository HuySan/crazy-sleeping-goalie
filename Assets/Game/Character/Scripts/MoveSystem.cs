using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Character
{
    class MoveSystem 
    {
        private Transform _characterTranform;
        private float _startPositionX;

        private bool isCapture;

        private Vector3 _mouseOffset;
        private float _mzCoord;


        public MoveSystem(Transform transform)
        {
            _characterTranform = transform;
            isCapture = false;
            _startPositionX = _characterTranform.position.x;
        }

        public void Сapture()
        {
            _mzCoord = Camera.main.WorldToScreenPoint(_characterTranform.position).z;

            _mouseOffset = _characterTranform.position - GetMouseWorldPosition();
            isCapture = true;
        }

        

        public void LetGo() => isCapture = false;


        public void Move()
        {
            if (isCapture)
            {
                _characterTranform.position = new Vector3(_startPositionX, Mathf.Clamp(GetMouseWorldPosition().y + _mouseOffset.y, 0.49f, 4.8f), Mathf.Clamp(GetMouseWorldPosition().z + _mouseOffset.z, 0, 10));
            }
        }

        private Vector3 GetMouseWorldPosition()
        {
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = _mzCoord;

            return Camera.main.ScreenToWorldPoint(mousePoint);
        }
    }
}
