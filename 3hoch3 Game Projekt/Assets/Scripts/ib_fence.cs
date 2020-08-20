using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_fence : MonoBehaviour
{

    // Zaun
    Vector3 fencePos;
  //  public GameObject fence;                    // fence
    Mesh meshFence;                               // stakes
    public List<int> facesFence;
    public List<Vector3> verticesFence, normalsFence;
    public List<Vector2> uvFence;
    int counterFence = 0;

    public Material fenceMat;


    // Start is called before the first frame update
    void Start()
    {
        // building the fence
        verticesFence = new List<Vector3>();
        facesFence = new List<int>();
        normalsFence = new List<Vector3>();
        uvFence = new List<Vector2>();

        //fence = new GameObject(); fence.name = "fence";

        // Mesh and Renderer 
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();


        float fenceLen = 96f;
        for (int i = 0; i < fenceLen; i++)
        {
            Vector3 fencePos = new Vector3(0, 0, 5 * i);
            buildStakes(fencePos);
        }
        Vector3 stakesPos1 = new Vector3(0, 5, -1.5f);
        buildBars(stakesPos1, fenceLen*5f );
        Vector3 stakesPos2 = new Vector3(0, 10, -1.5f);
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
    {                                                   // Aufbau eines Wuerfels / Pfahls aus Grundflaeche
        Vector3 a = new Vector3(1f, 0f, 1f) + pos;      // Boden: entgegen dem Uhrzeigersinn
        Vector3 b = new Vector3(-1f, 0f, 1f) + pos;
        Vector3 c = new Vector3(-1f, 0f, -1f) + pos;
        Vector3 d = new Vector3(1f, 0f, -1f) + pos;
        float hoehe = 13f;
        Vector3 e = new Vector3(1f, hoehe, 1f) + pos;  // Decke: entgegen dem Uhrzeigersinn 
        Vector3 f = new Vector3(-1f, hoehe, 1f) + pos;
        Vector3 g = new Vector3(-1f, hoehe, -1f) + pos;
        Vector3 h = new Vector3(1f, hoehe, -1f) + pos;
        createStakeFaces(a, b, c, d);                    // Zusammensetzen des Wuerfels / Pfahls
        createStakeFaces(e, f, g, h);
        createStakeFaces(a, e, h, d);
        createStakeFaces(b, c, g, f);
        createStakeFaces(c, d, h, g);
        createStakeFaces(a, b, f, e);
    }

    void buildBars(Vector3 pos, float length)
    {                                                   // Aufbau eines Wuerfels / Pfahls aus Grundflaeche
        Vector3 a = new Vector3(1f, 0f, length) + pos;      // Boden: entgegen dem Uhrzeigersinn
        Vector3 b = new Vector3(-1f, 0f, length) + pos;
        Vector3 c = new Vector3(-1f, 0f, 0) + pos;
        Vector3 d = new Vector3(1f, 0f, 0) + pos;
        float hoehe = 1f;
        Vector3 e = new Vector3(1f, hoehe, length) + pos;  // Decke: entgegen dem Uhrzeigersinn 
        Vector3 f = new Vector3(-1f, hoehe, length) + pos;
        Vector3 g = new Vector3(-1f, hoehe, 0) + pos;
        Vector3 h = new Vector3(1f, hoehe, 0) + pos;
        createStakeFaces(a, b, c, d);                    // Zusammensetzen des Wuerfels / Pfahls
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

        MeshCollider meshColliderFence = gameObject.AddComponent<MeshCollider>();
        Rigidbody rbFence = gameObject.AddComponent<Rigidbody>();
        rbFence.isKinematic = true;
        meshColliderFence.sharedMesh = gameObject.GetComponent<MeshFilter>().mesh;
    }



    Vector3 getNormalesFence(Vector3 a, Vector3 b, Vector3 c)
    {  // Normalenberechnung
        Vector3 ab = b - a;                                 // Berechnung Vektor ab
        Vector3 ac = c - a;                                 // Berechnung Vektor ac
        return Vector3.Cross(ab, ac).normalized;            // Kreuzprodukt fuer Normalenberechnung
    }








}