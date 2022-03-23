using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private float jumpForce = 2f;
    public float JumpForce
    {
        get { return jumpForce; }
        
        set { jumpForce = value; }

    }
   
    public bool groundedPlayer;

    public Vector3 playerVelocity;
    private Rigidbody rb;
    

    private void Start()
    {        
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {  
        jump();
    }




    public virtual void jump()
    {
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            rb.AddForce(transform.position.x, JumpForce, transform.position.z, ForceMode.Impulse);
        }      

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            groundedPlayer = true;
            print("Test");
        }

    }


}//class



