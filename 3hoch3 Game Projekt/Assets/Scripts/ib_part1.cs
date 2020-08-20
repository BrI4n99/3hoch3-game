using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_part1 : MonoBehaviour
{

    // Abschnitt1
    Vector3 floor1Pos;
    Mesh meshFloor;                             
    public List<int> facesFloor;
    public List<Vector3> verticesFloor, normalsFloor;
    public List<Vector2> uvFloor;
    int counterFloor = 0;

    // Kugel

    GameObject sphere1;

    //public Material floorMat;
    Renderer rendFloor;

    MeshCollider meshColliderFloor;

    // Start is called before the first frame update
    void Start()
    {
        sphere1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere1.transform.position =  new Vector3(-24, 1f, 165);
        sphere1.transform.localScale += new Vector3 (2f,2f,2f);

        Rigidbody rbSphere1 = sphere1.AddComponent<Rigidbody>();
        rbSphere1.isKinematic = true;


        meshFloor = new Mesh();
        gameObject.AddComponent<MeshFilter>();
        gameObject.GetComponent<MeshFilter>().mesh = meshFloor;

        meshFloor.Clear();

        // Renderer
        gameObject.AddComponent<MeshRenderer>();
        rendFloor= gameObject.GetComponent<MeshRenderer>();

        // Material
        //rendFloor.materials = floorMat;

        //Mesh Collider
        meshColliderFloor = gameObject.AddComponent<MeshCollider>();
        meshColliderFloor.sharedMesh = meshFloor;

        Vector3 floor1Pos = new Vector3(-24f, -1.5f, 0);
        buildFloor(floor1Pos, 480f, 24f);
        showFloor();

       // Vector3 bale1Pos = new Vector3(-24, 0, 200);
        // public static Object Instantiate(bale, bale1Pos);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void createFaces(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
        Vector3 normale = getNormales(c, b, a);         // Normale berechnen lassen: wie Dreieck I (Reihenfolge)
        verticesFloor.Add(a); normalsFloor.Add(normale); uvFloor.Add(new Vector2(0.0f, 0.0f));
        verticesFloor.Add(b); normalsFloor.Add(normale); uvFloor.Add(new Vector2(1.0f, 0.0f));
        verticesFloor.Add(c); normalsFloor.Add(normale); uvFloor.Add(new Vector2(1.0f, 1.0f));
        verticesFloor.Add(d); normalsFloor.Add(normale); uvFloor.Add(new Vector2(0.0f, 1.0f));

        facesFloor.Add(counterFloor + 0);                 // Dreieck I
        facesFloor.Add(counterFloor + 2);
        facesFloor.Add(counterFloor + 1);
        facesFloor.Add(counterFloor+ 0);                 // Dreieck II
        facesFloor.Add(counterFloor + 3);
        facesFloor.Add(counterFloor + 2);

        counterFloor += 4;
    }


     void buildFloor (Vector3 pos, float breite, float laenge)
    {                                                   // Aufbau eines Wuerfels / Pfahls aus Grundflaeche
        Vector3 a = new Vector3(laenge, 0f, breite) + pos;      // Boden: entgegen dem Uhrzeigersinn
        Vector3 b = new Vector3(-laenge, 0f, breite) + pos;
        Vector3 c = new Vector3(-laenge, 0f, 0) + pos;
        Vector3 d = new Vector3(laenge, 0f, 0) + pos;
        float hoehe = 1f;
        Vector3 e = new Vector3(laenge, hoehe, breite) + pos;  // Decke: entgegen dem Uhrzeigersinn 
        Vector3 f = new Vector3(-laenge, hoehe, breite) + pos;
        Vector3 g = new Vector3(-laenge, hoehe, 0) + pos;
        Vector3 h = new Vector3(laenge, hoehe, 0) + pos;
        createFaces(a, b, c, d);                    // Zusammensetzen des Wuerfels / Pfahls
        createFaces(e, f, g, h);
        createFaces(a, e, h, d);
        createFaces(b, c, g, f);
        createFaces(c, d, h, g);
        createFaces(a, b, f, e);
    }
    public Vector3 getNormales(Vector3 a, Vector3 b, Vector3 c)
    {  // Normalenberechnung
        Vector3 ab = b - a;                                 // Berechnung Vektor ab
        Vector3 ac = c - a;                                 // Berechnung Vektor ac
        return Vector3.Cross(ab, ac).normalized;            // Kreuzprodukt fuer Normalenberechnung
    }

void showFloor()
    {
        meshFloor = new Mesh();
        meshFloor.vertices = verticesFloor.ToArray();
        meshFloor.normals = normalsFloor.ToArray();
        meshFloor.triangles = facesFloor.ToArray();
        meshFloor.uv = uvFloor.ToArray();
        gameObject.GetComponent<MeshFilter>().mesh = meshFloor;

        MeshCollider meshColliderFloor = gameObject.AddComponent<MeshCollider>();
        Rigidbody rbFloor = gameObject.AddComponent<Rigidbody>();
        rbFloor.isKinematic = true;
        meshColliderFloor.sharedMesh = gameObject.GetComponent<MeshFilter>().mesh;
    }
}
