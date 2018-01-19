using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InputScripts
{
    public enum Control
    {
        MovePlayerRight,
        MovePlayerLeft,
        PlayerJump
    }

    public class ControlMapping
    {
        private static ControlMapping _instance;
        private static Dictionary<Control, string> _mappedControls;

        private ControlMapping()
        {
            _mappedControls = new Dictionary<Control, string>
            {
                { Control.MovePlayerLeft, "left" },
                { Control.MovePlayerRight, "right" },
                { Control.PlayerJump, "up" }
            };
        }

        public static ControlMapping Instance()
        {
            return _instance ?? (_instance = new ControlMapping());
        }

        public bool GetControlPressed(Control control)
        {
            string mappedKey = _mappedControls[control];

            if (Input.GetKey(mappedKey))
                return true;

            return false;
        }
    }
}
