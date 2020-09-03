using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TL_Obstacle1_Logic : MonoBehaviour
{
    public GameObject platform;
    public GameObject waterplane;

    bool lowerGroundState;
    bool riseWaterState;

    float movementTime= 2.5f;
    float lerpValue = 0;
    Vector3 endValue;
    Vector3 startValue;

    //Object der Klasse TL_Obstacle1
    TL_Obstacle1 obstacle1;

    void Start()
    {
        lowerGroundState = false;
        riseWaterState = false;

        startValue = waterplane.transform.position;
        endValue = waterplane.transform.position + new Vector3(0, 5, 0);

        //Instanz der Klasse tl_ObjectPooler erzeugen, um auf deren Funktion zugreifen zu können
        obstacle1 = TL_Obstacle1.Instance;

        StartCoroutine("CompleteObstacle");
    }

    // Update is called once per frame
    void Update()
    {
        //Boden senken
        if (lowerGroundState)
        {
            obstacle1.LowerObstacleGround();
        }

        //Wasser anheben
        if (riseWaterState)
        {
            if (lerpValue < 1)
            {
                lerpValue += Time.deltaTime / movementTime;
                waterplane.transform.position = Vector3.Lerp(startValue, endValue, lerpValue);
            }
            else
            {
                waterplane.transform.position = endValue;
            }
        }
    }

    private IEnumerator CompleteObstacle()
    {
        yield return new WaitForSeconds(1);
        print("Lower Ground");
        lowerGroundState = true;

        yield return new WaitForSeconds(3);
        print("rise Water");
        riseWaterState = true;

        yield return new WaitForSeconds(3);
        platform.SetActive(true);

        yield return new WaitForSeconds(1);
        Instantiate(platform, transform.position + new Vector3(0, 0, 16.5f), platform.transform.rotation).name = "Platform";

        yield return new WaitForSeconds(1.5f);
        Instantiate(platform, transform.position + new Vector3(0, 0, 19.75f), platform.transform.rotation).name = "Platform";

        yield return new WaitForSeconds(1.2f);
        Instantiate(platform, transform.position + new Vector3(0, 0, 23), platform.transform.rotation).name = "Platform";
    }
}
