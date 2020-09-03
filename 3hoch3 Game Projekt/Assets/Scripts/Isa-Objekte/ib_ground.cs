using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_ground : MonoBehaviour
{
    Mesh mesh;                              
    Renderer rend;
    MeshCollider meshCollider;
    public float laenge = 360f; 
    // Rigidbody rb;
                          
    public List<int> faces;
    public List<Vector3> vertices, normals;
    public List<Vector2> uv;
    int counter = 0;

    // Abschnitt 1
    Vector3 floorPos;

    // Material
    public Material groundMat;



    // Start is called before the first frame update
    void Start()

    {
        //  Listen 
        faces = new List<int>();
        vertices = new List<Vector3>();
        normals = new List<Vector3>();
        uv = new List<Vector2>();

        // MeshFilterer
        mesh = new Mesh();
        gameObject.AddComponent<MeshFilter>();
        gameObject.GetComponent<MeshFilter>().mesh = mesh;

        mesh.Clear();

        //MeshRenderer + Material
        gameObject.AddComponent<MeshRenderer>(); 
        rend = gameObject.GetComponent<Renderer>();
        rend.material = groundMat;

        //MeshCollider
        meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = gameObject.GetComponent<MeshFilter>().mesh;
 
        Vector3 floor1Pos = new Vector3(-24f, -1.5f, 0);
        buildFloor(floor1Pos, laenge, 24f);
        showFloor();  

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void createFaces(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
        Vector3 normale = getNormales(c, b, a);                     // Normale berechnen lassen: wie Dreieck I (Reihenfolge)
        vertices.Add(a); normals.Add(normale); uv.Add(new Vector2(0.0f, 0.0f));
        vertices.Add(b); normals.Add(normale); uv.Add(new Vector2(1.0f, 0.0f));
        vertices.Add(c); normals.Add(normale); uv.Add(new Vector2(1.0f, 1.0f));
        vertices.Add(d); normals.Add(normale); uv.Add(new Vector2(0.0f, 1.0f));

        faces.Add(counter  + 0);                                    // Dreieck I
        faces.Add(counter  + 2);
        faces.Add(counter  + 1);
        faces.Add(counter  + 0);                                    // Dreieck II
        faces.Add(counter  + 3);
        faces.Add(counter  + 2);

        counter += 4;
    }

     void buildFloor (Vector3 pos, float breite, float laenge)
    {                                                               // Aufbau eines Wuerfels / Pfahls aus Grundflaeche
        Vector3 a = new Vector3(laenge, 0f, breite) + pos;          // Boden: entgegen dem Uhrzeigersinn
        Vector3 b = new Vector3(-laenge, 0f, breite) + pos;
        Vector3 c = new Vector3(-laenge, 0f, 0) + pos;
        Vector3 d = new Vector3(laenge, 0f, 0) + pos;
        float hoehe = 1f;
        Vector3 e = new Vector3(laenge, hoehe, breite) + pos;      // Decke: entgegen dem Uhrzeigersinn 
        Vector3 f = new Vector3(-laenge, hoehe, breite) + pos;
        Vector3 g = new Vector3(-laenge, hoehe, 0) + pos;
        Vector3 h = new Vector3(laenge, hoehe, 0) + pos;
        createFaces(a, d, c, b);                                  // Zusammensetzen des Wuerfels / Pfahls
        createFaces(e, f, g, h);
        createFaces(a, e, h, d);
        createFaces(b, c, g, f);
        createFaces(c, d, h, g);
        createFaces(a, b, f, e);
    }
    public Vector3 getNormales(Vector3 a, Vector3 b, Vector3 c)
    {  // Normalenberechnung
        Vector3 ab = b - a;                                     // Berechnung Vektor ab
        Vector3 ac = c - a;                                     // Berechnung Vektor ac
        return Vector3.Cross(ab, ac).normalized;                // Kreuzprodukt fuer Normalenberechnung
    }

void showFloor()
    {
        mesh.vertices = vertices.ToArray();
        mesh.normals = normals.ToArray();
        mesh.triangles = faces.ToArray();
        mesh.uv = uv.ToArray();
        gameObject.GetComponent<MeshFilter>().mesh = mesh;

        MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
        Rigidbody rbGround = gameObject.AddComponent<Rigidbody>();
        rbGround.isKinematic = true;
        meshCollider.sharedMesh = gameObject.GetComponent<MeshFilter>().mesh;
    }
}


