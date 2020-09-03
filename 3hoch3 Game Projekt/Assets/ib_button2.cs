using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_button2 : MonoBehaviour
{

    public bool firstTouch;
    public Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        firstTouch = ib_button.first;
    }


    void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Player" && firstTouch == true)
            {
                animator.SetBool("button", false);
                Debug.Log("off");
               
            }
        }
}
