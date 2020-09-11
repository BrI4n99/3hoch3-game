using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ib_eggText : MonoBehaviour
{
    
    public Text eggText;
    private int countEggs;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        countEggs = ib_LevelUI.eggs;
        eggText.text = "" + countEggs;

    }
}
