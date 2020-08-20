using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TL_Dungeon : MonoBehaviour
{
    public GameObject startPart;
    public GameObject endPart;
    public GameObject[] dungeonParts;

    GameObject[] builtParts;

    void Start()
    {


        builtParts = new GameObject[dungeonParts.Length + 1];
        builtParts[0] = Instantiate(startPart, transform.position, transform.rotation);

        for (int i = 1; i < dungeonParts.Length + 1; i++)
        {
            Transform anker = builtParts[i - 1].transform.GetChild(0);
            builtParts[i] = Instantiate(dungeonParts[i - 1], anker.position, anker.rotation);
        }

    }

}
