using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    float mx;
    public Transform feet;
    public Transform side1;
    public Transform side2;
    public float jumpForce;
    public LayerMask groundLayers;//Return layer on which player stands
    public GameObject player;
    public Animator anim;
    public int ExtraJumps = 1;
    public int currentJumps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Horizontal input
        mx = Input.GetAxisRaw("Horizontal");
        //Reset jumps ones player hits the ground
        if(IsGrounded())
        {
            currentJumps = 0;
        }
        //Jumping
        if (Input.GetButtonDown("Jump") && currentJumps < ExtraJumps)//Dont let player jump unless his on the ground
        {
            currentJumps += 1;
            Jump();
        }

        //ANIMATIONS
        //Turn on Running animation if moving
        //Absolute always returns you positive value
        if(Mathf.Abs(mx) > 0.05f)
        {
            anim.SetBool("IsRunning", true);
        } else
        {
            anim.SetBool("IsRunning", false);
        }

        //Make player turn different sides
        if (mx > 0f)
        {
            transform.localScale = new Vector3(4f, 4f, 4f);
        }
        else if(mx < 0f)
        {
            transform.localScale = new Vector3(-4f, 4f, 4f);
        }

        //Change into jumping animation
        anim.SetBool("IsGrounded", IsGrounded());//Make function return whether his grounded or not
    }



    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

        rb.velocity = movement;
    }

    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        
        rb.velocity = movement;
    }

    //Check for collision with ground
    public bool IsGrounded ()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null)//Return true if player on the ground
        {
            return true;
        }

        return false;
    }

}
