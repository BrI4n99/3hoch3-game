using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TL_Elevator : MonoBehaviour
{
    bool onButton;
    GameObject button;
    GameObject elevator;
    int objectsOnButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Egg")
        {
            return;
        }
        objectsOnButton++;
        print("Trigger Enter");
        onButton = true;
    }

    private void OnTriggerExit(Collider other)
    {
        objectsOnButton--;
        print("Trigger Exit");
        if (objectsOnButton <= 0)
        {
            onButton = false;
        }       
    }

    void Start()
    {
        onButton = false;
        objectsOnButton = 0;

        button = GameObject.Find("Button");
        elevator = GameObject.Find("Elevator");
    }

    void Update()
    {
        //Button drücken und loslassen
        if (onButton)
        {
            Vector3 start = transform.position + new Vector3(0, -0.35f, 0);
            Vector3 end = start + new Vector3(0, -0.2f, 0);
            button.transform.position = Vector3.Lerp(start, end, 20f);
        }
        else
        {
            Vector3 start = transform.position + new Vector3(0, -0.35f, 0);
            Vector3 end = start + new Vector3(0, 0.2f, 0);
            button.transform.position = Vector3.Lerp(start, end, 20f);
        }

        //Fahrstuhl je nach Zustand des Buttons bewegen
        if (onButton && elevator.transform.position.y >= -10)
        {
            elevator.transform.position += new Vector3(0, -0.008f, 0);        
        }
        if (!onButton && elevator.transform.position.y < -0.2f)
        {
            elevator.transform.position += new Vector3(0, 0.008f, 0);
        }
    }
}
