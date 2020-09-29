using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_kuh : MonoBehaviour
{
    public GameObject sheep;
    public float targetDistance;
    public float allowedDistance = 4;
    public float fspeed;
    public RaycastHit shot; //für die Distanz zu Sheep
    private bool folgen = false;
    public static bool hasKuh;
    public float jumpHeight = 1;
    bool up;

    private void Start()
    {
        up = true;
        if (kjg_sceneChanger.warDraussen) {
            gameObject.SetActive(false);
        }
    }
    //jumping Methoden
    IEnumerator jumpUp(float seconds)
    {
        this.transform.position += new Vector3(0, 1.5f * Time.deltaTime, 0);
        yield return new WaitForSeconds(seconds);
        up = false;
    }

    IEnumerator jumpDown(float seconds)
    {
        this.transform.position -= new Vector3(0, 1.5f * Time.deltaTime, 0);
        yield return new WaitForSeconds(seconds);
        up = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SheepWhite") {
            folgen = true;
            hasKuh = true;
        }
       
    }

    float sec;
   
    void Update()
    {
        //Damit Kuh dem Schaf folgt
        if (folgen) {
        
            transform.LookAt(sheep.transform);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
            {
                targetDistance = shot.distance;
                if (targetDistance >= allowedDistance)
                {
                    fspeed = 0.3f;
                    transform.position = Vector3.MoveTowards(transform.position, sheep.transform.position, fspeed);
                }
                else
                {
                    fspeed = 0;
                }
            }
            //Springen
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, sheep.transform.position.y, gameObject.transform.position.z);
        }

        sec = 0.6f;
        //Hovering / Floating
        if (!folgen && kjg_tuer.offen) {
            if (up)
            {
                StartCoroutine(jumpUp(sec));
            }
            else
            {
                StartCoroutine(jumpDown(sec));
            }
        }
    }
}
