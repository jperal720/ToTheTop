using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthMechanics : MonoBehaviour
{

    float hp;
    private float playerDamage;

    // Start is called before the first frame update
    void Start()
    {
        hp = 100f;
        //playerDamage = GetComponent<>().;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void onDamage()
    {
        //when player slashes enemy
        hp -= playerDamage;
    }
}
