using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ib_button : MonoBehaviour
{
    public Animator animator; 
  //  BoxCollider beineVorn = new BoxCollider();
    
    public GameObject button;
    public GameObject fullBucket;
    public GameObject well;
    float distance;

    public AudioSource chain; 

    public static bool first;
    public static bool second = true;
    public bool buttonStatus = false;
   // bool moveBucket;

    int counter = 0;
    public static int bonuspunkte = 0;
    private bool playSound; 

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


        if (counter == 1 && !playSound) {
            playSound = true;
            chain.Play();
        }

        if (first == true && second == true)
        {
            StartCoroutine(Move());
         
            second = false;
            first = false;

            
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "beineButton")
        {
            buttonStatus = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "beineButton")
        {
            buttonStatus = false;
           
            if (counter < 3)
            {
                counter++;
            }

            if (counter == 3 && second == true)
            {
                first = true;
                chain.Play();
            }
            
        }
    }

    IEnumerator Move()
    {
        second = false;
        yield return new WaitForSeconds(2f);
        fullBucket.transform.position += transform.position;
        fullBucket.transform.position = new Vector3(-10.5f, 6.5f, 29.3f + distance);
        yield return new WaitForSeconds(2f);
        fullBucket.transform.position = new Vector3(-10.5f, 10.5f, 29.3f + distance);

        Debug.Log("+ 100 Punkte: Du hast es geschafft. Dein Durst ist gestillt.");
        ib_StaticVar._score += 100;
        StartCoroutine(starScript.zoom2());

    }


}
