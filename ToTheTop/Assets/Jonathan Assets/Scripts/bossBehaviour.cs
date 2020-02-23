using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBehaviour : MonoBehaviour {

    public Transform[] target;
    public float speed;
    public bool spawnEnemyFunction = false;

    private int current;
	
	// Update is called once per frame
	void Update () {

		if((transform.position != target[current].position) && spawnEnemyFunction == false)
        {
            Vector2 pos = Vector2.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(pos);
        }
        else if((transform.position == target[current].position) && spawnEnemyFunction == false)
        {
            current = (current + 1) % target.Length;
        }
	}
}
