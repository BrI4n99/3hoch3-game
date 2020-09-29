using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TL_SiloDoor : MonoBehaviour
{
    public float rotSpeed = 200f;
    private Quaternion startRot, endRot;
    bool targetHit = false;
    private float smooth;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Egg")
        {
            targetHit = true;
            //Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        startRot = transform.parent.parent.rotation;
        endRot = Quaternion.AngleAxis(-85, Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetHit && transform.parent.parent.rotation.y > -90)
        {
            transform.parent.parent.Rotate(-Vector3.up * (10 * Time.deltaTime));
        }
    }
}
