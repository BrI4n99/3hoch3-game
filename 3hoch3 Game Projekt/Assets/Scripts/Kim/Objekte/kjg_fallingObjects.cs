using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Objekte sollen random im Labyrinth von der Decke fallen, Schaf muss denen ausweichen
public class kjg_fallingObjects : MonoBehaviour
{
    public GameObject bucket;
    public GameObject boden;
    float zeit;
    float randomStelleX;
    float randomStelleZ;

    // Update is called once per frame
    void Update()
    {
        zeit += Time.deltaTime;

        if(zeit > 10)
        {
            for (int i = 0; i < 6; i++)
            {
                randomStelleX = Random.Range(0, 49);
                randomStelleZ = Random.Range(0, 49);
                Instantiate(bucket, new Vector3(randomStelleX, 6, randomStelleZ), Quaternion.identity);
                //Audio
                GetComponent<AudioSource>().Play();
            }
            zeit = 0;
        }        
        
    }
}
