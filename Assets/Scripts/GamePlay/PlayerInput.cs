using UnityEngine;
using UnityEngine.InputSystem;

namespace Objects
{
    public class PlayerInput : MonoBehaviour
    {
        private Player player;
        private Vector2 moveInput;
        private Vector2 lookInput;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
         player= GetComponent<Player>();
        }

        public void OnMove(InputValue value)
        {
            moveInput = value.Get<Vector2>();
        }

        public void OnLook(InputValue value)
        {
            lookInput= value.Get<Vector2>();
        }

        public void OnShoot(InputValue value)
        {
            if (value.isPressed)
            {
                player.Shoot();
            }
        }

        public void OnJump(InputValue value)
        {
            if (value.isPressed)
            {
                player.Nuke();
            }
        }

        private void FixedUpdate()
        {
            player.Move(moveInput, lookInput);
        }
    }
}
