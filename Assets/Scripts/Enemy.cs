using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : MonoBehaviour
    {
        public float Speed;
        private Player _player;
        private PhysicsComponent _physicsComponent;

        public void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            _physicsComponent = new PhysicsComponent(75);
        }

        public void Update()
        {
            var deltaTime = Time.deltaTime;
            float movement = Vector3.Normalize(_player.transform.position - transform.position).x * Speed * deltaTime; 
            transform.position = new Vector3(transform.position.x + movement, transform.position.y, transform.position.z);

            transform.position = _physicsComponent.CalculatePosition(transform.position, deltaTime);
        }
    }
}