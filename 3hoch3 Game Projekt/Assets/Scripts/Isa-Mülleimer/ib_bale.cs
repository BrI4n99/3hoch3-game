using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_bale : MonoBehaviour
{

/*
    Mesh meshBales;                              
    public List<int> facesBales;
    public List<Vector3> verticesBales, normalsBales;
    public List<Vector2> uvBales;
    int counterBales = 0;

    public Material baleMat; */

    // Start is called before the first frame update
    void Start()
    {

        /*
       // building bales
        verticesBales = new List<Vector3>();
        facesBales = new List<int>();
        normalsBales = new List<Vector3>();
        uvBales = new List<Vector2>();
     // Mesh and Renderer 
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>(); 


        float baleHeight = 3f;
        float baleLength = 3f;
        float baleWidth = 8f;
     
        Vector3 balesPos1 = new Vector3(-40, 0, 140);
        buildBales(balesPos1, baleLength, baleWidth, baleHeight);

        Vector3 balesPos2 = new Vector3(-24, 0, 140);
        buildBales(balesPos2,  baleLength, baleWidth, baleHeight);

        Vector3 balesPos3 = new Vector3(-40, 0, 25);
        buildBales(balesPos3,  baleLength, baleWidth, baleHeight);

        Vector3 balesPos4 = new Vector3(-8, 0, 50);
        buildBales(balesPos4,  baleLength, baleWidth, baleHeight);

        Vector3 balesPos5 = new Vector3(-40, 0, 75);
        buildBales(balesPos5,  baleLength, baleWidth, baleHeight);

        Vector3 balesPos6 = new Vector3(-8, 0, 100);
        buildBales(balesPos6,  baleLength, baleWidth, baleHeight);

        Vector3 balesPos7 = new Vector3(-8, 0, 275);
        buildBales(balesPos7,  baleLength, baleWidth, baleHeight);

        Vector3 balesPos8 = new Vector3(-40, 0, 300);
        buildBales(balesPos8,  baleLength, baleWidth, baleHeight);


        // Pyramide
        float posPyr = 190f;
        Vector3 balesPos9 = new Vector3(-8, 0, posPyr);                // unten rechts
        buildBales(balesPos9,  baleLength, baleWidth, baleHeight);
        Vector3 balesPos10 = new Vector3(-24, 0, posPyr);              // unten mittig
        buildBales(balesPos10,  baleLength, baleWidth, baleHeight); 
        Vector3 balesPos11 = new Vector3(-40, 0, posPyr);               //unten links  
        buildBales(balesPos11,  baleLength, baleWidth, baleHeight);     
        Vector3 balesPos12 = new Vector3(-32, baleHeight, posPyr);      //mittig links  
        buildBales(balesPos12,  baleLength, baleWidth, baleHeight);     
        Vector3 balesPos13 = new Vector3(-16, baleHeight, posPyr);      //mittig rechts  
        buildBales(balesPos13,  baleLength, baleWidth, baleHeight);  
        Vector3 balesPos14 = new Vector3(-24, baleHeight*2, posPyr);    // oben mittig
        buildBales(balesPos14,  baleLength, baleWidth, baleHeight); 

        // Kugel hinzufügen
        // Kugel anschubsen; Rigidbody zu Kugel hinzufügen, Kraft
        // Wenn Kugel Heuballen (unten, mittig) trifft, dann verschwindet der Heuballen und die 3 darüberlagernden
        // Collider     


        showBales();

   
        Renderer baleRend = gameObject.GetComponent<Renderer>();
        baleRend.material = baleMat;

        */


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    public void createBalesFaces(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
        Vector3 normale = getNormalesBales(c, b, a);         // Normale berechnen lassen: wie Dreieck I (Reihenfolge)
        verticesBales.Add(a); normalsBales.Add(normale); uvBales.Add(new Vector2(1.0f, 1.0f));
        verticesBales.Add(b); normalsBales.Add(normale); uvBales.Add(new Vector2(1.0f, 0.0f));
        verticesBales.Add(c); normalsBales.Add(normale); uvBales.Add(new Vector2(0.0f, 0.0f));
        verticesBales.Add(d); normalsBales.Add(normale); uvBales.Add(new Vector2(0.0f, 1.0f));

        facesBales.Add(counterBales + 2);                 // Dreieck I
        facesBales.Add(counterBales + 1);
        facesBales.Add(counterBales + 0);
        facesBales.Add(counterBales + 0);                 // Dreieck II
        facesBales.Add(counterBales + 3);
        facesBales.Add(counterBales + 2);

        counterBales += 4;
    }

    public void buildBales(Vector3 pos, float laenge, float breite, float hoehe)
    {                                                   // Aufbau eines Wuerfels / Ballen aus Grundflaeche
        Vector3 a = new Vector3(breite, 0f, laenge) + pos;      // Boden: entgegen dem Uhrzeigersinn
        Vector3 b = new Vector3(-breite, 0f, laenge) + pos;
        Vector3 c = new Vector3(-breite, 0f, -laenge) + pos;
        Vector3 d = new Vector3(breite, 0f, -laenge) + pos;
        
        Vector3 e = new Vector3(breite, hoehe, laenge) + pos;  // Decke: entgegen dem Uhrzeigersinn 
        Vector3 f = new Vector3(-breite, hoehe, laenge) + pos;
        Vector3 g = new Vector3(-breite, hoehe, -laenge) + pos;
        Vector3 h = new Vector3(breite, hoehe, -laenge) + pos;
        createBalesFaces(a, d, c, b);                    // Zusammensetzen des Wuerfels / Pfahls
        createBalesFaces(e, f, g, h);
        createBalesFaces(a, b, f, e);
        createBalesFaces(b, c, g, f);
        createBalesFaces(c, d, h, g);
        createBalesFaces(d, a, e, h);
    }

public void showBales()
    {
        meshBales = new Mesh();
        meshBales.vertices = verticesBales.ToArray();
        meshBales.normals = normalsBales.ToArray();
        meshBales.triangles = facesBales.ToArray();
        meshBales.uv = uvBales.ToArray();
        gameObject.GetComponent<MeshFilter>().mesh = meshBales;

        MeshCollider meshColliderBales = gameObject.AddComponent<MeshCollider>();
        Rigidbody rbBales = gameObject.AddComponent<Rigidbody>();
        rbBales.isKinematic = true;
        meshColliderBales.sharedMesh = gameObject.GetComponent<MeshFilter>().mesh;
    }

    public Vector3 getNormalesBales(Vector3 a, Vector3 b, Vector3 c)
    {  // Normalenberechnung
        Vector3 ab = b - a;                                 // Berechnung Vektor ab
        Vector3 ac = c - a;                                 // Berechnung Vektor ac
        return Vector3.Cross(ab, ac).normalized;            // Kreuzprodukt fuer Normalenberechnung
    }
    */
    
}
