using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DorbermanJump : Animal
{

    
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // groundedPlayer = m_Controller.isGrounded;

       //jump();
    }

   
}//class



