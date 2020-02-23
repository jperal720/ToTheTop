using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHealthMechanics : MonoBehaviour {

    private float hp;
    public Transform spawnPoint;
    public GameObject enemySpawn;
    public GameObject Boss;
    public GameObject player;

    //call amount of damage the player will be able to do

	// Use this for initialization
	void Start () {
        hp = 100;
	}
	
	// Update is called once per frame
	void Update () {
        takeDamage();
        spawnEnemy();
	}

    public void takeDamage() {
        //if player hits the boss then return true then subtract from hp
    }

    public bool enoughDamage() {

        return false;
    }

    public void spawnEnemy() {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Boss.GetComponent<bossBehaviour>().spawnEnemyFunction = true;

        }
        //for now I will be testing by just pressing x and e; final game make it so it depends on health
        //((hp <= 75 && hp >= 50) || (hp <= 50 && hp >= 25) || (hp <= 25 && hp > 0)) && enoughDamage()
        if (Boss.GetComponent<bossBehaviour>().spawnEnemyFunction == true) {
            if (transform.position != spawnPoint.position)
            {

                Vector2 pos = Vector2.MoveTowards(transform.position, spawnPoint.position, Boss.GetComponent<bossBehaviour>().speed * Time.deltaTime);
                GetComponent<Rigidbody2D>().MovePosition(pos);
            }
                    
            //once the boss has reached the spawnPoint
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    //spawn enemies; wait a couple of seconds per enemy then go back to regular path
                    Instantiate(enemySpawn, spawnPoint.transform.position, Quaternion.identity);
                    
                }
                Boss.GetComponent<bossBehaviour>().spawnEnemyFunction = false;
            }
        }

        //yield return new WaitForSeconds(0f);
    }
}
