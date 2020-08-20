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

    //Anpassungen Kamera Kim Janina Guddat:
    private bool headUp;


    // Ende Anpassungen Kamera Kim Janina Guddat

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        controller.center = new Vector3(0f, 0.71f, 0.12f);
        controller.radius = 0.64f;
        controller.height = 0f;
        controller.minMoveDistance = 0f;

        // camera.transform.position = Vector3.zero;
        // camera.transform.position = camera.transform.position + new Vector3(0, camera_height, -2.2f);
    }

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

    // Update is called once per frame
    void Update()
    {
        sheepOnGround = controller.isGrounded;
        if (sheepOnGround && sheepVelocity.y < 0)
        {
            sheepVelocity.y = 0f;
        }

        move = new Vector3(0, 0, Input.GetAxis("Vertical"));
        move = transform.TransformDirection(move);
        controller.Move(move * Time.deltaTime * sheepSpeed);

        if (move != Vector3.zero)
        {
            transform.forward = move;
            //gameObject.transform.rotation = Quaternion.LookRotation(move);
        }

        if (Input.GetButtonDown("Jump") && sheepOnGround)
        {
            sheepVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        sheepVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(sheepVelocity * Time.deltaTime);

        //Camera
        //Anpassungen Kamera Kim Janina Guddat:
            camera.transform.parent = this.transform;
            camera.transform.position = new Vector3(camera.transform.position.x, camera_height + this.transform.position.y, camera.transform.position.z);

        // Wackeln 
        //Hovering / Floating
        if (headUp)
        {
            StartCoroutine(camUp());
        }
        else
        {
            StartCoroutine(camDown());
        }

        // Ende Anpassungen Kamera Kim Janina Guddat

    }
}
