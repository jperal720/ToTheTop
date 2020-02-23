using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnBehaviour : MonoBehaviour
{


    public Transform player;
    //Vector2 bulletDir = VectorFromAngle(CalculateTheta(player));

    void Start()
    {
        //bulletDir = VectorFromAngle(CalculateTheta(player));
    }
    
    private float CalculateTheta(Transform playerPos)
    {
        float differenceX = transform.position.x - playerPos.position.x;
        float differenceY = transform.position.y - playerPos.position.y;

        Debug.Log(differenceX + " " + differenceY);
        return Mathf.Atan(differenceY/differenceX);
    }

    private Vector2 VectorFromAngle(float theta)
    {
        return new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
    }
    
}
