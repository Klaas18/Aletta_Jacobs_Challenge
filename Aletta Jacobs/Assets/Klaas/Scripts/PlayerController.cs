using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.5f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    public bool isUsingJoystick = true;
    
    [SerializeField] private FixedJoystick _joystick;



    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "npc")
        {
            other.GetComponent<NPC_Script>().canWave = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "npc")
        {
            other.GetComponent<NPC_Script>().canWave = false;
        }
    }

    void LateUpdate()
    {
        Vector3 move = new Vector3();
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        if (isUsingJoystick)
        {
            //Vooruit
            if (_joystick.Vertical > 0.1)
            {
                move = transform.TransformDirection(Vector3.forward);
                controller.Move(move * Time.deltaTime * playerSpeed);
            }
            //Lonks
            if (_joystick.Horizontal < -0.1)
            {
                move = transform.TransformDirection(Vector3.left);
                controller.Move(move * Time.deltaTime * playerSpeed);
            }
            //Achteruit
            if (_joystick.Vertical < -0.1)
            {
                move = transform.TransformDirection(Vector3.back);
                controller.Move(move * Time.deltaTime * playerSpeed);
            }
            //Rechts
            if (_joystick.Horizontal > 0.1)
            {
                move = transform.TransformDirection(Vector3.right);
                controller.Move(move * Time.deltaTime * playerSpeed);
            }
        }
        else
        {
            //Vooruit
            if (Input.GetKey(KeyCode.W))
            {
                move = transform.TransformDirection(Vector3.forward);
                controller.Move(move * Time.deltaTime * playerSpeed);
            }
            //Lonks
            if (Input.GetKey(KeyCode.A))
            {
                move = transform.TransformDirection(Vector3.left);
                controller.Move(move * Time.deltaTime * playerSpeed);
            }
            //Achteruit
            if (Input.GetKey(KeyCode.S))
            {
                move = transform.TransformDirection(Vector3.back);
                controller.Move(move * Time.deltaTime * playerSpeed);
            }
            //Rechts
            if (Input.GetKey(KeyCode.D))
            {
                move = transform.TransformDirection(Vector3.right);
                controller.Move(move * Time.deltaTime * playerSpeed);
            }
        }




        // if (move != Vector3.zero)
        // {
        //     gameObject.transform.forward = move;
        // }



        // Changes the height position of the player..
        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
