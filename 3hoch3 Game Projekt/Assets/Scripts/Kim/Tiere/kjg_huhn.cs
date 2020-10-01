using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_huhn : MonoBehaviour
{
    public GameObject sheep;
    public GameObject kuh;
    public GameObject schwein;
    private GameObject followObject;

    public float targetDistance;
    public float allowedDistance;
    public float fspeed;
    private float sec;

    public RaycastHit sheepDistance; //für die Distanz zu Sheep
    
    private bool up;
    private bool folgen;
    public static bool hasHuhn;
    public static bool huhnFirst;

    private void Start()
    {
        gameObject.SetActive(false);

        up = true;
       
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
        /*if (other.gameObject.name == "SheepWhite")
        {
            folgen = true;
            hasHuhn = true;
        }*/

        if (other.gameObject.name == "SheepWhite" )
        {
            if (!kjg_kuh.hasKuh && !kjg_schwein.hasSchwein)
            {
                huhnFirst = true;
                followObject = sheep;
            }
            if (!kjg_schwein.hasSchwein && kjg_kuh.kuhFirst)
            {
                huhnFirst = false;
                followObject = kuh;
            }
            if (!kjg_kuh.hasKuh && kjg_schwein.schweinFirst)
            {
                huhnFirst = false;
                followObject = schwein;
            }
            folgen = true;
            hasHuhn = true;
        }

    }
    
    // Update is called once per frame
    void Update()
    {
     
        // Damit Huhn dem Schaf folgt
        if (folgen)
        {
            transform.LookAt(followObject.transform);
            if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.forward), out sheepDistance))
            {
                targetDistance = sheepDistance.distance;
                if (targetDistance >= allowedDistance)
                {
                    fspeed = 0.3f;
                    transform.position = Vector3.MoveTowards(transform.position, followObject.transform.position + new Vector3(0,0.3f,0), fspeed);
                }
                else
                {
                    fspeed = 0;
                }
            }
            //Springen
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, sheep.transform.position.y, gameObject.transform.position.z);
        }

            sec = 0.5f;

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

        //Prüfen, ob man draußen war, damit die Tiere nicht noch einmal angezeigt werden
        if (kjg_sceneChanger.warDraussen)
        {
            gameObject.SetActive(false);
        }
    }
            
    
}


