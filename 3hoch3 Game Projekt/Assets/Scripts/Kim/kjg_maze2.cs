using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_maze2 : MonoBehaviour
{
    public GameObject wallTriggerObject;
    GameObject mazeObject;
    public Mesh maze;
    public Material matMaze;

    List<Vector3> verticesMaze = new List<Vector3>(); //Punkte 
    List<int> block = new List<int>(); //Dreiecke
    List<Vector3> normalsBlock = new List<Vector3>(); //Liste für Normalen
    List<Vector2> uvMaze = new List<Vector2>(); //Liste für UV-Koordinaten

    //collider
    MeshCollider mazeCollider;

    float laenge;
    float breite;

    int countMesh = 0;

    [SerializeField]
    kjg_wallTrigger wallTriggerScript;

    private bool wand;

    void addVertices(float x, float y, float z) {
        laenge = 1; //Random.Range(0.0f, 3.0f);
        breite = 1;

        //-----------------------------------------VERTICES---------------------------------------------------

        //Oben
        verticesMaze.Add(new Vector3(x, y, z + laenge)); //oben hinten links                 0
        verticesMaze.Add(new Vector3(x + breite, y, z + laenge)); //oben hinten rechts       1
        verticesMaze.Add(new Vector3(x, y, z)); //oben vorne links                           2
        verticesMaze.Add(new Vector3(x + breite, y, z)); //oben vorne rechts                 3

        //Boden 
        verticesMaze.Add(new Vector3(x, 0, z + laenge)); //unten hinten links                4
        verticesMaze.Add(new Vector3(x + breite, 0, z + laenge)); //unten hinten rechts      5
        verticesMaze.Add(new Vector3(x, 0, z)); //unten vorne links                          6
        verticesMaze.Add(new Vector3(x + breite, 0, z)); //unten vorne rechts                7

        //Seite vorne
        verticesMaze.Add(new Vector3(x, 0, z)); //unten vorne links                          8
        verticesMaze.Add(new Vector3(x, y, z)); //oben vorne links                           9
        verticesMaze.Add(new Vector3(x + breite, 0, z)); //unten vorne rechts               10
        verticesMaze.Add(new Vector3(x + breite, y, z)); //oben vorne rechts                11 

        //Seite rechts
        verticesMaze.Add(new Vector3(x + breite, 0, z)); //unten vorne rechts               12
        verticesMaze.Add(new Vector3(x + breite, y, z)); //oben vorne rechts                13 
        verticesMaze.Add(new Vector3(x + breite, 0, z + laenge)); //unten hinten rechts     14
        verticesMaze.Add(new Vector3(x + breite, y, z + laenge)); //oben hinten rechts      15

        //Seite hinten
        verticesMaze.Add(new Vector3(x + breite, 0, z + laenge)); //unten hinten rechts     16
        verticesMaze.Add(new Vector3(x + breite, y, z + laenge)); //oben hinten rechts      17
        verticesMaze.Add(new Vector3(x, y, z + laenge)); //oben hinten links                18
        verticesMaze.Add(new Vector3(x, 0, z + laenge)); //unten hinten links               19

        //Seite links
        verticesMaze.Add(new Vector3(x, 0, z + laenge)); //unten hinten links               20
        verticesMaze.Add(new Vector3(x, y, z + laenge)); //oben hinten links                21
        verticesMaze.Add(new Vector3(x, y, z)); //oben vorne links                          22
        verticesMaze.Add(new Vector3(x, 0, z)); //unten vorne links                         23

    }
    void createTrianglesAndUV() {
        //-----------------------------------------DREIECKE---------------------------------------------------

        //Dreieck1 Oben
        block.Add(countMesh + 2);
        block.Add(countMesh + 0);
        block.Add(countMesh + 3);

        //Dreieck2 Oben
        block.Add(countMesh + 3);
        block.Add(countMesh + 0);
        block.Add(countMesh + 1);

        //Dreieck3 Unten
        block.Add(countMesh + 4);
        block.Add(countMesh + 6);
        block.Add(countMesh + 7);

        //Dreieck4 Unten
        block.Add(countMesh + 4);
        block.Add(countMesh + 7);
        block.Add(countMesh + 5);

        //Dreieck5 Vorne
        block.Add(countMesh + 8);
        block.Add(countMesh + 9);
        block.Add(countMesh + 10);

        //Dreieck6 Vorne
        block.Add(countMesh + 10);
        block.Add(countMesh + 9);
        block.Add(countMesh + 11);

        //Dreieck7 Rechts
        block.Add(countMesh + 12);
        block.Add(countMesh + 13);
        block.Add(countMesh + 14);

        //Dreieck8 Rechts
        block.Add(countMesh + 14);
        block.Add(countMesh + 13);
        block.Add(countMesh + 15);

        //Dreieck9 Hinten
        block.Add(countMesh + 16);
        block.Add(countMesh + 17);
        block.Add(countMesh + 18);

        //Dreieck10 Hinten
        block.Add(countMesh + 16);
        block.Add(countMesh + 18);
        block.Add(countMesh + 19);

        //Dreieck11 Links
        block.Add(countMesh + 20);
        block.Add(countMesh + 21);
        block.Add(countMesh + 22);

        //Dreieck12 Links
        block.Add(countMesh + 23);
        block.Add(countMesh + 20);
        block.Add(countMesh + 22);

        //---------------------------------UV KOORDINATEN---------------------------------------------------

        //Seite1 Oben
        uvMaze.Add(new Vector2(0, 0));
        uvMaze.Add(new Vector2(1, 0));
        uvMaze.Add(new Vector2(0, 1));
        uvMaze.Add(new Vector2(1, 1));

        //Seite2 Unten
        uvMaze.Add(new Vector2(0, 0));
        uvMaze.Add(new Vector2(1, 0));
        uvMaze.Add(new Vector2(0, 1));
        uvMaze.Add(new Vector2(1, 1));

        //Seite3 Vorne
        uvMaze.Add(new Vector2(0, 0));
        uvMaze.Add(new Vector2(1, 0));
        uvMaze.Add(new Vector2(0, 1));
        uvMaze.Add(new Vector2(1, 1));

        //Seite4 Rechts
        uvMaze.Add(new Vector2(0, 0));
        uvMaze.Add(new Vector2(1, 0));
        uvMaze.Add(new Vector2(0, 1));
        uvMaze.Add(new Vector2(1, 1));

        //Seite5 Hinten
        uvMaze.Add(new Vector2(0, 1));
        uvMaze.Add(new Vector2(1, 1));
        uvMaze.Add(new Vector2(1, 0));
        uvMaze.Add(new Vector2(0, 0));

        //Seite6 Links
        uvMaze.Add(new Vector2(0, 0));
        uvMaze.Add(new Vector2(1, 0));
        uvMaze.Add(new Vector2(1, 1));
        uvMaze.Add(new Vector2(0, 1));
        countMesh += 24;

        UpdateMesh();
    }

    //IEnumerator, damit sich die Blöcke nach und nach aufbauen
    IEnumerator createMesh() {
        for (int j = 0; j < 51; j += 1)
        {
            for (int k = 0; k < 51; k += 1)
            {
                float fj = (float)j;
                float fk = (float)k;
                //1
                if ((k == 0 || k <= 8) && j == 10)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //2
                if (k == 6 && (j >= 22 && j <= 28))
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //3
                if ((k >= 0 && k <= 4) && j == 34)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //4
                if (k == 12 && (j >= 0 && j <= 22))
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //5
                if ((k >= 4 && k <= 11) && j == 16)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //6
                if ((k >= 12 && k <= 20) && j == 22)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //7
                if (k == 20 && (j > 6 && j <= 22))
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //8 TIERE
                if ((k >= 10 && k <= 17) && j == 26)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //9 TIERE
                if (k == 10 && (j >= 26 && j <= 34))
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //10 TIERE
                if (k == 9 && (j >= 34 && j <= 46))
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //11
                if ((k >= 4 && k <= 9) && j == 40)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //12 TIERE
                if ((k >= 9 && k <= 20) && j == 40)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //13 TIERE
                if (k == 20 && (j >= 26 && j <= 40))
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //14
                if ((j >= 28 && j <= 32) && k == 26)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //15
                if ((k >= 12 && k <= 26) && j == 49)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //16
                if (k == 25 && (j >= 42 && j <= 49))
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //17
                if ((j >= 10 && j <= 22) && k == 26)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //18  Schlüssel!!!!!
                if ((j >= 0 && j <= 6) && k == 24)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //19 Schlüssel!!!!
                if ((k >= 24 && k <= 30) && j == 6)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //20
                if ((j >= 24 && j <= 37) && k == 32)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //21
                if ((k >= 26 && k <= 36) && j == 38)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //22
                if ((j >= 38 && j <= 19) && k == 36)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //23
                if (j == 0 && (k >= 34 && k <= 38))
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //24
                if ((j >= 0 && j <= 14) && k == 38)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //25
                if (j == 14 && (k >= 30 && k <= 38))
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //26
                if (j == 8 && (k >= 38 && k <= 46))
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //27
                if ((j >= 6 && j <= 7) && k == 46)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //28
                if ((j >= 20 && j <= 24) && k == 38)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //29
                if (j == 18 && (k >= 42 && k <= 49))
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //30
                if ((j >= 24 && j <= 30) && k == 45)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //31
                if ((j >= 30 && j <= 38) && k == 44)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //32
                if (j == 30 && (k >= 36 && k <= 44))
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //33
                if (j == 38 && (k >= 44 && k <= 49))
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }

                //34
                if ((j >= 44 && j <= 49) && k == 44)
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.01f);
                }
            }
        }
    }
    //"Random" Wände
    IEnumerator createWall() {
        
        for (int j = 0; j <= 50; j++) {
            for (int k = 0; k <= 50; k++) {

                float fj = (float)j;
                float fk = (float)k;
                
                if ((kjg_wallTrigger.a == 0 || kjg_wallTrigger.b == 0)&& (j == 22 && (k >= 6 && k <= 12))) {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.15f);
                    Debug.Log("createWall");
                }
                if ((kjg_wallTrigger.a == 1 || kjg_wallTrigger.b == 1) && (j == 10 && (k >= 20 && k <= 26)))
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.15f);
                    Debug.Log("createWall");
                }
                if ((kjg_wallTrigger.a == 2 || kjg_wallTrigger.b == 2) && (j == 38 && (k >= 20 && k <= 26)))
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.15f);
                    Debug.Log("createWall");
                }
                if ((kjg_wallTrigger.a == 3 || kjg_wallTrigger.b == 3) && (k == 32 && (j >= 14 && j <= 24)))
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.15f);
                    Debug.Log("createWall");
                }
                if ((kjg_wallTrigger.a == 4 || kjg_wallTrigger.b == 4) && (j == 24 && (k >= 38 && k <= 44)))
                {
                    addVertices(fj, 3, fk);
                    createTrianglesAndUV();
                    yield return new WaitForSeconds(0.15f);
                    Debug.Log("createWall");
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Erstellung des Mesh für Labyrinth
        maze = new Mesh();
        mazeObject = new GameObject("Labyrinth");
        mazeObject.AddComponent<MeshFilter>();
        mazeObject.AddComponent<MeshRenderer>();
        mazeObject.GetComponent<MeshFilter>().mesh = maze;

        //Texturierung
        Renderer rendMaze = mazeObject.GetComponent<Renderer>();
        rendMaze.material = matMaze;
        matMaze = mazeObject.GetComponent<Renderer>().material;

        //Collider
        mazeCollider = mazeObject.AddComponent<MeshCollider>();
        Rigidbody mazeBody = mazeObject.AddComponent<Rigidbody>();
        mazeBody.isKinematic = true;
        mazeCollider.sharedMesh = maze;

        StartCoroutine(createMesh());
    }
    void UpdateMesh()
    {
        //Mesh ändern bzw. füllen
        maze.Clear();

        maze.vertices = verticesMaze.ToArray();
        maze.triangles = block.ToArray();
        maze.uv = uvMaze.ToArray();
        maze.RecalculateNormals();

        mazeCollider.sharedMesh = maze;
    }
    int count = 0;
    private void Update()
    {
        if (kjg_wallTrigger.trigger && count < 23) {
            //Debug.Log("trigger" + kjg_wallTrigger.trigger);
            StartCoroutine(createWall());
            count++;
            //Debug.Log("MazeSkript");
        }
    }
}
