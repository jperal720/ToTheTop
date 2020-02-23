using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletFunc : MonoBehaviour
{

    public float speed = 20;
    private Vector2 bulletDir;
    private float numOfBullets;
    private bool bulletAlive;

    public Rigidbody2D rb;

    //is called as soon as the object is enabled
    private void Start()
    {
        bulletAlive = false;
        numOfBullets = GameObject.Find("BulletSpawn").GetComponent<BossBullets>().Update();

        if (bulletAlive == false)
        {
            Debug.Log(numOfBullets);
            rb.velocity = VectorFromAngle(numOfBullets * 45f) * speed;


            bulletAlive = true;
        }
    }
    // Update is called once per frame
    void Update()
    {

        //make it so after a certain amount of time the bullets will destroy
    }

    private Vector2 VectorFromAngle(float theta)
    {
        return new Vector2 (Mathf.Sin(theta), Mathf.Cos(theta));
    }

}
