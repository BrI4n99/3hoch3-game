using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_skybox : MonoBehaviour
{

    public float rot = 0;
    public Skybox sky;
    public Material morning;
 

    // Start is called before the first frame update


    void Start()
    {
        RenderSettings.skybox = morning;
        
    }
    void Update()
    {
        rot += 2 * Time.deltaTime;
        rot %= 360;
        morning.SetFloat("_Rotation", rot);
    }
}
