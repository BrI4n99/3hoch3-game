using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_crackedEggs : MonoBehaviour
{
    public GameObject egg1;
    public GameObject egg2;
    public GameObject egg3;
    public GameObject crackedEgg;

    Vector3 posEgg1;
    Vector3 posEgg2;
    Vector3 posEgg3;


   

    public AudioSource crack;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == egg1)
        {
            posEgg2 = egg2.transform.position;
            Destroy(egg1, 0.1f) ;
            crack.Play();
            StartCoroutine(kaputteEier(posEgg1));
        }

        if (other.gameObject == egg2)
        {
            posEgg2 = egg2.transform.position;
            Destroy(egg2, 0.1f);
            crack.Play();
            StartCoroutine(kaputteEier(posEgg2));
           
        }

        if (other.gameObject == egg3)
        {
            posEgg3 = egg3.transform.position;
            Destroy(egg3, 0.1f);
            crack.Play();
            StartCoroutine(kaputteEier(posEgg3));
     
            
        }

    }


    IEnumerator kaputteEier( Vector3 pos)
    {
        yield return new WaitForSeconds(0.1f);
        GameObject crackedEgg1 = Instantiate(crackedEgg, new Vector3 (pos.x + 2, pos.y, pos.z), Quaternion.identity);
    }
}
