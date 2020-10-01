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
    private float zValue1;
    private float zValue2;

    private Transform part;
    private float partRotation;

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

        zValue1 = startPositionPlatform.position.z + 2;
        zValue2 = startPositionPlatform.position.z - 2;

        part = GameObject.Find("Obstacle1").transform;
        partRotation = part.transform.localEulerAngles.y;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (partRotation == 0 || partRotation == 180 || partRotation == -180 || partRotation == 360 || partRotation == -360)
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
                //transform.Translate(transform.parent.transform.forward * 1 * Time.deltaTime);
                transform.position += new Vector3(0.03f, 0, 0);
            }
            else
            {
                //transform.Translate(-transform.parent.transform.forward * 1 * Time.deltaTime);
                transform.position += new Vector3(-0.03f, 0, 0);
            }
        }
        else
        {
            if (transform.position.z > zValue1)
            {
                right = false;
            }
            if (transform.position.z < zValue2)
            {
                right = true;
            }
            if (right)
            {
                //transform.Translate(transform.parent.transform.forward * 1 * Time.deltaTime);
                transform.position += new Vector3(0, 0, 0.03f);
            }
            else
            {
                //transform.Translate(-transform.parent.transform.forward * 1 * Time.deltaTime);
                transform.position += new Vector3(0, 0, -0.03f);
            }
        }
    }
}
