using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ib_controllerNeu : MonoBehaviour
{
    // Dieser Controller wurde komplett von Isabell Bürkner erstellt - Ziel war es dem Schaf jedoch ähnliche Funktionalitäten zu geben, wie im Controller von Kim Janina Guddat / Tim Liehr

    public GameObject cam;
    public float cam_height = 1.0f;
    private bool headUp = true;
    bool sheepIsMoving = true;

    public float speed;         // 16 
    public float speedAround;   // 36
    public float JumpHeight;    // 9f

    public bool isGrounded = true;

    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Camera
        cam.transform.parent = this.transform;
        cam.transform.position = new Vector3(cam.transform.position.x, cam_height + cam.transform.position.y, cam.transform.position.z);
    }



    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");


        // Sprinten
        // float endSpeed = Input.GetKey(KeyCode.LeftShift) ? speed * 1.25f : speed;


        // Vorwärts laufen
        if (verticalMovement > 0f)
        {
            float endspeed;

            // Sprinten
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                endspeed = speed * 1.25f;
            }
            // normal
            else {
                endspeed = speed;
            }

            Vector3 movement = new Vector3(0, 0, verticalMovement) * endspeed;
            gameObject.transform.Translate(movement * Time.deltaTime);
        }


        // Rückwärts hopsen 
        else if (verticalMovement < 0f)
            {
            if (isGrounded) rb.velocity = (Vector3.up - transform.forward * 3f) * 2f;
        }
        

        // Drehen 
        Vector3 around = new Vector3(0, horizontalMovement, 0) * speedAround;
        gameObject.transform.Rotate(around * Time.deltaTime);


        // Springen
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector3.up * (JumpHeight);
        }


        // Kamera "wackeln" als Imitation des "Laufens", immer wenn sich das Schaf bewegt

        if (verticalMovement != 0 || horizontalMovement != 0)
        {
            sheepIsMoving = true;
        }
        else
        {
            sheepIsMoving = false;
        }

        if (sheepIsMoving)
        {
            if (headUp)
            {
                StartCoroutine(camUp());
            }
            
        }


        // "Strahl", der nach unten prüft, ob sich dort etwas befindet 
        isGrounded = Physics.Raycast(transform.position + Vector3.up * 2, Vector3.down, out RaycastHit hitInfo, 4f);
    }


    void FixedUpdate()
    {
        // Physikalische Berechnungen
        // rb.AddForce(Physics.gravity); // über Inspector

    }

    // Angelehnt an Funktionalität von Kim Janina Guddat
    IEnumerator camUp()
    {
        headUp = false;
        cam.transform.rotation = cam.transform.rotation * Quaternion.AngleAxis(12.0f * Time.deltaTime, Vector3.right);
        yield return new WaitForSeconds(0.75f);
    
        cam.transform.rotation = cam.transform.rotation * Quaternion.AngleAxis(-12.0f * Time.deltaTime, Vector3.right);
        yield return new WaitForSeconds(0.75f);
        headUp = true;
    }

   
}


