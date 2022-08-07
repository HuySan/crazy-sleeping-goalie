using System;
using UnityEngine;

namespace Guns.Scripts
{
    class ShootingSystem
    {
        private float _force;
        private GameObject _prefab;
       // private Vector3 _shootingPoint;
        public ShootingSystem(GameObject prefab, float force)
        {
            _prefab = prefab;
            _force = force;
        }

        public void CreateBall(Transform transform, Quaternion gunRotation)
        {
            GameObject createObject = GameObject.Instantiate(_prefab, transform.position, gunRotation);
            Shoot(createObject, transform);
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
