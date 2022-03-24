using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickJump : Animal//Inheritance
{   //Component
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        JumpForce = 2f; //Encapsulation 
        groundedPlayer = true;
        rb = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        jump();//Abstraction
    }

    public override void jump() //Polymorphism 
    {
        if (Input.GetButtonDown("Jump") && groundedPlayer || Input.GetKeyDown(KeyCode.Alpha1) && groundedPlayer)
        {
            groundedPlayer = false;
            rb.AddForce(transform.position.x, JumpForce, transform.position.z, ForceMode.Impulse);
        }

        base.jump();
    }



    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            groundedPlayer = true;
        }

    }


}//class
