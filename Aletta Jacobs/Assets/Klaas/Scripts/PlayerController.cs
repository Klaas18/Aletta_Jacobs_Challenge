using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private float _rotationSpeed = 100;
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {

        Vector3 NextDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        //if (NextDir != Vector3.zero)
        //    transform.rotation = Quaternion.LookRotation(NextDir);
        //controller.Move(NextDir / 8);

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));//Input.GetAxis("Horizontal")
        controller.Move(move * Time.deltaTime * playerSpeed);

        Vector3 rotation = new Vector3(0, Input.GetAxis("Horizontal") * _rotationSpeed * Time.deltaTime, 0);
        gameObject.transform.rotation = Quaternion.LookRotation(NextDir);
       // gameObject.transform.Rotate(rotation);


        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
