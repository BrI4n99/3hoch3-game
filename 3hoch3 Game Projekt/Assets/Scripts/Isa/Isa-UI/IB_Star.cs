using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IB_Star : MonoBehaviour
{

    public Canvas canvas;
    private static Image star;
    private bool zoom;
    public Vector3 scale = new Vector3(1.5f, 1.5f, 1.5f) ;


    #region Singleton

    public static IB_Star Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("ib_LevelUI").GetComponent<Canvas>();
        star = canvas.transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static IEnumerator starZoom() {
        for (int i = 1; i < 6; i++)
        {
            star.transform.localScale += (new Vector3(i+ 0.005f, i + 0.005f, i+ 0.005f));
            yield return new WaitForSeconds(0.1f);

        }
        yield return new WaitForSeconds(1f);

        for (int i = 1; i < 6; i++)
        {
            star.transform.localScale -= (new Vector3(i+ 0.005f, i + 0.005f, i+ 0.005f));
            yield return new WaitForSeconds(0.1f);

        }
    }
}
