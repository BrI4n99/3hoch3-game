using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ib_sheep1 : MonoBehaviour
{
    
    private bool showSheep1;
    public Image sheepPic1;

    // Start is called before the first frame update
    void Start()
    {
     
        
    }

    // Update is called once per frame
    void Update()
    {
        showSheep1 = ib_StaticVar.sheep1;

        if (showSheep1)
        {
            sheepPic1.enabled = true;
        }
        else
        {
            sheepPic1.enabled = false;
        }

    }
}
