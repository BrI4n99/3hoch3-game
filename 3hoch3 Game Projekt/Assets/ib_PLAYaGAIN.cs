using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ib_PLAYaGAIN : MonoBehaviour
{
    public GameObject looseScreen;
    
    // Start is called before the first frame update
    void Start()
    {

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
       UnityEditor.EditorApplication.isPlaying = false; // später löschen
        Application.Quit();
    }

    public void PlayGameAgain(string level)
    {
        looseScreen.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }

    public void PlayNextOne(string level)
    {

        SceneManager.LoadScene(level);
    }
}



