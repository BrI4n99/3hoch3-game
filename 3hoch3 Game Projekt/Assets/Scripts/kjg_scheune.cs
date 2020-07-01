using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_scheune : MonoBehaviour
{
    Mesh scheune;
    GameObject haus;
    public Material matScheune;

    List<Vector3> verticesWand = new List<Vector3>(); //Punkte 
    List<int> trianglesWand = new List<int>(); //Dreiecke bzw. Spur
    List<Vector3> normalsWand = new List<Vector3>(); //Liste für Normalen
    List<Vector2> uvScheune = new List<Vector2>(); //Liste für UV-Koordinaten

    void scheuneErstellen()
    {
        //----------------------------------VERTICES----------------------------------------

        //Vorne
        verticesWand.Add(new Vector3(-2, 3, 0));        // oben vorne links        0
        verticesWand.Add(new Vector3(2, 3, 0));         // oben vorne rechts       1
        verticesWand.Add(new Vector3(-2, 0, 0));        // unten vorne links       2  
        verticesWand.Add(new Vector3(2, 0, 0));         // unten vorne rechts      3

        //Hinten
        verticesWand.Add(new Vector3(-2, 3, 5));        // oben hinten links       4
        verticesWand.Add(new Vector3(2, 3, 5));         // oben hinten rechts      5
        verticesWand.Add(new Vector3(-2, 0, 5));        // unten hinten links      6
        verticesWand.Add(new Vector3(2, 0, 5));         // unten hinten rechts     7 

        //Rechts
        verticesWand.Add(new Vector3(2, 3, 0));         // oben vorne rechts       8 (1)
        verticesWand.Add(new Vector3(2, 0, 0));         // unten vorne rechts      9 (3)
        verticesWand.Add(new Vector3(2, 3, 5));         // oben hinten rechts     10 (5)
        verticesWand.Add(new Vector3(2, 0, 5));         // unten hinten rechts    11 (7)

        //Links
        verticesWand.Add(new Vector3(-2, 3, 0));        // oben vorne links       12 (0)
        verticesWand.Add(new Vector3(-2, 0, 0));        // unten vorne links      13 (2)
        verticesWand.Add(new Vector3(-2, 3, 5));        // oben hinten links      14 (4)
        verticesWand.Add(new Vector3(-2, 0, 5));        // unten hinten links     15 (6)

        //Dach links
        verticesWand.Add(new Vector3(-2.2f, 3, -0.2f)); // oben vorne links       16 (0)
        verticesWand.Add(new Vector3(-2.2f, 3, 5.2f));  // oben hinten links      17 (4)
        verticesWand.Add(new Vector3(0, 5, -0.2f));     // oben mitte vorne       18 (8)
        verticesWand.Add(new Vector3(0, 5, 5.2f));      // oben mitte hinten      19 (9) 

        //Dach rechts
        verticesWand.Add(new Vector3(0, 5, -0.2f));     // oben mitte vorne       20 (8)
        verticesWand.Add(new Vector3(0, 5, 5.2f));      // oben mitte hinten      21 (9) 
        verticesWand.Add(new Vector3(2.2f, 3, -0.2f));  // oben vorne rechts      22 (1)
        verticesWand.Add(new Vector3(2.2f, 3, 5.2f));   // oben hinten rechts     23 (5)

        //----------------------------------TRIANGLES----------------------------------------

        //Vorne oben innen
        trianglesWand.Add(2);
        trianglesWand.Add(1);
        trianglesWand.Add(0);

        //Vorne unten innen
        trianglesWand.Add(3);
        trianglesWand.Add(1);
        trianglesWand.Add(2);

        //Vorne oben außen
        trianglesWand.Add(1);
        trianglesWand.Add(2);
        trianglesWand.Add(0);

        //Vorne unten außen
        trianglesWand.Add(3);
        trianglesWand.Add(2);
        trianglesWand.Add(1);

        //hinten oben innen
        trianglesWand.Add(7);
        trianglesWand.Add(4);
        trianglesWand.Add(5);

        //hinten unten innen
        trianglesWand.Add(6);
        trianglesWand.Add(4);
        trianglesWand.Add(7);

        //hinten oben außen
        trianglesWand.Add(4);
        trianglesWand.Add(7);
        trianglesWand.Add(5);

        //hinten unten außen
        trianglesWand.Add(6);
        trianglesWand.Add(7);
        trianglesWand.Add(4);

        //rechts oben innen
        trianglesWand.Add(9);
        trianglesWand.Add(10);
        trianglesWand.Add(8);

        //rechts unten innen
        trianglesWand.Add(11);
        trianglesWand.Add(10);
        trianglesWand.Add(9);

        //rechts oben außen
        trianglesWand.Add(10);
        trianglesWand.Add(9);
        trianglesWand.Add(8);

        //rechts unten außen
        trianglesWand.Add(11);
        trianglesWand.Add(9);
        trianglesWand.Add(10);

        //links oben innen
        trianglesWand.Add(15);
        trianglesWand.Add(12);
        trianglesWand.Add(14);

        //links unten innen
        trianglesWand.Add(13);
        trianglesWand.Add(12);
        trianglesWand.Add(15);

        //links oben außen
        trianglesWand.Add(12);
        trianglesWand.Add(15);
        trianglesWand.Add(14);

        //links unten außen
        trianglesWand.Add(13);
        trianglesWand.Add(15);
        trianglesWand.Add(12);

        //Dach links oben außen
        trianglesWand.Add(17);
        trianglesWand.Add(19);
        trianglesWand.Add(18);

        //Dach links unten außen
        trianglesWand.Add(17);
        trianglesWand.Add(18);
        trianglesWand.Add(16);

        //Dach links oben innen
        trianglesWand.Add(18);
        trianglesWand.Add(19);
        trianglesWand.Add(17);

        //Dach links unten innen
        trianglesWand.Add(16);
        trianglesWand.Add(18);
        trianglesWand.Add(17);

        //Dach rechts oben innen
        trianglesWand.Add(22);
        trianglesWand.Add(21);
        trianglesWand.Add(20);

        //Dach rechts unten außen
        trianglesWand.Add(22);
        trianglesWand.Add(21);
        trianglesWand.Add(23);

        //Dach rechts oben außen
        trianglesWand.Add(20);
        trianglesWand.Add(21);
        trianglesWand.Add(22);

        //Dach rechts unten innen
        trianglesWand.Add(23);
        trianglesWand.Add(21);
        trianglesWand.Add(22);

        //----------------------------------UV KOORDINATEN----------------------------------------

        //Seite1 Vorne
        uvScheune.Add(new Vector2(0, 1));
        uvScheune.Add(new Vector2(1, 1));
        uvScheune.Add(new Vector2(0, 0));
        uvScheune.Add(new Vector2(1, 0));

        //Seite 2 Hinten
        uvScheune.Add(new Vector2(1, 1));
        uvScheune.Add(new Vector2(0, 1));
        uvScheune.Add(new Vector2(1, 0));
        uvScheune.Add(new Vector2(0, 0));

        //Seite 3 Links
        uvScheune.Add(new Vector2(1, 1));
        uvScheune.Add(new Vector2(1, 0));
        uvScheune.Add(new Vector2(0, 1));
        uvScheune.Add(new Vector2(0, 0));

        //Seite 4 Rechts
        uvScheune.Add(new Vector2(0, 1));
        uvScheune.Add(new Vector2(0, 0));
        uvScheune.Add(new Vector2(1, 1));
        uvScheune.Add(new Vector2(1, 0));

        //Seite 5 Dach links
        uvScheune.Add(new Vector2(1, 0));
        uvScheune.Add(new Vector2(0, 0));
        uvScheune.Add(new Vector2(1, 1));
        uvScheune.Add(new Vector2(0, 0));

        //Seite 6 Dach rechts
        uvScheune.Add(new Vector2(0, 1));
        uvScheune.Add(new Vector2(1, 1));
        uvScheune.Add(new Vector2(0, 0));
        uvScheune.Add(new Vector2(1, 0));

    }

    // Start is called before the first frame update
    void Start()
    {
        scheuneErstellen();

        scheune = new Mesh();
        haus = new GameObject("Haus");

        haus.AddComponent<MeshFilter>();
        haus.AddComponent<MeshRenderer>();
        haus.GetComponent<MeshFilter>().mesh = scheune;

        //Texturierung
        Renderer rendScheune = haus.GetComponent<Renderer>();
        rendScheune.material = matScheune;
        matScheune = haus.GetComponent<Renderer>().material;
       
        //Texture textureScheune = Resources.Load("1") as Texture;
        //rendScheune.material.mainTexture = textureScheune;
        /*Renderer rendScheune = haus.GetComponent<Renderer>();
        rendScheune.material = new Material(Shader.Find("Unlit"));
        Texture textureScheune = Resources.Load("1") as Texture;
        rendScheune.material.mainTexture = textureScheune;*/

        scheune.Clear();

        scheune.vertices = verticesWand.ToArray();
        scheune.triangles = trianglesWand.ToArray();
        scheune.uv = uvScheune.ToArray();
        scheune.RecalculateNormals();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
