using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_hayBaleVar : MonoBehaviour
{
    Mesh mesh;
    Renderer rend;
   BoxCollider boxCollider;
    //MeshCollider meshCollider;
    // Rigidbody rb;
    // float mass = 1000f;
    public AudioSource sheep;

    public List<int> faces;
    public List<Vector3> vertices, normals;
    public List<Vector2> uv;
    int counter = 0;

    public int abzug = -50;
    private bool touch = false;
    public static int minuspunkte = 0;

    // fixe Variablen Groesse
    public static float[] length = new float[5] {2f, 2.33f, 2.66f, 2.9f, 3.1f };
    public int index;

    public static float baleHeight = 3f;
    public static float baleLength = 3f;
    public static float baleWidth = 8f;

    
    public Material hayMat;

    // Start is called before the first frame update
    void Start()
    {
    index = Random.Range(0,5);

        // Listen
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
        rend.material = hayMat;

        Vector3 balesPos1 = new Vector3(0, -0.5f, 0);
        buildBales(balesPos1, length[index], baleWidth, baleHeight);
        showBales();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void createFaces(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
        Vector3 normale = getNormalesBales(c, b, a);            // Normale berechnen lassen: wie Dreieck I (Reihenfolge)
        vertices.Add(a); normals.Add(normale); uv.Add(new Vector2(1.0f, 1.0f));
        vertices.Add(b); normals.Add(normale); uv.Add(new Vector2(1.0f, 0.0f));
        vertices.Add(c); normals.Add(normale); uv.Add(new Vector2(0.0f, 0.0f));
        vertices.Add(d); normals.Add(normale); uv.Add(new Vector2(0.0f, 1.0f));

        faces.Add(counter + 2);                       // Dreieck I
        faces.Add(counter + 1);
        faces.Add(counter + 0);
        faces.Add(counter + 0);                       // Dreieck II
        faces.Add(counter + 3);
        faces.Add(counter + 2);

        counter += 4;
    }

    public void buildBales(Vector3 pos, float laenge, float breite, float hoehe)
    {                                                                                   // Aufbau eines Wuerfels / Ballen aus Grundflaeche
        Vector3 a = new Vector3(breite, 0f, laenge) + pos;                              // Boden: entgegen dem Uhrzeigersinn
        Vector3 b = new Vector3(-breite, 0f, laenge) + pos;
        Vector3 c = new Vector3(-breite, 0f, -laenge) + pos;
        Vector3 d = new Vector3(breite, 0f, -laenge) + pos;

        Vector3 e = new Vector3(breite, hoehe, laenge) + pos;                           // Decke: entgegen dem Uhrzeigersinn 
        Vector3 f = new Vector3(-breite, hoehe, laenge) + pos;
        Vector3 g = new Vector3(-breite, hoehe, -laenge) + pos;
        Vector3 h = new Vector3(breite, hoehe, -laenge) + pos;
        createFaces(a, d, c, b);                                                        // Zusammensetzen des Wuerfels / Pfahls
        createFaces(e, f, g, h);
        createFaces(a, b, f, e);
        createFaces(b, c, g, f);
        createFaces(c, d, h, g);
        createFaces(d, a, e, h);
    }

    public void showBales()
    {
        mesh.vertices = vertices.ToArray();
        mesh.normals = normals.ToArray();
        mesh.triangles = faces.ToArray();
        mesh.uv = uv.ToArray();

      //meshCollider = gameObject.AddComponent<MeshCollider>();               // untauglich, erkennt keine Collision
      // Viele verschiedene Einstellungen gewählt, bisher keine optimale gefunden  
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(2 * baleWidth + 0.2f, baleHeight - 0.2f, 2 * length[index] - 0.2f);
        //boxCollider.size = new Vector3(2 * baleWidth+0.2f, baleHeight -0.75f, 2 * length[index]-0.75f);
        // boxCollider.size = new Vector3(2 * baleWidth - 1f, baleHeight - 1f, 2 * length[index] - 1f);
    }

    public Vector3 getNormalesBales(Vector3 a, Vector3 b, Vector3 c)
    {  // Normalenberechnung
        Vector3 ab = b - a;                                 // Berechnung Vektor ab
        Vector3 ac = c - a;                                 // Berechnung Vektor ac
        return Vector3.Cross(ab, ac).normalized;            // Kreuzprodukt fuer Normalenberechnung
    }


    void OnCollisionEnter(Collision otherObj)               // Alternativ: OnTriggerEnter - hat nicht funktioniert
    {
         if (otherObj.gameObject.tag == "Player" || otherObj.gameObject.name == "Kopf" || otherObj.gameObject.name == "beineVorn" )  // MeshCollider-Schaf reagiert zu "senibel mit Heuballen (Mesh-Collider ODER Box-Collider - auch bei Größenregulierung nach unten
        //if (otherObj.gameObject.tag == "PlayerColl")
        //if (otherObj.gameObject.name == "Kopf" || otherObj.gameObject.name == "beineVorn" || otherObj.gameObject.name == "beineHinten" || otherObj.gameObject.name == "Koerper")
        {
            
            if (touch != true)
            {
                // minuspunkte += abzug;
                ib_StaticVar._score += abzug;
                Debug.Log("Punktabzug: 'Autsch, das war ein Heuballen!'");
                touch = true;
                sheep = GetComponent<AudioSource>();
                sheep.Play();

            }

        }
    }
}
