using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public Transform target;
    public float radius;
    private bool check = false;
    public float enemydistance;

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
