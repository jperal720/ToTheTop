using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conditionforshoot : MonoBehaviour
{
    float check;
    public Transform target;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        //shoot
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < radius)
        {
            check = Random.Range(0.0f, 50.0f);
            if (check >= 40)
            {
                //shoot
            }
        }
        
    }
}
