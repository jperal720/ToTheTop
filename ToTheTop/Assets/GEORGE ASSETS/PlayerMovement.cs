using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 5f;
    public bool isGrounded = false;

    ///*
    //private Rigidbody2D rb;
    public float laddis;
    public LayerMask whatIsLadder;
    private float inputVertical;
    //*/
    public bool isClimbing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();

        Ladder();

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

    }


    void Jump()
    {
        if (Input.GetButtonDown("Jump") && (isGrounded == true || isClimbing == true))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
        }
      
    }

   ///*
    void Ladder()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, laddis, whatIsLadder);
        if (hitInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                isClimbing = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                isClimbing = false;
            }
        }

        if (isClimbing == true && hitInfo.collider != null)
        {
            Vector3 moveup = new Vector3(0f,Input.GetAxis("Vertical"), 0f);
            transform.position += moveup * Time.deltaTime * moveSpeed;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            
            inputVertical = Input.GetAxis("Vertical");
            //rb.velocity = new Vector2(rb.velocity.x, inputVertical * Time.deltaTime* moveSpeed);
            //rb.gravityScale = 0;
            
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
    //*/
}
