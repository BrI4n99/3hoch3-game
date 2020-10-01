//Skript von Tim Liehr, Kamera-Anpassung von Kim Guddat

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_controller_camera : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 sheepVelocity;
    private Vector3 move;
    private bool sheepOnGround;
    public float sheepSpeed;
    public float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public GameObject camera;
    public float camera_height = 1.0f;

    //Object Pooler
    tl_ObjectPooler objectPooler;

    //Werte für das Werfen der Eier
    [Header("Throwing Settings")]
    public int eggForce;
    public float forceAngle;
    GameObject eggSpawn;

    //Rotation des Sheeps
    Vector3 rotationSheep;

    //Last pressed Button
    private KeyCode lastPressedKey;

    //Anpassungen Kamera Kim Janina Guddat:
    private bool headUp;

    //Isabell Bürkner
    private bool sheepIsMoving;

    // Ende Anpassungen Kamera Kim Janina Guddat

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        controller.center = new Vector3(0f, 0.71f, 0.12f);
        controller.radius = 0.64f;
        controller.height = 0f;
        controller.minMoveDistance = 0f;

        headUp = false;

        //Instanz der Klasse tl_ObjectPooler erzeugen, um auf deren Funktion zugreifen zu können
        objectPooler = tl_ObjectPooler.Instance;

        eggSpawn = new GameObject("Egg Spawn Point");
        eggSpawn.transform.parent = gameObject.transform;
        eggSpawn.transform.position = gameObject.transform.position;
        eggSpawn.transform.position += new Vector3(0, 0.3f, 1f);
    }

    //Kamera von Kim Guddat
       
    IEnumerator camUp()
    {
        camera.transform.rotation = camera.transform.rotation * Quaternion.AngleAxis(3.0f * Time.deltaTime, Vector3.right);
        yield return new WaitForSeconds(0.5f);
        headUp = false;
    }

    IEnumerator camDown()
    {
        camera.transform.rotation = camera.transform.rotation * Quaternion.AngleAxis(-3.0f * Time.deltaTime, Vector3.right);
        yield return new WaitForSeconds(0.5f);
        headUp = true;
    }
    //Ende Kamera von Kim Guddat
    void Update()
    {
        sheepOnGround = controller.isGrounded;
        if (sheepOnGround && sheepVelocity.y < 0)
        {
            sheepVelocity.y = 0f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            lastPressedKey = KeyCode.W;
            move = new Vector3(0, 0, 1);
            move = transform.TransformDirection(move);
            controller.Move(move * Time.deltaTime * sheepSpeed);
            rotationSheep = new Vector3(0, Input.GetAxis("Horizontal"), 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            lastPressedKey = KeyCode.S;
            move = new Vector3(0, 0, 1);
            move = transform.TransformDirection(move);
            controller.Move(-move * Time.deltaTime * sheepSpeed);
            rotationSheep = new Vector3(0, -Input.GetAxis("Horizontal"), 0);
        }
        else
        {
            move = new Vector3(0, 0, 0);
            move = transform.TransformDirection(move);
            controller.Move(move * Time.deltaTime * sheepSpeed);
            if (lastPressedKey == KeyCode.S)
            {
                rotationSheep = new Vector3(0, -Input.GetAxis("Horizontal"), 0);
            }
            else
            {
                rotationSheep = new Vector3(0, Input.GetAxis("Horizontal"), 0);
            }
        }

        if (move != Vector3.zero)
        {
            sheepIsMoving = true;
            transform.forward = move;
            //gameObject.transform.rotation = Quaternion.LookRotation(move);
        }
        else {
            sheepIsMoving = false;
        }

        if (Input.GetButtonDown("Jump") && sheepOnGround)
        {
            sheepVelocity.y += Mathf.Sqrt(jumpHeight * -3.1f * gravityValue);
        }

        transform.Rotate(rotationSheep);
        sheepVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(sheepVelocity * Time.deltaTime);

        //Camera
        //Anpassungen Kamera Kim Janina Guddat:

        camera.transform.parent = this.transform;
            camera.transform.position = new Vector3(camera.transform.position.x, camera_height + this.transform.position.y, camera.transform.position.z);

        // Wackeln 
        //Hovering / Floating
        if (sheepIsMoving)                             // Wackeln nur, wenn sich das Schaf bewegt - Anpassung Isabell Bürkner
        {                    
            if (headUp)
            { 
                StartCoroutine(camUp());
            }
            else
            {
                StartCoroutine(camDown());
            }
        } 

        // Ende Anpassungen Kamera Kim Janina Guddat

        //Eier werfen
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject egg = objectPooler.SpawnFromPool("Egg", eggSpawn.transform.position, eggSpawn.transform.rotation);
            Vector3 direction = Quaternion.AngleAxis(forceAngle, eggSpawn.transform.right) * eggSpawn.transform.forward;
            egg.GetComponent<Rigidbody>().AddForce(direction * eggForce);
        }

        //Sound Kim Janina Guddat
        if (kjg_tomatoTrigger.hitSheep) {
            //Audio
            GetComponent<AudioSource>().Play();
        }
    }
}
