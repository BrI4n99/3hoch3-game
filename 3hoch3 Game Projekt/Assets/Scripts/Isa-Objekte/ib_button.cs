using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_button : MonoBehaviour
{
    
    public static bool first;
    public static bool second;

    Collider coll;
    public Animator animator; 
    BoxCollider beineVorn = new BoxCollider();
    public bool buttonStatus = false;
    int counter = 0;
    // int objectsOnButton;
    // bool onButton;


    Vector3 hoch = new Vector3(0, -0.35f, 0); 
    Vector3 runter = new Vector3(0, -0.65f, 0); 

    public GameObject fullBucket; 
    bool moveBucket;
    public GameObject button; 
    Vector3 aktuell;


    // Start is called before the first frame update
    void Start()
    {
    aktuell = button.transform.position;
    animator = GetComponentInParent<Animator>();
    // onButton = false;
        
    
    //objectsOnButton = 0;
    aktuell = button.transform.position; 

    

    }

    // Update is called once per frame
    void Update()
    {
        second = ib_button02.touch; 

        if (second) {
           buttonStatus = false;
        }

        animator.SetBool("onButton", buttonStatus);


        if (counter >= 3) 
        {
            fullBucket.transform.position = new Vector3(-10.5f, 10f, 29.3f); 
        }
        /*

        if (onButton)
        {
            button.transform.position = new Vector3(aktuell.x, -1.5f, aktuell.z);
            
        }
        else
        {
            button.transform.position = new Vector3(aktuell.x, 1.5f, aktuell.z);
            
        }
        // Vollen Eimer 
        if (onButton)
        {
            fullBucket.transform.position += new Vector3(0, 3, 0);        
        }

        */

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "beineVorn")
        {
            print("enter");
            buttonStatus = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "beineVorn")
        {
            print("exit");
            buttonStatus = false;
            counter++;
        }
    }

    /*void OnCollisionEnter(Collision other)
    {


        if (other.gameObject.tag == "Player" && !first)
        {

            first = true;
            //button.transform.position = new Vector3(aktuell.x, runter.y, aktuell.z);
            //animator.SetBool("onButton", true);
            buttonStatus = true;
            Debug.Log("on -first");


        }

        if (second) {
            moveBucket = true; 
            //animator.SetBool("onButton", true);
            buttonStatus = true;
            Debug.Log("on -third");

        }



    }
    */
    /*        void OnCollisionExit(Collision other)
            {

               // objectsOnButton--;
                //if (objectsOnButton <= 0) {
                //button.transform.position = new Vector3(aktuell.x, hoch.y, aktuell.z);
                animator.SetBool("button", false);
                Debug.Log("off" + counter);
                //}
            }
     */
}
