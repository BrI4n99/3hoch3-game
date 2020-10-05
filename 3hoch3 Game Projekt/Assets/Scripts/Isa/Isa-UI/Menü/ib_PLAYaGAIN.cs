using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ib_PLAYaGAIN : MonoBehaviour
{
   

     ib_StaticVar staticScript;
     ib_Datenspeicher datenspeicher;


    // Start is called before the first frame update
    void Start()
    {
        staticScript = ib_StaticVar.Instance;
        datenspeicher = ib_Datenspeicher.Instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void QuitMenu()
    {
       //UnityEditor.EditorApplication.isPlaying = false; // später löschen
        Application.Quit();
    }

    public void PlayGameAgain(string level)
    {
        staticScript.setLevel1Values();
        Scene scene = SceneManager.GetActiveScene();
  
        SceneManager.LoadScene("ib-szene");

    }

    public void PlayNextOne(string level)
    {
        Debug.Log("level1 " + ib_StaticVar.level1);

        if (level == "ib-szene") {
            datenspeicher.setLevel1Values();
        }

        /* if (level == "kjg-szene" && ib_StaticVar.level1 == false) {
            datenspeicher.setLevel2Values();
        }

        if (level == "tl-szene" && ib_StaticVar.level1 == false && ib_StaticVar.level2 == false) {
            datenspeicher.setLevel2Values();
        }*/

        datenspeicher.setLevel2Values();
        SceneManager.LoadScene(level);
    }
}



