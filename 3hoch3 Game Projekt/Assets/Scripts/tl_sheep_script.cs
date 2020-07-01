using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tl_sheep_script : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 sheepVelocity;
    private Vector3 move;
    private bool sheepOnGround;
    public float sheepSpeed;
    public float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        controller.center = new Vector3(0f, 0.7f, 0.12f);
        controller.radius = 0.64f;
        controller.height = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        sheepOnGround = controller.isGrounded;
        if (sheepOnGround && sheepVelocity.y < 0)
        {
            sheepVelocity.y = 0f;
        }

        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * sheepSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        if (Input.GetButtonDown("Jump") && sheepOnGround)
        {
            sheepVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        sheepVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(sheepVelocity * Time.deltaTime);
    }
}
