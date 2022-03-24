using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private float jumpForce = 5f;
    public float JumpForce
    {
        get { return jumpForce; }
        
        set { jumpForce = value; }

    }
   
    public bool groundedPlayer;
    private Rigidbody rb;
    

    private void Start()
    {
        groundedPlayer = true;
        rb = GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {  
        jump();
    }




    public virtual void jump()
    {
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            groundedPlayer = false;
            rb.AddForce(transform.position.x, jumpForce, transform.position.z, ForceMode.Impulse);
        }      

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            groundedPlayer = true;
            print("test");
        }

    }


}//class



