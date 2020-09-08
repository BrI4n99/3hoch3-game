using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_fenceFlex : MonoBehaviour
{

    // Zaun
    Vector3 fencePos;
    public AudioSource sheep;
    public float fenceLen = 72;
    public float[] hoehe;
    public float[] abstand;
    public float[] dicke;

    public float waitingTime;

    public static int index;

    Mesh meshFence;                               // stakes
    public List<int> facesFence;
    public List<Vector3> verticesFence, normalsFence;
    public List<Vector2> uvFence;
    int counterFence = 0;

    public Material fenceMat;

    public int abzug = -25;
    private bool touch = false;
    public static int minuspunkte = 0;


    // Start is called before the first frame update
    void Start()
    {
        // Zaun dynamisch verändern
        index = (int)Random.Range(1, 5);
        hoehe = new float[6] { 13f, 11f, 9f, 3f, 3f, 3f };
        abstand = new float[6] { 5f, 4f, 3.2f, 1.1f, 1.1f, 1.1f };
        dicke = new float[6] { 0.9f, 0.8f, 0.7f, 0.5f, 0.5f, 0.5f };

        // building the fence
        verticesFence = new List<Vector3>();
        facesFence = new List<int>();
        normalsFence = new List<Vector3>();
        uvFence = new List<Vector2>();

        //fence = new GameObject(); fence.name = "fence";

        // Mesh and Renderer 
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        /*
        for (int i = 0; i < fenceLen; i++)
        {
            Vector3 fencePos = new Vector3(0, 0, 5 * i);
            buildStakes(fencePos);

            Vector3 stakesPos1 = new Vector3(0, abstand[index], -1.5f + 5*i);
            buildBars(stakesPos1, 1 * 5f);
            Vector3 stakesPos2 = new Vector3(0, abstand[index] * 2, -1.5f + 5 * i);
            buildBars(stakesPos2, 1 * 5f);

        }*/
        //Vector3 stakesPos1 = new Vector3(0, abstand[index], -1.5f);
        //buildBars(stakesPos1, fenceLen*5f );
        //Vector3 stakesPos2 = new Vector3(0, abstand[index]*2, -1.5f);
        //buildBars(stakesPos2, fenceLen*5f);


        Renderer fenceRend = gameObject.GetComponent<Renderer>();
        fenceRend.material = fenceMat;

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(createFence());
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

        // Aufbau eines Wuerfels / Pfahls aus Grundflaeche
        Vector3 a = new Vector3(1f, 0f, 1f) + pos;      // Boden: entgegen dem Uhrzeigersinn
        Vector3 b = new Vector3(-1f, 0f, 1f) + pos;
        Vector3 c = new Vector3(-1f, 0f, -1f) + pos;
        Vector3 d = new Vector3(1f, 0f, -1f) + pos;
        float hoch = hoehe[index];
        Vector3 e = new Vector3(1f, hoch, 1f) + pos;  // Decke: entgegen dem Uhrzeigersinn 
        Vector3 f = new Vector3(-1f, hoch, 1f) + pos;
        Vector3 g = new Vector3(-1f, hoch, -1f) + pos;
        Vector3 h = new Vector3(1f, hoch, -1f) + pos;
        createStakeFaces(a, d, c, b);                    // Zusammensetzen des Wuerfels / Pfahls
        createStakeFaces(e, f, g, h);
        createStakeFaces(a, e, h, d);
        createStakeFaces(b, c, g, f);
        createStakeFaces(c, d, h, g);
        createStakeFaces(a, b, f, e);
        showFence();
    }

    void buildBars(Vector3 pos, float length)
    {

        float dick = dicke[index];                    // Aufbau eines Wuerfels / Pfahls aus Grundflaeche
        Vector3 a = new Vector3(dick, 0f, length) + pos;      // Boden: entgegen dem Uhrzeigersinn
        Vector3 b = new Vector3(-dick, 0f, length) + pos;
        Vector3 c = new Vector3(-dick, 0f, 0) + pos;
        Vector3 d = new Vector3(dick, 0f, 0) + pos;
        float hoehe = dick;
        Vector3 e = new Vector3(dick, hoehe, length) + pos;  // Decke: entgegen dem Uhrzeigersinn 
        Vector3 f = new Vector3(-dick, hoehe, length) + pos;
        Vector3 g = new Vector3(-dick, hoehe, 0) + pos;
        Vector3 h = new Vector3(dick, hoehe, 0) + pos;
        createStakeFaces(a, d, c, b);                    // Zusammensetzen des Wuerfels / Pfahls
        createStakeFaces(e, f, g, h);
        createStakeFaces(a, e, h, d);
        createStakeFaces(b, c, g, f);
        createStakeFaces(c, d, h, g);
        createStakeFaces(a, b, f, e);
        showFence();
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
        //Rigidbody rbFence = gameObject.AddComponent<Rigidbody>();
        // gameObject.GetComponent<Rigidbody>();
        //rbFence.isKinematic = true;
        meshColliderFence.sharedMesh = gameObject.GetComponent<MeshFilter>().mesh;
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
    IEnumerator createFence()
    {
        for (int i = 0; i < fenceLen; i++)
        {
            Vector3 fencePos = new Vector3(0, 0, 5 * i);
            buildStakes(fencePos);

            Vector3 stakesPos1 = new Vector3(0, abstand[index], -1.5f + 5 * i);
            buildBars(stakesPos1, 1 * 5f);
            Vector3 stakesPos2 = new Vector3(0, abstand[index] * 2, -1.5f + 5 * i);
            buildBars(stakesPos2, 1 * 5f);
            yield return new WaitForSeconds(waitingTime);

        }

    }


}