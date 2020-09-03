using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TL_Dungeon : MonoBehaviour
{
    [Header("Bauteile:")]
    public GameObject startPart;
    public GameObject endPart;
    public GameObject[] dungeonParts;

    [Header("Anzahl der jeweiligen Bauteile:")]
    public int countStraightPart;
    public int countCurveLeft;
    public int countCurveRight;
    public int countObstacle1;
    public int countObstacle2;

    GameObject[] builtParts;

    //Anzahl der Bauteile
    int countParts;

    //Liste mit den Bauteilen
    List<string> partsList = new List<string>();

    //Anker, an dem das nachfolgende Bauteil angehängt wird
    Transform anker;

    //Zufallsnummer
    int randomNumber;

    void Start()
    {
        //Anzahl der Bauteile
        countParts = countStraightPart + countCurveLeft + countCurveRight + countObstacle1 + countObstacle2 + 2;

        //Array mit der jeweiligen Anzahl der Bauteile
        int[] numberParts = {countStraightPart, countCurveLeft, countCurveRight, countObstacle1, countObstacle2 };
        
        //Bauteile in die Liste eintragen
        for (int i = 0; i < numberParts.Length; i++)
        {
            for (int j = 0; j < numberParts[i]; j++)
            {
                if (i == 0)
                {
                    partsList.Add("StraightPart");
                }
                else if (i == 1)
                {
                    partsList.Add("CurveLeft");
                }
                else if (i == 2)
                {
                    partsList.Add("CurveRight");
                }
                else if (i == 3)
                {
                    partsList.Add("Obstacle1");
                }
                else if (i == 4)
                {
                    partsList.Add("Obstacle2");
                }
            }
        }

        print(partsList[6]);

        //Start Part einfügen
        builtParts = new GameObject[countParts];
        builtParts[0] = Instantiate(startPart, transform.position, transform.rotation);

        //Bauteile zwischen Start und End zufällig anordnen und einfügen
        for (int k = 1; k < countParts - 1; k++)
        {
            if (partsList.Count > 0)
            {
                randomNumber = Random.Range(0, partsList.Count - 1);
            }          
            print("Zufallsnummer: " + randomNumber);

            //Anker des zuletzt platzierten Parts
            anker = builtParts[k - 1].transform.GetChild(0);

            if (partsList[randomNumber] == "StraightPart")
            {
                builtParts[k] = Instantiate(dungeonParts[0], anker.position, anker.rotation);
            }
            else if (partsList[randomNumber] == "CurveLeft")
            {
                builtParts[k] = Instantiate(dungeonParts[1], anker.position, anker.rotation);
            }
            else if (partsList[randomNumber] == "CurveRight")
            {
                builtParts[k] = Instantiate(dungeonParts[2], anker.position, anker.rotation);
            }
            else if (partsList[randomNumber] == "Obstacle1")
            {
                builtParts[k] = Instantiate(dungeonParts[3], anker.position, anker.rotation);
            }
            else if (partsList[randomNumber] == "Obstacle2")
            {
                builtParts[k] = Instantiate(dungeonParts[4], anker.position, anker.rotation);
            }

            if (partsList.Count > 0)
            {
                partsList.RemoveAt(randomNumber);
            }            

            //builtParts[k] = Instantiate(dungeonParts[k - 1], anker.position, anker.rotation);
        }

        //End Part dranhängen
        anker = builtParts[builtParts.Length - 2].transform.GetChild(0);
        builtParts[builtParts.Length - 1] = Instantiate(endPart, anker.transform.position, anker.transform.rotation);
    }

}
