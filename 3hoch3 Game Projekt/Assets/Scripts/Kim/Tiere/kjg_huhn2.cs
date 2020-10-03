using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_huhn2 : MonoBehaviour
{
    public GameObject ziel1;
    public GameObject ziel2;
    public GameObject ziel3;
    public GameObject ziel4;
    public GameObject ziel5;
    public GameObject ziel6;
    public GameObject ziel7;
    public GameObject ziel8;
    public GameObject sheep;


    public float targetDistance;
    public float allowedDistance;
    private float fspeed;
    public float speed;
    private float sec;
    private float zeit;
    private int zaehlerGO;

    public static bool hasHuhn;
    private bool up;

    public RaycastHit zielDistance; //für die Distanz zu Ziel

    
    private void Start()
    {
        up = true;
        gameObject.SetActive(false);
        zaehlerGO = 0;
    }
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
    //Das Huhn läuft die verschiedenen Ziele der Reihe nach ab und kommt somit selbst zum Ausgang, wo es auf das Schaf wartet
    void Update()
    {
        switch (zaehlerGO)
        {
            case 0:
                if (kjg_tuer.offen)
                {
                    hasHuhn = true;
                    Debug.Log("tür ist auf");
                    zaehlerGO = 1;
                }
                break;

            case 1:
                transform.LookAt(ziel1.transform);
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out zielDistance))
                {
                    targetDistance = zielDistance.distance;
                    if (targetDistance >= allowedDistance)
                    {
                        fspeed = speed;
                        transform.position = Vector3.MoveTowards(transform.position, ziel1.transform.position , fspeed);
                    }
                    else
                    {
                        fspeed = 0;
                    }
                }

                if (kjg_huhnZiel1.z1Erreicht)
                {
                    Debug.Log("Ziel 1 erreicht");
                   
                    zaehlerGO = 2;
                    kjg_huhnZiel1.z1Erreicht = false;
                }
                break;

            case 2:
                transform.LookAt(ziel2.transform);
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out zielDistance))
                {
                    targetDistance = zielDistance.distance;
                    if (targetDistance >= allowedDistance)
                    {
                        fspeed = speed;
                        transform.position = Vector3.MoveTowards(transform.position, ziel2.transform.position, fspeed);
                    }
                    else
                    {
                        fspeed = 0;
                    }
                }

                if (kjg_huhnZiel1.z1Erreicht)
                {
                    Debug.Log("Ziel 2 erreicht");

                    zaehlerGO = 3;
                    kjg_huhnZiel1.z1Erreicht = false;
                }
                break;

            case 3:
                transform.LookAt(ziel3.transform);
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out zielDistance))
                {
                    targetDistance = zielDistance.distance;
                    if (targetDistance >= allowedDistance)
                    {
                        fspeed = speed;
                        transform.position = Vector3.MoveTowards(transform.position, ziel3.transform.position , fspeed);
                    }
                    else
                    {
                        fspeed = 0;
                    }
                }

                if (kjg_huhnZiel1.z1Erreicht)
                {
                    Debug.Log("Ziel 3 erreicht");

                    zaehlerGO = 4;
                    kjg_huhnZiel1.z1Erreicht = false;
                }
                break;

            case 4:
                transform.LookAt(ziel4.transform);
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out zielDistance))
                {
                    targetDistance = zielDistance.distance;
                    if (targetDistance >= allowedDistance)
                    {
                        fspeed = speed;
                        transform.position = Vector3.MoveTowards(transform.position, ziel4.transform.position, fspeed);
                    }
                    else
                    {
                        fspeed = 0;
                    }
                }

                if (kjg_huhnZiel1.z1Erreicht)
                {
                    Debug.Log("Ziel 4 erreicht");

                    zaehlerGO = 5;
                    kjg_huhnZiel1.z1Erreicht = false;
                }
                break;

             case 5:
                transform.LookAt(ziel5.transform);
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out zielDistance))
                {
                    targetDistance = zielDistance.distance;
                    if (targetDistance >= allowedDistance)
                    {
                        fspeed = speed;
                        transform.position = Vector3.MoveTowards(transform.position, ziel5.transform.position, fspeed);
                    }
                    else
                    {
                        fspeed = 0;
                    }
                }

                if (kjg_huhnZiel1.z1Erreicht)
                {
                    Debug.Log("Ziel 5 erreicht");

                    zaehlerGO = 6;
                    kjg_huhnZiel1.z1Erreicht = false;
                }
                break;

             case 6:
                transform.LookAt(ziel6.transform);
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out zielDistance))
                {
                    targetDistance = zielDistance.distance;
                    if (targetDistance >= allowedDistance)
                    {
                        fspeed = speed;
                        transform.position = Vector3.MoveTowards(transform.position, ziel6.transform.position, fspeed);
                    }
                    else
                    {
                        fspeed = 0;
                    }
                }

                if (kjg_huhnZiel1.z1Erreicht)
                {
                    Debug.Log("Ziel 6 erreicht");

                    zaehlerGO = 7;
                    kjg_huhnZiel1.z1Erreicht = false;
                }
                break;

             case 7:
                transform.LookAt(ziel7.transform);
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out zielDistance))
                {
                    targetDistance = zielDistance.distance;
                    if (targetDistance >= allowedDistance)
                    {
                        fspeed = speed;
                        transform.position = Vector3.MoveTowards(transform.position, ziel7.transform.position, fspeed);
                    }
                    else
                    {
                        fspeed = 0;
                    }
                }

                if (kjg_huhnZiel1.z1Erreicht)
                {
                    Debug.Log("Ziel 7 erreicht");

                    zaehlerGO = 8;
                    kjg_huhnZiel1.z1Erreicht = false;
                }
                break;

             case 8:
                transform.LookAt(ziel8.transform);
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out zielDistance))
                {
                    targetDistance = zielDistance.distance;
                    if (targetDistance >= allowedDistance)
                    {
                        fspeed = speed;
                        transform.position = Vector3.MoveTowards(transform.position, ziel8.transform.position, fspeed);
                    }
                    else
                    {
                        fspeed = 0;
                    }
                }

                if (kjg_huhnZiel1.z1Erreicht)
                {
                    Debug.Log("Ziel 8 erreicht");
                    zaehlerGO = 9;
                    kjg_huhnZiel1.z1Erreicht = false;
                }
                break;
            case 9:
                zeit = Time.deltaTime;
                sec = 0.3f;
                //Hovering / Floating
                if (up)
                {
                    StartCoroutine(jumpUp(sec));
                }
                else
                {
                    StartCoroutine(jumpDown(sec));
                }

                if (zeit > 5) {
                    gameObject.SetActive(false);
                }
                break;
        }
    }
}
