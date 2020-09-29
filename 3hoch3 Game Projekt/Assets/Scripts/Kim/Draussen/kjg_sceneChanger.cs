using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class kjg_sceneChanger : MonoBehaviour
{
    public float stopp;
    private float zeit;
    public static bool warDraussen;
    private void Start()
    {
        warDraussen = true;
    }
    // Update is called once per frame
    void Update()
    {
        zeit += Time.deltaTime;

        if (zeit > stopp) {
            Debug.Log("Change Scene");
            SceneManager.LoadScene("kjg-szene");
        }
    }
}
