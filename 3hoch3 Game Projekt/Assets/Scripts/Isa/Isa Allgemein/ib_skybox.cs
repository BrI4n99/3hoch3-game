using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_skybox : MonoBehaviour
{

    public float rot = 90;
    public Skybox sky;
    public Skybox skyNight;
    public Material morning;
    public Material night;
    bool nacht = true;
    float i;


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
    

    }

    IEnumerator nightToDay() {
        RenderSettings.skybox = night;
        yield return new WaitForSeconds(7f);
        nacht = false;
        RenderSettings.skybox = morning;
        rot =116;

    }

}
