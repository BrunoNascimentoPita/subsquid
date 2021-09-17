using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float inputX;
    private float speedX = 3.0f;
    private float jumpInitialSpeed = 6f;
    private float gravityScale = 1;


    private bool jump;
    private bool isGrounded;


    private bool bottomRightRayHit;
    private bool bottomLeftRayHit;

    private Vector3 oringinBottomRightRay;
    private Vector3 oringinBottomLeftRay;


    private Rigidbody2D rigidbody2d;  


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Checkgrounded();
        Gravity();


        inputX = Input.GetAxis("Horizontal");
        jump = Input.GetButton("Jump");

        transform.Translate(speedX * inputX * Time.deltaTime, 0, 0);

        CheckJump();


       



    }
     void Checkgrounded()
    {
        oringinBottomRightRay = transform.position + new Vector3(0.5f, -0.4f, 0);
        oringinBottomLeftRay = transform.position + new Vector3(-0.5f, -0.4f, 0);
        bottomRightRayHit = Physics2D.Raycast(oringinBottomRightRay, Vector3.down, 0.15f);
        bottomLeftRayHit = Physics2D.Raycast(oringinBottomLeftRay, Vector3.down, -0.6f);


        if (bottomRightRayHit || bottomLeftRayHit)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }

    void CheckJump()
    {
        if (jump && isGrounded)
        {
            rigidbody2d.velocity = new Vector3(rigidbody2d.velocity.x, jumpInitialSpeed, 0);
        }
        if (jump && (rigidbody2d.velocity.y > 0))
        {
            gravityScale = 1.4f;

        }
        if (rigidbody2d.velocity.y <= 0)
        {
            gravityScale = 2.5f;
        }
    }

    void Gravity()
    {
        rigidbody2d.velocity =   new Vector3(0f, gravityScale * -9.81f * Time.deltaTime, 0f);
    }




      





        
        
   }

