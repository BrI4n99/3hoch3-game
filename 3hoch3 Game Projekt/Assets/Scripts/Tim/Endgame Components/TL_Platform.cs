using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TL_Platform : MonoBehaviour
{
    bool right;

    private GameObject player;

    private Transform startPositionPlatform;

    private float xValue1;
    private float xValue2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Platform Object")
        {
            return;
        }

        if (other.gameObject.name == "Player")
        {
            print("Player entered Platform");
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Platform Object")
        {
            return;
        }

        if (other.gameObject.name == "Player")
        {
            print("Player left Platform");
            player.transform.parent = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        startPositionPlatform = gameObject.transform;

        xValue1 = startPositionPlatform.position.x + 2;
        xValue2 = startPositionPlatform.position.x - 2;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (transform.position.x > xValue1)
        {
            right = false;
        }
        if (transform.position.x < xValue2)
        {
            right = true;
        }
        if (right)
        {
            transform.position += new Vector3(0.03f, 0, 0);
        }
        else
        {
            transform.position += new Vector3(-0.03f, 0, 0);
        }
    }
}
