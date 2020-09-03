using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_goDuck : MonoBehaviour
{

    public GameObject duck;  
    public AudioSource chicken;
    bool go = false;
    private int counter = 0;
    bool gone = false;
    private Vector3 duckPos;
    private Vector3 newDuckPos;
    public Vector3[] goDuckPos = new Vector3[] { new Vector3(-1, 2, 5), new Vector3(-4, -1, 3), new Vector3(3, 1, 5), 
                                                 new Vector3(5, -1, 5), new Vector3(-4, 1, 5), new Vector3(-4, -1, 5), 
                                                 new Vector3(5, 1, 5), new Vector3(4, -1, 3), new Vector3(3, 0, 5), 
                                                new Vector3(-3, 1, 5), new Vector3(5, -1, 5), new Vector3(5, 0, 5)};


    public Vector3 jump = new Vector3(0, 1.5f, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
      //  while (go == false && gone == false) {
           //  StartCoroutine(JumpDuck());       
      //  }
        
        if (go && !gone && counter <= 1) {
        chicken.Play();
        StartCoroutine(MoveDuck());
        gone = true;
        go = false;

        }
         
    }



    void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "Player") {
            go = true;
        }
    }

     IEnumerator MoveDuck() {
        chicken.Play();
        
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < goDuckPos.Length; i++) 
        {
            yield return new WaitForSeconds(0.6f);
            duck.transform.position += goDuckPos[i];
        }
        counter++;
         Destroy(duck);
        chicken.Stop();
          
        
    }

    /*
    IEnumerator JumpDuck() {
        duck.transform.position += jump;
        yield return new WaitForSeconds(0.5f);
        duck.transform.position -= jump;
        yield return new WaitForSeconds(0.5f);
    }*/

}
