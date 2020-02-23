using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 5f;
    public bool isGrounded = false;
    public Animator animator;
    public bool keepPlaying;

    ///*
    //private Rigidbody2D rb;
    public float laddis;
    public LayerMask whatIsLadder;
    private float inputVertical;
    //*/
    public bool isClimbing = false;
    private bool right, left;
    private bool mouseclick = false;
    // Start is called before the first frame update
    void Start()
    {
        right = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseclick == false)
        {
            animator.SetFloat("Attack", 0.0f);
        }
        if (Input.GetMouseButtonUp(0))
        {
         animator.SetFloat("Attack", 1.0f);
            StartCoroutine(WaitForHalfASecond());
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("attacking");
            mouseclick = true;
        }


        Jump();
        
        Ladder();
        if (isClimbing) {
            animator.SetFloat("Climb Speed", 1.0f);
        }
        else
        {
            animator.SetFloat("Climb Speed", 0.0f);
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        if(movement.x < 0)
        {
            TurnLeft();
        }
        if (movement.x > 0)
        {
            TurnRight();
        }
        animator.SetFloat("Speed",Mathf.Abs(movement.x * Time.deltaTime * moveSpeed));
        transform.position += movement * Time.deltaTime * moveSpeed;
        
    }

    void TurnLeft()
    {   if (left) { 
            return;
                }
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        left = true;
        right = false;
    }

    void TurnRight()
    {
        if (right)
        {
            return;
        }
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        left = false;
        right = true;
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
    IEnumerator WaitForHalfASecond()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetFloat("Attack", 0.0f);
    }
}
