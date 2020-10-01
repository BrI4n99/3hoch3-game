using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IB_Star : MonoBehaviour
{

    public Canvas canvas;
    public Image star;
    
    public Vector3 scale = new Vector3(1.5f, 1.5f, 1.5f) ;
    Animator starZoom;

    #region Singleton                                       
    public static IB_Star Instance;                                     // Methodenaufrufe in anderen Scripts möglich

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        starZoom = star.GetComponent<Animator>();
        float len = starZoom.runtimeAnimatorController.animationClips[0].length;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  IEnumerator zoom() {
        
        starZoom.enabled = true;
     
        starZoom = star.GetComponent<Animator>();
        float len = starZoom.runtimeAnimatorController.animationClips[0].length;
        starZoom.SetBool("startZoom", false);
        StartCoroutine(stop());
        yield return new WaitForSeconds(0.1f);
    
    }


    public IEnumerator stop()
    {
       
        yield return new WaitForSeconds(1.75f);
        starZoom.enabled = false;
    }


    public IEnumerator zoom2()
    {
        starZoom.enabled = true;
        starZoom = star.GetComponent<Animator>();
        starZoom.SetBool("startZoom", true);
        StartCoroutine(stop());
        yield return new WaitForSeconds(2);
        starZoom.enabled = false;
      
    }


}
