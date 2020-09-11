using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ib_sheep3 : MonoBehaviour
{
    private bool showSheep3;
    public Image sheepPic3;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showSheep3 = ib_LevelUI.sheep3;

        if (showSheep3)
        {
            sheepPic3.enabled = true;
        }
        else
        {
            sheepPic3.enabled = false;
        }

    }
}
