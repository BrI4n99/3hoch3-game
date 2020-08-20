using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TL_StrawBaleSpawner : MonoBehaviour
{
    //Object Pooler
    tl_ObjectPooler objectPooler;

    public GameObject spawnpoint;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    private bool triggerEntered;
    private bool spawnStarted;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            print("Obstacle 2 entered");
            triggerEntered = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Instanz der Klasse tl_ObjectPooler erzeugen, um auf deren Funktion zugreifen zu können
        objectPooler = tl_ObjectPooler.Instance;
    }

    void Update()
    {
        if (triggerEntered && !spawnStarted)
        {
            InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
            spawnStarted = true;
        }
    }

    public void SpawnObject()
    {       
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
        else
        {
            Vector3 rndPos = new Vector3(0, 0, Random.Range(-2.0f, 2.0f));
            GameObject strawBale = objectPooler.SpawnFromPool("StrawBale", spawnpoint.transform.position + rndPos, spawnpoint.transform.rotation);
        }    
    }
}
