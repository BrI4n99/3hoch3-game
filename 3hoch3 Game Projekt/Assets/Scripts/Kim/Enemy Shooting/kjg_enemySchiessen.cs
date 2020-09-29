using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_enemySchiessen : MonoBehaviour
{
    public GameObject tomato;
    float bulletSpeed = 500;
    GameObject temptomato;

  void shoot() {
        temptomato = Instantiate(tomato, transform.position, Quaternion.identity) as GameObject;
        Rigidbody temptomatoRigidbody = temptomato.GetComponent<Rigidbody>();

        //Rigidbody eine Force hinzufügen, damit Tomate in eine Richtung fliegt.

        temptomatoRigidbody.AddForce(-temptomatoRigidbody.transform.right * bulletSpeed);

        //Destroy TempBullet -- ÄNDERN --
        //Zermatschte Stelle auf Boden hinzufügen

        Destroy(temptomato, 1);

        //Audio
        GetComponent<AudioSource>().Play();
    }

    float zeit;
    // Update is called once per frame
    void Update()
    {
        zeit += Time.deltaTime;
        if (zeit > 1.5f && kjg_triggerShooting.shootTrigger)
        {
            shoot();
            zeit = 0;
        }
    }
}
