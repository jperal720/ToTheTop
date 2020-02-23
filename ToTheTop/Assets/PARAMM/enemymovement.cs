using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour
{
    // Start is called before the first frame update

    float speed;
    public Transform target;
    float radius;
    private bool check = false;
    float enemydistance;
    public Animator animator;
    private bool right, left;
    private void Start()
    {
        speed = Random.Range(1f, 3.0f);
        radius = Random.Range(30.0f, 50.0f);
        enemydistance = 8f;
    }
    // Update is called once per frame
    void Update()
    {
        if (target.position.x - transform.position.x < 0)
        {
            TurnLeft();
        }
        if (target.position.x-transform.position.x > 0)
        {
            TurnRight();
        }



        if (Vector2.Distance(transform.position, target.position) < radius && check==false) {
            check = true;
        }

        if (Vector2.Distance(transform.position, target.position) > enemydistance && check==true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            animator.SetFloat("Speed", 1.0f);
        }
        else
        {
            animator.SetFloat("Speed", 0.0f);
        }
    }
    void TurnLeft()
    {
        if (left)
        {
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
}
