using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ib_eggText : MonoBehaviour
{
    
    public Text eggText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        eggText.text = "" + ib_StaticVar._eggs; 

    }
}
