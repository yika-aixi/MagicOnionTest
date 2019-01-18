//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//2019年01月16日03:59:31
//

using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(SmoothMouseLook))]
    [RequireComponent(typeof(CharacterController))]
    public class MoveComponent : MonoBehaviour
    {
        public Vector3 CamOffset = new Vector3(0, 0, 15);

        //Variables
        public float speed = 6.0F;

        private void Awake()
        {
            transform.position = Vector3.zero;
            
            var cam = Camera.main;

            cam.transform.SetParent(transform);
            cam.transform.localPosition = Vector3.zero + CamOffset;

            _controller = GetComponent<CharacterController>();
        }

        public float jumpSpeed = 8.0F;
        public float gravity = 20.0F;
        private Vector3 moveDirection = Vector3.zero;
        private CharacterController _controller;
        private float turner;
        private float looker;
        public float sensitivity;
        void Update()
        {
            // is the controller on the ground?
            if (_controller.isGrounded)
            {
                //Feed moveDirection with input.
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                //Multiply it by speed.
                moveDirection *= speed;
                //Jumping
                if (Input.GetButton("Jump"))
                    moveDirection.y = jumpSpeed;
            }

            turner = Input.GetAxis("Mouse X") * sensitivity;
            looker = -Input.GetAxis("Mouse Y") * sensitivity;
            if (turner != 0)
            {
                //Code for action on mouse moving right
                transform.eulerAngles += new Vector3(0, turner, 0);
            }

            if (looker != 0)
            {
                //Code for action on mouse moving right
                transform.eulerAngles += new Vector3(looker, 0, 0);
            }

            //Applying gravity to the controller
            moveDirection.y -= gravity * Time.deltaTime;
            //Making the character move
            _controller.Move(moveDirection * Time.deltaTime);
        }
    }
}