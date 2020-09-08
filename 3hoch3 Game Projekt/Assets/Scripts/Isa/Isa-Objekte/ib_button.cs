using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_button : MonoBehaviour
{
    public Animator animator; 
    BoxCollider beineVorn = new BoxCollider();
    
    public GameObject button;
    public GameObject fullBucket;
    public GameObject well;
    float distance;

    public AudioSource chain; 

    public static bool first;
    public static bool second = true;
    public bool buttonStatus = false;
    bool moveBucket;

    int counter = 0;
    public static int bonuspunkte = 0;


    // Start is called before the first frame update
    void Start()
    {
    distance = well.transform.position.z;
    animator = GetComponentInParent<Animator>();
    chain.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("onButton", buttonStatus);

        if (first == true && second == true)
        {
            Debug.Log("Play und Move");
            StartCoroutine(Move());
            chain.Play();
            second = false;
            first = false;
            bonuspunkte = 150;
        }

        /*
          Vector3 aktPos = fullBucket.transform.position;
          float aktY = aktPos.y;

          if (aktY <= 10.5 && first == true && second == true) {
                StartCoroutine(Move());
        }*/

        /*
       if (aktPos.y >= 10f ) 
       {
           first = false;
           second = false;
       }*/

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "beineButton")
        {
            print("enter");
            buttonStatus = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "beineButton")
        {
            print("exit");
            buttonStatus = false;
           
            if (counter < 3)
            {
                counter++;
            }

            if (counter == 3 && second == true)
            {
                first = true;
            }

            Debug.Log(counter);
            
        }
    }

    IEnumerator Move()
    {
        second = false;
        print("Move");
        yield return new WaitForSeconds(2f);
        fullBucket.transform.position += transform.position;
        fullBucket.transform.position = new Vector3(-10.5f, 6.5f, 29.3f + distance);
        yield return new WaitForSeconds(2f);
        fullBucket.transform.position = new Vector3(-10.5f, 10.5f, 29.3f + distance);
        /*yield return new WaitForSeconds(2f);
        Vector3 start = fullBucket.transform.position;
        Vector3 ende = start + new Vector3(0, 2.5f, 0);
        fullBucket.transform.position = Vector3.Lerp(start, ende, Time.deltaTime * 2);*/

    }


}
