using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_rollingBarrel : MonoBehaviour
{

    private Rigidbody rb;
    public float speed = 10;
    public float xForce;
    public float zForce;
    public static int sterben = 0;

    private bool barrCheck = false;
    
    int lives;
    // Start is called before the first frame update
    void Start()
    {
            gameObject.SetActive(false);
       // rb = gameObject.AddComponent<Rigidbody>();
        rb = gameObject.GetComponent<Rigidbody>();  
     
    }

    // Update is called once per frame
    void Update()
    {
       //  rb.AddForce(speed * new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")));
       lives = ib_GUI.leben;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ib_ground")
        {
            Debug.Log("test touch ground");
            speed += 30;
            transform.Rotate(Random.Range(-15, 15),Random.Range(10, 15),Random.Range(15, 20));

            rb.AddRelativeForce (Vector3.forward * 40);

        }

        if (other.gameObject.tag == "Player")
        {
            if (barrCheck == false && !rb.IsSleeping()) {           // ruhende Fässer - kein Abzug
                Debug.Log("Neeeein, das war nicht gut....");
                rb.drag = 50;
                Destroy(gameObject, 1.5f);
                //rb.useGravity = false;
                // 
                sterben++;

                if (lives == 0) {
                    Debug.Log("GameOver");
                }
                barrCheck = true;
            }
        }
    }


    

}