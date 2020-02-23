using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] gplatforms;

    [SerializeField]
    GameObject[] rplatforms;

    int numberofPlatformsg;
    int numberofPlatformsr;

    int toggle = 0; //0 for green, 1 for red, starts as green


    // Start is called before the first frame update
    void Start()
    {
        numberofPlatformsg = gplatforms.Length;
        numberofPlatformsr = rplatforms.Length;
        for (int i = 0; i < numberofPlatformsr; i++)
        {
            rplatforms[i].SetActive(false);
        }
    }

    void toggleplat()
    {
        if (toggle == 0)
        {
            for (int i = 0; i < numberofPlatformsg; i++)
            {
                gplatforms[i].SetActive(false);
                for (int j = 0; j < numberofPlatformsr; j++)
                {
                    rplatforms[j].SetActive(true);
                }
                toggle = 1;
            }
        }
        else
        {
            for (int i = 0; i < numberofPlatformsr; i++)
            {
                rplatforms[i].SetActive(false);
                for (int j = 0; j < numberofPlatformsg; j++)
                {
                    gplatforms[j].SetActive(true);
                }
                toggle = 0;
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            toggleplat();
        }
    }
}
