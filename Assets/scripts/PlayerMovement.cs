using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;
using UnityEngine.UIElements;
//jump not working

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform gunpoint;
    [SerializeField] CharacterController characterController;
    private float initialHeight;
    public Transform capsuleHeight;
    private float horizontalInput, verticalInput;
    private float speed = 8;
    public float walkSpeed;
    public float SprintSpeed;
    [SerializeField] Transform Camera;
    public float jumpHeight = 2.0f;       // Jump height in units.
    public float gravity = 9.81f;
    private MovementState state;
    public enum MovementState
    {
        Walking,
        Sprinting,
        Air
    }
    private void Start()
    {
        initialHeight = characterController.height;
       
    }
    private void Update()
    {
        PlayerMove();
        speedHandeling();
        crouch();
        jump();

    }
    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
          

        }
    }
    private void speedHandeling()
    {
        if (Input.GetKey(KeyCode.LeftShift) && characterController.isGrounded)
        {
            state = MovementState.Sprinting;
            speed = SprintSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftControl) && characterController.isGrounded)
        {
            state = MovementState.Walking;

            speed = walkSpeed;

        }
        else
        {
            state = MovementState.Air;
            speed = 12;
        }
    }
    private void crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            characterController.height = initialHeight * 0.65f;
            capsuleHeight.localScale = new Vector3(1, 0.65f, 1);
        }
        else
        {
            characterController.height = characterController.height = initialHeight;
            capsuleHeight.localScale = new Vector3(1, 1, 1);
        }
    }
    private void PlayerMove()
    {
        //gravity
        Vector3 priv = new Vector3(characterController.velocity.x, -9.8f, characterController.velocity.z);
        characterController.Move(priv * Time.deltaTime);

        transform.rotation = Quaternion.LookRotation(Camera.forward, Camera.up);
        horizontalInput = Input.GetAxis(axisName: "Horizontal");
        verticalInput = Input.GetAxis(axisName: "Vertical");
        Vector3 MoveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 lookMove = transform.TransformDirection(MoveDirection);
        lookMove.y = 0f;
        characterController.Move(lookMove * speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);


    }
}