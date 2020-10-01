using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_skybox : MonoBehaviour
{

    public float rot = 90;
  

    public Material morning;
    public Material night;
    bool nacht = true;
    float i;
    public GameObject player;
    public GameObject ground; 
    public GameObject barn;
    public GameObject landscape;
    public GameObject start;
    public GameObject endAll;
    public float angleRot = 3.5f;


    private bool rotationStart;

    // Start is called before the first frame update


    void Start()
    {
        StartCoroutine(nightToDay());
       // RenderSettings.skybox = morning;
        // RenderSettings.skybox = night;

    }
    void Update()
    {
        
       
        rot %= 360;
        if (nacht)
        {

            i += 0.004f;
            rot += (4 - i) * Time.deltaTime;
            
            night.SetFloat("_Rotation", rot);
        }
        else {
            rot += 2 * Time.deltaTime;
            morning.SetFloat("_Rotation", rot);
        }


        if (player.transform.position.z > 650 && !rotationStart)  {
            rotationStart = true;
            barn.gameObject.SetActive(true);
            ground.gameObject.SetActive(true);
            landscape.gameObject.SetActive(true);
            StartCoroutine(rotateUp());
            start.gameObject.SetActive(false);

        }

        
        if (player.transform.position.z > 900)
        {
            ground.gameObject.SetActive(false);
           
        }
    }

    IEnumerator nightToDay() {
        RenderSettings.skybox = night;
        yield return new WaitForSeconds(7f);
        nacht = false;
        RenderSettings.skybox = morning;
        rot = 116;

    }

    // Landschaft am Ende ins Bild "schieben", Illusion "näherkommen", anstatt abruptes Erscheinen
    IEnumerator rotateUp()
    {
       
        for (int i = 0; i < 350; i++) {

            angleRot -= 0.01f;
            yield return new WaitForSeconds(0.025f);

           endAll.transform.rotation = Quaternion.RotateTowards(endAll.transform.rotation, Quaternion.Euler(angleRot , 0, 0),  Time.deltaTime);
           
        }

       
    }

    }
