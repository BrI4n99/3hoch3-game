using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_fence : MonoBehaviour
{

    // Zaun
    Vector3 fencePos;
    public AudioSource sheep;
    public float fenceLen = 72; 
    public float hoehe;
    public float ab =0;
    public float barHeight = 3.7f;
    
    public int abzug = -25;
    private bool touch = false;
    public static int minuspunkte = 0;

    Mesh meshFence;                               // stakes
    public List<int> facesFence;
    public List<Vector3> verticesFence, normalsFence;
    public List<Vector2> uvFence;
    int counterFence = 0;

    public Material fenceMat;
    public BoxCollider myColl = new BoxCollider();
    


    // Start is called before the first frame update
    void Start()
    {
        myColl = gameObject.AddComponent<BoxCollider>();

        // building the fence
        verticesFence = new List<Vector3>();
        facesFence = new List<int>();
        normalsFence = new List<Vector3>();
        uvFence = new List<Vector2>();

        //fence = new GameObject(); fence.name = "fence";

        // Mesh and Renderer 
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        for (int i = 0; i < fenceLen; i++)
        {
            int rand = Random.Range(0, 40);
            if (rand == 1) continue;

            Vector3 fencePos = new Vector3(1, 0, 5 * i );
            buildStakes(fencePos);

        }
        Vector3 stakesPos1 = new Vector3(1, barHeight, -1.5f);
        buildBars(stakesPos1, fenceLen*5f );
        Vector3 stakesPos2 = new Vector3(1, barHeight*2, -1.5f);
        buildBars(stakesPos2, fenceLen*5f);
        showFence();

        Renderer fenceRend = gameObject.GetComponent<Renderer>();
        fenceRend.material = fenceMat;
      
    }

    // Update is called once per frame
    void Update()
    {

    }


    void createStakeFaces(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
        Vector3 normale = getNormalesFence(c, b, a);         // Normale berechnen lassen: wie Dreieck I (Reihenfolge)
        verticesFence.Add(a); normalsFence.Add(normale); uvFence.Add(new Vector2(1.0f, 1.0f));
        verticesFence.Add(b); normalsFence.Add(normale); uvFence.Add(new Vector2(1.0f, 0.0f));
        verticesFence.Add(c); normalsFence.Add(normale); uvFence.Add(new Vector2(0.0f, 0.0f));
        verticesFence.Add(d); normalsFence.Add(normale); uvFence.Add(new Vector2(0.0f, 1.0f));
        

        facesFence.Add(counterFence + 2);                 // Dreieck I
        facesFence.Add(counterFence + 1);
        facesFence.Add(counterFence + 0);
        facesFence.Add(counterFence + 0);                 // Dreieck II
        facesFence.Add(counterFence + 3);
        facesFence.Add(counterFence + 2);

        counterFence += 4;
        
    }


    void buildStakes(Vector3 pos)
    {

        float[] hoch = new float[8] { 10f, 9.6f, 9.4f, 10.5f, 10.3f, 9.7f, 9.8f, 10.1f };

        hoehe = hoch[Random.Range(0, 8)]- ab; 

                                                        // Aufbau eines Wuerfels / Pfahls aus Grundflaeche
        Vector3 a = new Vector3(1f, 0f, 1f) + pos;      // Boden: entgegen dem Uhrzeigersinn
        Vector3 b = new Vector3(-1f, 0f, 1f) + pos;
        Vector3 c = new Vector3(-1f, 0f, -1f) + pos;
        Vector3 d = new Vector3(1f, 0f, -1f) + pos;
        // hoehe = 13f;
        Vector3 e = new Vector3(1f, hoehe, 1f) + pos;  // Decke: entgegen dem Uhrzeigersinn 
        Vector3 f = new Vector3(-1f, hoehe, 1f) + pos;
        Vector3 g = new Vector3(-1f, hoehe, -1f) + pos;
        Vector3 h = new Vector3(1f, hoehe, -1f) + pos;
        createStakeFaces(a, d, c, b);                    // Zusammensetzen des Wuerfels / Pfahls
        createStakeFaces(e, f, g, h);
        createStakeFaces(a, e, h, d);
        createStakeFaces(b, c, g, f);
        createStakeFaces(c, d, h, g);
        createStakeFaces(a, b, f, e);
    }

    void buildBars(Vector3 pos, float length)
    {                                                   // Aufbau eines Wuerfels / Pfahls aus Grundflaeche
        Vector3 a = new Vector3(0.8f, 0f, length) + pos;      // Boden: entgegen dem Uhrzeigersinn
        Vector3 b = new Vector3(-0.8f, 0f, length) + pos;
        Vector3 c = new Vector3(-0.8f, 0f, 0) + pos;
        Vector3 d = new Vector3(0.8f, 0f, 0) + pos;
        float hoehe = 1f;
        Vector3 e = new Vector3(0.8f, hoehe, length) + pos;  // Decke: entgegen dem Uhrzeigersinn 
        Vector3 f = new Vector3(-0.8f, hoehe, length) + pos;
        Vector3 g = new Vector3(-0.8f, hoehe, 0) + pos;
        Vector3 h = new Vector3(0.8f, hoehe, 0) + pos;
        createStakeFaces(a, d, c, b);                    // Zusammensetzen des Wuerfels / Pfahls
        createStakeFaces(e, f, g, h);
        createStakeFaces(a, e, h, d);
        createStakeFaces(b, c, g, f);
        createStakeFaces(c, d, h, g);
        createStakeFaces(a, b, f, e);
    }


    void showFence()
    {
        meshFence = new Mesh();
        meshFence.vertices = verticesFence.ToArray();
        meshFence.normals = normalsFence.ToArray();
        meshFence.triangles = facesFence.ToArray();
        meshFence.uv = uvFence.ToArray();
        gameObject.GetComponent<MeshFilter>().mesh = meshFence;
        meshFence.RecalculateNormals();
        MeshCollider meshColliderFence = gameObject.AddComponent<MeshCollider>();
        Rigidbody rbFence = gameObject.AddComponent<Rigidbody>();
        rbFence.isKinematic = true;
        meshColliderFence.sharedMesh = gameObject.GetComponent<MeshFilter>().mesh;

       float myCollHeight = hoehe*0.5f + 30f;
       float myCollWidth = 2f;
       myColl.center= new Vector3(myCollWidth *0.5f, myCollHeight*0.5f , fenceLen * 2.5f);
       //myColl.transform.Translate (new Vector3(myCollWidth * 0.5f, myCollHeight * 0.5f, fenceLen * 0.5f));
       myColl.size = new Vector3(myCollWidth, myCollHeight, fenceLen * 5 );

        myColl.isTrigger = false;

    }



    Vector3 getNormalesFence(Vector3 a, Vector3 b, Vector3 c)
    {  // Normalenberechnung



        Vector3 ab = b - a;                                 // Berechnung Vektor ab
        Vector3 ac = c - a;                                 // Berechnung Vektor ac
        return Vector3.Cross(ab, ac).normalized;            // Kreuzprodukt fuer Normalenberechnung
    }




  void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Player")
        {
            if (touch != true)
            {
                minuspunkte += abzug;
                Debug.Log("Punktabzug: 'Autsch, das war ein Heuballen!'");
                touch = true;
                sheep = GetComponent<AudioSource>();
                sheep.Play();

            }

        }
    }




}