using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_labyrinth : MonoBehaviour
{

    GameObject mazeObject;
    Mesh maze;
    public Material matMaze;

    List<Vector3> verticesMaze = new List<Vector3>(); //Punkte 
    List<int> block = new List<int>(); //Häuser (Dreiecke)
    List<Vector3> normalsBlock = new List<Vector3>(); //Liste für Normalen
    List<Vector2> uvMaze = new List<Vector2>(); //Liste für UV-Koordinaten

    //int[,] mazeArray = new int[,] { {0, 0 }, { 0, 0 }, { 5, 6 }, { 7, 8 } };

    float laenge;
    float breite;

    int countMesh = 0;

    void createMaze(float x, float y, float z) {

        laenge = 2; //Random.Range(0.0f, 3.0f);
        breite = 2;

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
        uvMaze.Add(new Vector2(0, 0));
        uvMaze.Add(new Vector2(0, 1));
        uvMaze.Add(new Vector2(1, 1));
        uvMaze.Add(new Vector2(1, 0));

        //Seite6 Links
        uvMaze.Add(new Vector2(0, 0));
        uvMaze.Add(new Vector2(1, 0));
        uvMaze.Add(new Vector2(1, 1));
        uvMaze.Add(new Vector2(0, 1));

        countMesh += 24;

    }

    // Start is called before the first frame update
    void Start()
    {
        //Labyrinth erstellen
        for (int j = 0; j < 49; j += 2)
        {
            for (int k = 0; k < 49; k += 2)
            {

                float fj = (float)j;
                float fk = (float)k;
                //1
                if ((k == 0 || k <= 8) && j == 10)
                {
                    createMaze(fj, 3, fk);
                }

                //2
                if (k == 6 && (j >= 22 && j <= 28))
                {
                    createMaze(fj, 3, fk);
                }

                //3
                if ((k >= 0 && k <= 4) && j == 34)
                {
                    createMaze(fj, 3, fk);
                }

                //4
                if (k == 12 && (j >= 0 && j <= 22))
                {
                    createMaze(fj, 3, fk);
                }

                //5
                if ((k >= 4 && k <= 10) && j == 16)
                {
                    createMaze(fj, 3, fk);
                }

                //6
                if ((k >= 12 && k <= 20) && j == 22)
                {
                    createMaze(fj, 3, fk);
                }

                //7
                if (k == 20 && (j > 6 && j <= 22))
                {
                    createMaze(fj, 3, fk);
                }

                //8
                if ((k >= 10 && k <= 16) && j == 26)
                {
                    createMaze(fj, 3, fk);
                }

                //9
                if (k == 10 && (j >= 26 && j <= 34))
                {
                    createMaze(fj, 3, fk);
                }

                //10
                if (k == 8 && (j >= 34 && j <= 46))
                {
                    createMaze(fj, 3, fk);
                }

                //11
                if ((k >= 4 && k <= 6) && j == 40)
                {
                    createMaze(fj, 3, fk);
                }

                //12
                if ((k >= 10 && k <= 20) && j == 40)
                {
                    createMaze(fj, 3, fk);
                }

                //13
                if (k == 20 && (j >= 26 && j <= 40))
                {
                    createMaze(fj, 3, fk);
                }

                //14
                if ((j >= 28 && j <= 32) && k == 26)
                {
                    createMaze(fj, 3, fk);
                }

                //15
                if ((k >= 12 && k <= 26) && j == 48)
                {
                    createMaze(fj, 3, fk);
                }

                //16
                if (k == 25 && (j >= 42 && j <= 50))
                {
                    createMaze(fj, 3, fk);
                }

                //17
                if ((j >= 10 && j <= 22) && k == 26)
                {
                    createMaze(fj, 3, fk);
                }

                //18
                if ((j >= 0 && j <= 6) && k == 24)
                {
                    createMaze(fj, 3, fk);
                }

                //19
                if ((k >= 24 && k <= 30) && j == 6)
                {
                    createMaze(fj, 3, fk);
                }

                //20
                if ((j >= 24 && j <= 36) && k == 32)
                {
                    createMaze(fj, 3, fk);
                }

                //21
                if ((k >= 26 && k <= 36) && j == 38)
                {
                    createMaze(fj, 3, fk);
                }

                //22
                if ((j >= 38 && j <= 50) && k == 36)
                {
                    createMaze(fj, 3, fk);
                }

                //23
                if (j == 0 && (k >= 34 && k <= 38))
                {
                    createMaze(fj, 3, fk);
                }

                //24
                if ((j >= 0 && j <= 14) && k == 38)
                {
                    createMaze(fj, 3, fk);
                }

                //25
                if (j == 14 && (k >= 30 && k <= 38))
                {
                    createMaze(fj, 3, fk);
                }

                //26
                if (j == 8 && (k >= 38 && k <= 46))
                {
                    createMaze(fj, 3, fk);
                }

                //27
                if (j == 6 && k == 46)
                {
                    createMaze(fj, 3, fk);
                }

                //28
                if ((j >= 20 && j <= 24) && k == 38)
                {
                    createMaze(fj, 3, fk);
                }

                //29
                if (j == 18 && (k >= 42 && k <= 50))
                {
                    createMaze(fj, 3, fk);
                }

                //30
                if ((j >= 24 && j <= 30) && k == 46)
                {
                    createMaze(fj, 3, fk);
                }

                //31
                if ((j >= 30 && j <= 38) && k == 44)
                {
                    createMaze(fj, 3, fk);
                }

                //32
                if (j == 30 && (k >= 36 && k <= 44))
                {
                    createMaze(fj, 3, fk);
                }

                //33
                if (j == 38 && (k >= 44 && k <= 50))
                {
                    createMaze(fj, 3, fk);
                }

                //34
                if ((j >= 44 && j <= 50) && k == 44)
                {
                    createMaze(fj, 3, fk);
                }
            }
        }

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

        //Mesh ändern bzw. füllen
        maze.Clear();

        maze.vertices = verticesMaze.ToArray();
        maze.triangles = block.ToArray();
        maze.uv = uvMaze.ToArray();
        maze.RecalculateNormals();

        //Collider
        MeshCollider mazeCollider = mazeObject.AddComponent<MeshCollider>();
        Rigidbody mazeBody = mazeObject.AddComponent<Rigidbody>();
        mazeBody.isKinematic = true;
        mazeCollider.sharedMesh = maze;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
