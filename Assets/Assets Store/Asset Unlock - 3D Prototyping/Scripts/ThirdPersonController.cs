using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    //Components
    public Camera GameCamera;    
    private CharacterController m_Controller;
    private Animator m_Animator;
    
    //Vector3
    private Vector3 playerVelocity;

    //Floats
    public float playerSpeed = 2.0f;    
    private float gravityValue = -9.81f;    
    private float JumpForce = 1.0f;

    //Bool
    private bool groundedPlayer;


    private void Start()
    {
        m_Controller = gameObject.GetComponent<CharacterController>();
        m_Animator = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        GroundPlayer(); //Abstraction
        MovePlayer(); //Abstraction
        jump(); //Abstraction


    }


    private void jump()
    {
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(JumpForce * -3.0f * gravityValue);
            m_Animator.SetTrigger("Jump");
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
    }

    private void GroundPlayer()
    {
        groundedPlayer = m_Controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -0.5f;
        }

    }

    private void MovePlayer()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //trasnform input into camera space
        var forward = GameCamera.transform.forward;
        forward.y = 0;
        forward.Normalize();
        var right = Vector3.Cross(Vector3.up, forward);

        Vector3 move = forward * input.z + right * input.x;
        move.y = 0;

        m_Controller.Move(move * Time.deltaTime * playerSpeed);

        m_Animator.SetFloat("MovementX", input.x);
        m_Animator.SetFloat("MovementZ", input.z);

        if (input != Vector3.zero)
        {
            gameObject.transform.forward = forward;
        }

        m_Controller.Move(playerVelocity * Time.deltaTime);
    }


}//class
