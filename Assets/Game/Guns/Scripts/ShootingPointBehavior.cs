using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Guns.Scripts
{
    class ShootingPointBehavior : MonoBehaviour
    {
        [SerializeField]
        private GameObject _ballPrefab;
        [SerializeField]
        private GameObject _bombPrefab;

        [SerializeField]
        [Range(0, 1000)]private float _force;

        [SerializeField]
        private Transform _gunTransform;

        private ShootingSystem _shootingSystem;
        private GunRotateSystem _gunRotateSystem;

        public void Start()
        {
            _shootingSystem = new ShootingSystem(_ballPrefab, _bombPrefab, _force);
            _gunRotateSystem = new GunRotateSystem(_gunTransform);

            

            StartCoroutine(DelayForSpawn(3));
        }


        private IEnumerator DelayForSpawn(float time)
        {
            while (true)
            {
                yield return new WaitForSeconds(0.4f);
                _gunRotateSystem.Rotate();
                yield return new WaitForSeconds(0.7f);
                _shootingSystem.CreateShell(this.transform, _gunTransform.rotation, this);
                
            }
        }
    }
}
