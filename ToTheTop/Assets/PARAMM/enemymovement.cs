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

    private void Start()
    {
        speed = Random.Range(2f, 6.0f);
        radius = Random.Range(30.0f, 50.0f);
        enemydistance = 5f;
    }
    // Update is called once per frame
    void Update()
    {   if (Vector2.Distance(transform.position, target.position) < radius && check==false) {
            check = true;
        }

        if (Vector2.Distance(transform.position, target.position) > enemydistance && check==true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }
}
