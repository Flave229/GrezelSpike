using Assets.Scripts.InputScripts;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        private ControlMapping _controlMappings;
        private PhysicsComponent _physicsComponent;

        private float _defaultJumpCooldown = 1.0f;
        private float _jumpCooldown;

        void Start ()
        {
            _controlMappings = ControlMapping.Instance();
            _physicsComponent = new PhysicsComponent(75);
            _jumpCooldown = _defaultJumpCooldown;
        }

        void Update ()
        {
            var deltaTime = Time.deltaTime;
            _jumpCooldown -= deltaTime;
            if (_controlMappings.GetControlPressed(Control.MovePlayerLeft))
                transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
            if (_controlMappings.GetControlPressed(Control.MovePlayerRight))
                transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
            if (transform.position.y <= -0.2f && _controlMappings.GetControlPressed(Control.PlayerJump) && _jumpCooldown <= 0.0f)
            {
                _physicsComponent.AddForce(new Vector3(0.0f, 70000.0f, 0.0f));
                _jumpCooldown = _defaultJumpCooldown;
            }

            transform.position = _physicsComponent.CalculatePosition(transform.position, deltaTime);
        }
    }
}