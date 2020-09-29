using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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

    IB_Star starScript;

    // Start is called before the first frame update
    void Start()
    {

    starScript = IB_Star.Instance;
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
            // bonuspunkte = 150;

            
        }


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

        Debug.Log("150 Punkte");
        ib_StaticVar._score += 150;
        StartCoroutine(starScript.zoom2());

    }


}
