using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    public Transform position1;
    public Transform position2;
    private bool fighting;
    private bool spawned;

    private void Start()
    {
        spawned = false;
        fighting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            fighting = false;
            if (fighting == false)
            {
                Destroy(GameObject.FindGameObjectWithTag("Wall1"));
                Destroy(GameObject.FindGameObjectWithTag("Wall2"));

                Debug.Log("gay");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if(spawned == true)
            {
                return;
            }

            Instantiate(wall1, position1.position, Quaternion.identity);
            Instantiate(wall2, position2.position, Quaternion.identity);

            spawned = true;
            fighting = true;
        }
    }
}
