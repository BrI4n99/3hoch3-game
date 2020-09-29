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
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("bonus " + ib_StaticVar._bonus);
            ib_StaticVar._score += ib_StaticVar._bonus;
            nextLevel = true;
            Debug.Log("SET TRUE");
            Debug.Log("now " + nextLevel);
            SceneManager.LoadScene("ib_nextLevel2");
        }
        nextLevel = false;
    }


}
