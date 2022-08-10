using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General.Scripts;

namespace Guns.Scripts
{
    class ShootingSystem
    {
        private float _force;
        private GameObject _ballPrefab;
        private GameObject _bombPrefab;


        private bool _bombTime;
        public ShootingSystem(GameObject ball, GameObject bomb, float force)
        {
            _ballPrefab = ball;
            _bombPrefab = bomb;
            _force = force;
            _bombTime = true;
        }

        public void CreateShell(Transform transform, Quaternion gunRotation, MonoBehaviour mono)
        {
            Creator(_ballPrefab, transform, gunRotation);

            if (!_bombTime)
                return;
            int timeForBomb = UnityEngine.Random.Range(5, 10);
            mono.StartCoroutine(TimeForBomb(timeForBomb, transform, gunRotation));
        }

        IEnumerator TimeForBomb(int time, Transform transform, Quaternion gunRotation)
        {
            _bombTime = false;
            yield return new WaitForSeconds(time);

            _bombTime = true;
            Creator(_bombPrefab, transform, gunRotation);
        }



        private void Creator(GameObject _prefab, Transform transform, Quaternion gunRotation)
        {
            GameObject createObject = GameObject.Instantiate(_prefab, transform.position, gunRotation);
            Shoot(createObject, transform);

            if (createObject == null)
                return;

            GameObject.Destroy(createObject, 5);
        }

        public void Shoot(GameObject prefab, Transform pivot)
        {
            Rigidbody rigidbody = prefab.GetComponent<Rigidbody>();
            if (rigidbody == null)
                return;
            rigidbody.AddForce(-pivot.transform.right * _force, ForceMode.Impulse);
        }

    }
}
