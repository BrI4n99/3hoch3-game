using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_Test : MonoBehaviour
{

    GameObject heuballen;
    GameObject moehre;
    GameObject kiste;
    GameObject schaf;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Test-Script Isabell Buerkner");

        schaf = GameObject.CreatePrimitive(PrimitiveType.Cube); schaf.name = "schafRudi";
        moehre = GameObject.CreatePrimitive(PrimitiveType.Sphere); moehre.name = "moehre";

        moehre.transform.position +=  new Vector3(2, 0, 2f);


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update Test-Script Isabell Buerkner");

    }
}
