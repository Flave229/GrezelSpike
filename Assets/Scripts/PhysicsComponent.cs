using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

namespace Assets.Scripts
{
    public class PhysicsComponent
    {
        private Vector3 _velocity;
        private Vector3 _acceleration;
        private List<Vector3> _forces;
        private readonly float _mass;

        public PhysicsComponent(float mass)
        {
            _mass = mass;
            _forces = new List<Vector3>();
        }

        public Vector3 CalculatePosition(Vector3 position, float deltaTime)
        {
            _forces.Add(new Vector3(0.0f, _mass * -9.81f, 0.0f));

            if (position.y <= -2.0f)
            {
                _forces.Add(new Vector3(0.0f, _mass * 9.81f, 0.0f));
                CollideWithFloor();
            }

            Vector3 netForce = CalculateNetForce();
            _acceleration = netForce / _mass;

            _velocity += _acceleration * deltaTime;
            position += _velocity * deltaTime + _acceleration * deltaTime * deltaTime * 0.5f;

            _forces = new List<Vector3>();
            return position;
        }

        private Vector3 CalculateNetForce()
        {
            var netForce = new Vector3(0, 0, 0);
            foreach (var force in _forces)
            {
                netForce += force;
            }
            return netForce;
        }

        public void AddForce(Vector3 force)
        {
            _forces.Add(force);
            Debug.Log(force);
        }

        private void CollideWithFloor()
        {
            _velocity.y *= -0.3f;
        }
    }
}
