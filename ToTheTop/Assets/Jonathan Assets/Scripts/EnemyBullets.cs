using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour {

    public GameObject bullet;
    public Transform bulletSpawn;
    //public Transform player;

    private void Update()
    {
        if (GetComponent<Bullet>().ballAlive == true) { return; }
        Shoot();
    }

    void Shoot()
    {
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        //shoot
    }
}
