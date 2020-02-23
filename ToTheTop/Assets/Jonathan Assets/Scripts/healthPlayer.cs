using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class healthPlayer : MonoBehaviour
{

    [SerializeField] private float hp;

    private float enemyDamage;
    //private GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        hp = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        enemyDamage = GameObject.FindGameObjectWithTag("Bullet").GetComponent<Bullet>().damage;

        ifRegen();

        if(hp <= 0)
        {
            SceneManager.LoadScene("Jonathan");
        }
    }

    public void ifRegen()
    {
        //if player picks up player regen then give him 100f hp
    }

    public void damagePlayer()
    {
        hp -= enemyDamage;
        Debug.Log(hp);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            damagePlayer();
        }
    }

}
