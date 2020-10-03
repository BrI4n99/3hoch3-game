using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ib_CheckBox_rollBarr : MonoBehaviour
{
    public GameObject fence; 
    public GameObject barrel1;
    public GameObject barrel2;
    public GameObject barrel3;
    Rigidbody rigidbody1;
    Rigidbody rigidbody2;
    Rigidbody rigidbody3;



    GameObject sheep;
    Vector3 sheepPos;
    public Canvas canvas;
    public Image sign;


    public static float hoch = 0;//Screen.height / 1.75F;
    public static float picHeight = 0;
    public static float height = 0;

    private bool touch;

    ib_abschnittGen gen;



    // Start is called before the first frame update
    void Start()
    {
        sheep = GameObject.FindGameObjectWithTag("Player");

        gen = ib_abschnittGen.Instance;

        canvas = GameObject.FindGameObjectWithTag("ib_HinweisCarrot").GetComponent<Canvas>();
        sign = canvas.transform.GetChild(3).GetComponent<Image>();
        picHeight = sign.sprite.rect.height;


        rigidbody1 = barrel1.GetComponent<Rigidbody>();
        rigidbody2 = barrel2.GetComponent<Rigidbody>();
        rigidbody3 = barrel3.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        sheepPos = sheep.transform.position;
        Vector2 sizeDelta = canvas.GetComponent<RectTransform>().sizeDelta;

        Vector2 canvasScale = new Vector2(canvas.transform.localScale.x, canvas.transform.localScale.y);

        Vector2 finalScale = new Vector2(sizeDelta.x * canvasScale.x, sizeDelta.y * canvasScale.y);
        hoch = (finalScale.x - picHeight * canvasScale.x * 1.2f);
    }

    void OnTriggerEnter(Collider other) 
    {
      
        if (other.gameObject.tag == "Player") {
            
        barrel1.gameObject.SetActive(true); 
        barrel2.gameObject.SetActive(true);
        barrel3.gameObject.SetActive(true);
        rigidbody1.useGravity = true; 
        rigidbody2.useGravity = true;
        rigidbody3.useGravity = true;

       
 

            if (touch != true && sheepPos.z < 900)
            {

                StartCoroutine(openSign());
                touch = true;
                StartCoroutine(closeSign());
            }

        
        
        }
    }


    public IEnumerator closeSign()
    {
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < hoch; i += 15)
        {
            sign.transform.Translate(new Vector3(0, -15, 0));
            yield return new WaitForSeconds(0.001f);
        }
    }

    public IEnumerator openSign()
    {
        for (int i = 0; i < hoch; i += 15)
        {
            sign.transform.Translate(new Vector3(0, 15, 0));
            yield return new WaitForSeconds(0.001f);

        }
    }

}



