using Assets.Scripts.InputScripts;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        private ControlMapping _controlMappings;

        void Start ()
        {
            _controlMappings = ControlMapping.Instance();
        }

        void Update ()
        {
            if (_controlMappings.GetControlPressed(Control.MovePlayerLeft))
                transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
            if (_controlMappings.GetControlPressed(Control.MovePlayerRight))
                transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
        }
    }
}
