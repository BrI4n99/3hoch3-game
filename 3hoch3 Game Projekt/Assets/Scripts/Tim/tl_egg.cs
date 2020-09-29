using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tl_egg : MonoBehaviour
{
    float damage = 20;

    private void OnCollisionEnter(Collision collision)
    {
        print(collision);
        
        IDamageable damageableObject = collision.collider.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeHit(damage);
        }
        
        gameObject.SetActive(false);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
