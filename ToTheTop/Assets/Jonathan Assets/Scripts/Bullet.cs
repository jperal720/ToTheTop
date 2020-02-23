using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20;
    public Rigidbody2D rb;

    public Transform player;
    Vector2 bulletDir;
    private bool ballAlive;

    //public Transform player;
    //public Transform bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = transform.right * speed;
        ballAlive = false;
    }

    private void Update()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();

        if(ballAlive == false)
        {
            rb.velocity = VectorFromAngle(CalculateTheta(player)) * speed;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        ballAlive = false;
    }

    private float CalculateTheta(Transform playerPos)
    {
        float differenceX = transform.position.x - playerPos.position.x;
        float differenceY = transform.position.y - playerPos.position.y;

        Debug.Log(differenceX + " " + differenceY);
        return Mathf.Atan(differenceY / differenceX);
    }

    private Vector2 VectorFromAngle(float theta)
    {
        return new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
    }

}
