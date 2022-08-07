using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
namespace Guns.Scripts
{
    class GunRotateSystem
    {
        private float _timeForRotate = 2;
        private Transform _objectTransform;
        private Transform _rotateTemp;

        public GunRotateSystem(Transform objectTransform)
        {
            _objectTransform = objectTransform;
            _rotateTemp = _objectTransform;
            
        }

        public void Rotate()
        {
            _objectTransform.eulerAngles = new Vector3(0, UnityEngine.Random.Range(-20, 20), -20);
        }
                
    }
}
