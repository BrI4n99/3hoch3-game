using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_carrotsPosition : MonoBehaviour
{
    public GameObject carrot;
    public GameObject carrotFail;

    // Start is called before the first frame update
    void Start()
    {
        
    int size = 50;
    Vector3[] values = new Vector3[size];
    int i = 0;
    

    // Array mit Koordinaten befüllen, an denen Möhren positioniert werden sollen
    values[i++] = new Vector3(-32, 1f, 15f);    // 0
    values[i++] = new Vector3(-16f, 1f, 35f);   // 1
    values[i++] = new Vector3(-32, 1f, 60);     // 2   
    values[i++] = new Vector3(-8f, 1f, 85);     // 3       
    values[i++] = new Vector3(-24, 3f, 132);    // 4      
    values[i++] = new Vector3(-8f, 3f, 264);    // 5

    // 12 vor einem Heuballen  Vector3 carrotDistance = new Vector3(0, 0, -12);

       
    for (int j = 0; j < i; j++) {
      GameObject collectCarrot = Instantiate(carrot, values[j], gameObject.transform.rotation);  
      carrot.name = string.Format("carrot_"+ j);
    }


      GameObject someFailCarrot = Instantiate(carrotFail, values[0] + new Vector3(10, 0, 0), gameObject.transform.rotation);  


}
    // Update is called once per frame
    void Update()
    {
        
    }
}
