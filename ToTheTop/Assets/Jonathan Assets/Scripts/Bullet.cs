using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public float damage = 10f;

    private Transform player;
    Vector2 bulletDir;
    public bool ballAlive;
    float differenceX, differenceY;

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
            ballAlive = true;
            rb.velocity = VectorFromAngle(CalculateTheta(player)) * speed;
            Debug.Log(differenceX + " " + differenceY);
            Debug.Log("Angle: " + -1 * Mathf.Rad2Deg * Mathf.Atan(differenceY / differenceX));

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        ballAlive = false;
    }

    private float CalculateTheta(Transform playerPos)
    {
        //float differenceX, differenceY;

        if(transform.position.x < playerPos.position.x)
            differenceX = (playerPos.position.x - transform.position.x);

        else
            differenceX = (playerPos.position.x - transform.position.x);

        if(transform.position.y < playerPos.position.y)
            differenceY = (playerPos.position.y - transform.position.y);

        else
            differenceY = (player.position.y - transform.position.y);

        if(transform.position.x > playerPos.position.x)
        {
            return Mathf.Atan2(differenceY , differenceX);
        }
        
        return Mathf.Atan2(differenceY, differenceX);
    }

    private Vector2 VectorFromAngle(float theta)
    {

        return new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
    }

}
