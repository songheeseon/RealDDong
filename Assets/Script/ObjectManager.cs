using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject poopPrefab;
    public GameObject poop_redPrefab;
    public GameObject poop_yellowPrefab;

    GameObject[] poop;
    GameObject[] poop_red;
    GameObject[] poop_yellow;

    GameObject[] targetPool;
    void Awake()
    {
        poop = new GameObject[100];
        poop_red = new GameObject[100];
        poop_yellow = new GameObject[100];

        Generate();
    }

    void Generate()
    {
        //poop
        for(int index = 0; index < poop.Length; index++)
        {
            poop[index] = Instantiate(poopPrefab);
            poop[index].SetActive(false);
        }
           
        for (int index = 0; index < poop_red.Length; index++)
        {
            poop_red[index] = Instantiate(poop_redPrefab);
            poop_red[index].SetActive(false);
        }
            
        for (int index = 0; index < poop_yellow.Length; index++)
        {
            poop_yellow[index] = Instantiate(poop_yellowPrefab);
            poop_yellow[index].SetActive(false);
        }
            
    }

    public GameObject MakeObj(string type)
    {
       
        switch (type)
        {
            case "poop":
                targetPool = poop;
                break;

            case "poop_red":
                targetPool = poop_red;
                break;

            case "poop_yellow":
                targetPool = poop_yellow;
                break;
        }

        for (int index = 0; index < targetPool.Length; index++){
            if (!targetPool[index].activeSelf){
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }

        return null;

    }
}