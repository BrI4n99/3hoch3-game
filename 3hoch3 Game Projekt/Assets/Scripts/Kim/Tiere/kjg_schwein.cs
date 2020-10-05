using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_schwein : MonoBehaviour
{
    public GameObject sheep;
    public GameObject huhn;
    public GameObject kuh;
    private GameObject followObject;

    public float targetDistance;
    public float allowedDistance = 4;
    public float fspeed;
    private float sec;

    public RaycastHit distanceTier; //für die Distanz zu Sheep

    private bool up;
    public static bool folgen;
    public static bool hasSchwein;
    public static bool schweinFirst;

    private int countPlay;
    private void Start()
    {
        countPlay = 0;
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
        if ((other.gameObject.name == "SheepWhite" && !kjg_kuh.hasKuh) || (other.gameObject.name == "SheepWhite" && kjg_tiereVorTuer.kuhVorTuer))
        {
            countPlay++;
            folgen = true;
            hasSchwein = true;
            if (countPlay == 1) {
                GetComponent<AudioSource>().Play();
            }
            Debug.Log("Schwein folgt Schaf");
        }
        else if (other.gameObject.name == "SheepWhite" && kjg_kuh.hasKuh) {
            folgen = false;
            //hasSchwein = true;
            //followObject = kuh;
            //Debug.Log("Schwein folgt Kuh");
        }
       
    }

    void Update()
    {
        //Damit Tier dem Schaf folgt
        if (folgen)
        {
            transform.LookAt(sheep.transform);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out distanceTier))
            {
                targetDistance = distanceTier.distance;
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
        if (!folgen && kjg_tuer.offen)
        {
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


