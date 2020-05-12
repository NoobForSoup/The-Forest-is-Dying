using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float sensitivity = 3.4f;
    public float movementSpeed = 4f;
    public float jumpHeight = 3f;

    public Camera camera;
    private CharacterController cc;

    private float yRotation = 0f;

    private float gravity = -9.81f;
    private Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundLayer;

    private bool isGrounded;

    public bool respawn = false;
    private float respawnCooldown = 0.2f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        InputHandling();
    }

    private void InputHandling()
    {
        if (respawn)
        {
            transform.position = FindObjectOfType<Killzone>().checkpoint;

            respawnCooldown -= Time.deltaTime;

            if(respawnCooldown <= 0f)
            {
                respawn = false;
                respawnCooldown = 0.2f;
            }
        }
        else
        {
            //groundcheck
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            //rotation
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * 50f * Time.deltaTime;
            float mouseY = Mathf.Clamp(Input.GetAxis("Mouse Y") * sensitivity * 50f * Time.deltaTime, -90f, 90f);

            yRotation -= mouseY;
            yRotation = Mathf.Clamp(yRotation, -90f, 90f);

            transform.Rotate(Vector3.up * mouseX);
            camera.transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);

            //movement
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            Vector3 move = transform.right * horizontal + transform.forward * vertical;

            cc.Move(move * movementSpeed * Time.deltaTime);

            //jump

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            //gravity
            velocity.y += gravity * Time.deltaTime;

            cc.Move(velocity * Time.deltaTime);
        }
    }
}
