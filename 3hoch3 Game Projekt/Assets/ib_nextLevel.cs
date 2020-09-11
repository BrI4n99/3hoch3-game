using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ib_nextLevel : MonoBehaviour
{

    public static bool nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (nextLevel) {

            Debug.Log("Szenenwechsel");
            nextLevel = false;
            SceneManager.LoadScene("ib_nextLevel2");
            
        }*/

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            nextLevel = true;
            Debug.Log("SET TRUE");
            SceneManager.LoadScene("ib_nextLevel2");
        }
        nextLevel = false;
    }
}
