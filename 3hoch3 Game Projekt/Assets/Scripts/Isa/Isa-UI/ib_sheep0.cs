using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ib_sheep0 : MonoBehaviour
{
  
    private bool showSheep0;
    public Image sheepPic0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showSheep0 = ib_LevelUI.sheep0;

        if (showSheep0) 
        {
            sheepPic0.enabled = true;
        } else {
            sheepPic0.enabled = false;
        }

    }
}
