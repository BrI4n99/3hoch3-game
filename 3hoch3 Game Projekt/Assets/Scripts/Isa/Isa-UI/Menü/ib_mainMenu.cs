using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ib_mainMenu : MonoBehaviour
{
    //public GameObject looseScreen;
    ib_StaticVar staticScript;

    // Start is called before the first frame update
    void Start()
    {
        staticScript = ib_StaticVar.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame(string level)
    {
        SceneManager.LoadScene(level);
       
    }




    public void QuitMenu() {
        UnityEditor.EditorApplication.isPlaying = false; // später löschen
        Application.Quit();
    }

    


}
