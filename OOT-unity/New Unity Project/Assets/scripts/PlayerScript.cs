using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : Singleton<PlayerScript>
{
    public CharacterController controller;

    public bool canMove = true;
    public bool isRunning = false;
    public float walkSpeed = 1f;
    public float runSpeed = 3f;
    public float turnSpeed = 90f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        #region Movement

        if (canMove)
        {
            Vector3 movDir;
            float moveSpeed;

            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            {
                moveSpeed = runSpeed;
                isRunning = true;
            }
            else
            {
                moveSpeed = walkSpeed;
                isRunning = false;
            }

            //check if strafing before applying movement
            if (Input.GetKey(KeyCode.Z))
            {
                movDir = transform.right * -moveSpeed;
            }
            else if (Input.GetKey(KeyCode.C))
            {
                movDir = transform.right * moveSpeed;
            }
            else
            {
                //rotation and forward movement
                transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
                movDir = transform.forward * Input.GetAxis("Vertical") * moveSpeed;
            }
            // move the character
            controller.Move(movDir * Time.deltaTime - Vector3.up * 0.1f);
        }
        #endregion
    }
}