using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullets : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletSpawn;
    public float numberOfBullets;
    private bool advance;

    private void Start()
    {
        advance = true;
    }

    // Update is called once per frame
    public float Update()
    {
        //for now
        if (Input.GetKeyDown(KeyCode.X) && advance == true)
        {
            advance = false;
            for(numberOfBullets = 0; numberOfBullets < 8f; numberOfBullets++)
            {
                //nB();      
                Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                return numberOfBullets;
            }
            advance = true;
        }
        return numberOfBullets;
    }

    public float nB()
    {
        Debug.Log("This is the number of bullets: " + numberOfBullets);
        return numberOfBullets;
    }
}
