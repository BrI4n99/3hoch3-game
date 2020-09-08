
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_controller_Anpassungen : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 sheepVelocity;
    private Vector3 move;
    private bool sheepOnGround;
    public float sheepSpeed;
    public float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    public GameObject camera;
    public float camera_height = 1.0f;

    //Anpassungen Kamera Kim Janina Guddat:
    private bool headUp;


    // Isa: ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Vector3 old_pos;
    Vector3 new_pos;
    bool sheepIsMoving = true;
    
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    // Ende Anpassungen Kamera Kim Janina Guddat

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        controller.center = new Vector3(0f, 0.71f, 0.12f);
        controller.radius = 0.64f;
        controller.height = 0f;
        controller.minMoveDistance = 0f;


        camera.transform.rotation = Quaternion.Euler(23, 0, 0);
        camera.transform.Translate(new Vector3(0, 0, -1));
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
    //Ende Kamera von Kim Guddatkj
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
            sheepIsMoving = true;
            //gameObject.transform.rotation = Quaternion.LookRotation(move);
        }

        else sheepIsMoving = false;

        if (Input.GetButtonDown("Jump") && sheepOnGround)
        {
            sheepVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        sheepVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(sheepVelocity * Time.deltaTime);


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




        //Camera
        //Anpassungen Kamera Kim Janina Guddat:
        camera.transform.parent = this.transform;
        camera.transform.position = new Vector3(camera.transform.position.x, camera_height + this.transform.position.y, camera.transform.position.z);

        // Wackeln 
        //Hovering / Floating

        if (  sheepIsMoving ) {
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

    }


    // Isa: ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
   

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}



/*
  

 function Start()
 {
 
 }

 function Update()
 {
     StartCoutine(isMoving());
     new_pos = transform.position;
     if(old_pos.x == new_pos.x && old_pos.y == new_pos.y  &&  old_pos.z == new_pos.z   )
     {
        sheepIsMoving = false;   
        print("Dont moving right now");
     }
     else sheepIsMoving = true;
 }
 
 
    IEnumerator isMoving()
    {
        old_pos = transform.position;
        yield return new WaitForSeconds(0.01f); 
    }


// oder 


     if(rigidbody.velocity.magnitude > 0)
     {
       // Player is moving
     }

    
 */





