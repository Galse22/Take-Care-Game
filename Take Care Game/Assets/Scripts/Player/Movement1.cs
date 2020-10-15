using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    public bool isGrounded;
    
    public Transform groundCheck;
    public float checkRadius;

    public LayerMask whatIsGround;

    // coyote jump
    private float gRemember;
    public float gRememberT;

    // jump value
    public int eJumps;
    public int eJumpsV;

    // shooting


    void Start()
    {
        eJumps = eJumpsV;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) && eJumps == 0 && (gRemember > 0)) 
        {
            rb.velocity = Vector2.up * jumpForce;
            eJumps--;
            gRemember = 0;
        }

    }

    void FixedUpdate()
    {

        if(isGrounded == true)
        {
            eJumps = eJumpsV;
            gRemember = gRememberT;
        }
        gRemember -=Time.deltaTime;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // going right but facing left 
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }

        // going left but facing right
        if(facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    // changes the z value ( I think)
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
