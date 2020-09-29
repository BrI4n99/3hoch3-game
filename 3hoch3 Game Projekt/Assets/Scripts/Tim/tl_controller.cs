using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tl_controller : LivingCreature
{
    private CharacterController controller;
    private Vector3 sheepVelocity;
    private Vector3 move;
    private bool sheepOnGround;
    private float gravityValue = -9.81f;
    [Header("Sheep Controller Settings")]
    public float sheepSpeed;
    public float jumpHeight = 1.0f;

    //Camera Settings
    [Header("Camera Settings")]
    public GameObject camera;
    public float camera_height = 2f;

    //Werte für das Werfen der Eier
    [Header("Throwing Settings")]
    public int eggForce;
    public float forceAngle;
    GameObject eggSpawn;

    //Werte Controller Push Settings
    public float pushPower = 2.0f;
    public float pushWeight = 6.0f;

    //Object Pooler
    tl_ObjectPooler objectPooler;

    //Zustand des Spielers
    bool playerAlive = true;

    //Rotation des Sheeps
    Vector3 rotationSheep;

    //Last pressed Button
    private KeyCode lastPressedKey;

    //Spawnpoint
    [Header("Spawnpoint")]
    public GameObject spawnpoint;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //------------------ Death des Players -----------------------------------
        if (hit.gameObject.name == "StrawBale")
        {
            print("Player lost");
            playerAlive = false;
        }

        if (hit.gameObject.name == "Water Collider")
        {
            print("Player lost");
            playerAlive = false;
        }
        //------------------------------------------------------------------------

        //------------------ Checkpoints -----------------------------------
        if (hit.gameObject.name == "Checkpoint Start")
        {
            print("Player reached Checkpoint Start");
            spawnpoint.transform.position = GameObject.Find("Checkpoint Start").transform.position;
            spawnpoint.transform.rotation = GameObject.Find("Checkpoint Start").transform.rotation;

            hit.gameObject.SetActive(false);
        }

        if (hit.gameObject.name == "Checkpoint Obstacle1")
        {
            print("Player reached Checkpoint Obstacle1");
            spawnpoint.transform.position = GameObject.Find("Checkpoint Obstacle1").transform.position;
            spawnpoint.transform.rotation = GameObject.Find("Checkpoint Obstacle1").transform.rotation;

            hit.gameObject.SetActive(false);
        }

        if (hit.gameObject.name == "Checkpoint Obstacle2")
        {
            print("Player reached Checkpoint Obstacle2");
            spawnpoint.transform.position = GameObject.Find("Checkpoint Obstacle2").transform.position;
            spawnpoint.transform.rotation = GameObject.Find("Checkpoint Obstacle2").transform.rotation;

            Destroy(GameObject.Find("Straw Bale Spawner"));
            hit.gameObject.SetActive(false);
        }
        //------------------------------------------------------------------------

        //------------------ Interaktion mit Rigidbodys --------------------------
        Rigidbody body = hit.gameObject.GetComponent<Rigidbody>();
        Vector3 force;

        //Falls kein Rigidbody
        if (body == null || body.isKinematic)
        {
            return;
        }

        if (hit.gameObject.tag == "ObjectToPush")
        {
            if (hit.moveDirection.y < -0.3)
            {
                force = new Vector3(0, -0.5f, 0) * 10 * pushWeight;
            }
            else
            {
                force = controller.velocity * pushPower + new Vector3(0, 5, 0);
            }

            body.AddForceAtPosition(force, hit.point);
        }        
        //------------------------------------------------------------------------
    }

    public override void Start()
    {
        base.Start();

        controller = gameObject.AddComponent<CharacterController>();
        controller.center = new Vector3(0f, 0.71f, 0.12f);
        controller.radius = 0.64f;
        controller.height = 0f;
        controller.minMoveDistance = 0f;

        // camera.transform.position = Vector3.zero;
        // camera.transform.position = camera.transform.position + new Vector3(0, camera_height, -2.2f);

        //Instanz der Klasse tl_ObjectPooler erzeugen, um auf deren Funktion zugreifen zu können
        objectPooler = tl_ObjectPooler.Instance;

        eggSpawn = new GameObject("Egg Spawn Point");
        eggSpawn.transform.parent = gameObject.transform;
        eggSpawn.transform.position = gameObject.transform.position;
        eggSpawn.transform.position += new Vector3(0, 0.3f, 0.7f);

        //Spawn des Players
        transform.position = spawnpoint.transform.position;
        transform.rotation = spawnpoint.transform.rotation;

        //Kamera
        camera.transform.position = new Vector3(transform.position.x, camera_height, transform.position.z - 2.2f);
    }

    // Update is called once per frame

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
            transform.forward = move;
            //gameObject.transform.rotation = Quaternion.LookRotation(move);
        }

        if (Input.GetButtonDown("Jump") && sheepOnGround)
        {
            sheepVelocity.y += Mathf.Sqrt(jumpHeight * -3.1f * gravityValue);
        }

        transform.Rotate(rotationSheep);
        sheepVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(sheepVelocity * Time.deltaTime);

        //Camera
        camera.transform.parent = transform;
        //camera.transform.position = new Vector3(camera.transform.position.x, transform.position.y + camera_height, camera.transform.position.z);
        //camera.transform.position = new Vector3(transform.position.x, camera_height, transform.position.z - 2.2f);

        //camera.transform.rotation = Quaternion.Euler(22, transform.rotation.y, 0);

        //Eier werfen
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject egg = objectPooler.SpawnFromPool("Egg", eggSpawn.transform.position, eggSpawn.transform.rotation);
            Vector3 direction = Quaternion.AngleAxis(forceAngle, eggSpawn.transform.right) * eggSpawn.transform.forward;
            egg.GetComponent<Rigidbody>().AddForce(direction * eggForce);
        }

        //Respawn des Spielers, je nach Checkpoint
        if (!playerAlive)
        {
            transform.position = spawnpoint.transform.position;
            transform.rotation = spawnpoint.transform.rotation;

            ib_StaticVar._lives--;
            playerAlive = true;
        }
    }
}
