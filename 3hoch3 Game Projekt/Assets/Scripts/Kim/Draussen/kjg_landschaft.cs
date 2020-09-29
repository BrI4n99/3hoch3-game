using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_landschaft : MonoBehaviour
{
    //Landschaft für draußen erstellen

    Mesh terrain;
    GameObject terrainObject;
    public Material matLandschaft;
    MeshCollider tCollider;

    Vector3[] tVertices;
    int[] tTriangles;
    //Vector2[] tUV;

    int xSize = 60;
    int zSize = 60;

    private float hoehe;

 
    void Start()
    {
        terrain = new Mesh();
        terrainObject = new GameObject("Terrain");
        terrainObject.AddComponent<MeshFilter>();
        terrainObject.AddComponent<MeshRenderer>();
        terrainObject.GetComponent<MeshFilter>().mesh = terrain;

        //Texturierung
        Renderer rendTerrain = terrainObject.GetComponent<Renderer>();
        rendTerrain.material = matLandschaft;
        matLandschaft = terrainObject.GetComponent<Renderer>().material;

        //Collider
        tCollider = terrainObject.AddComponent<MeshCollider>();
        Rigidbody tBody = terrainObject.AddComponent<Rigidbody>();
        tBody.isKinematic = true;
        tCollider.sharedMesh = terrain;

        createTerrain();

        terrain.Clear();

        terrain.vertices = tVertices;
        terrain.triangles = tTriangles;
        //terrain.uv = tUV;
        terrain.RecalculateNormals();
        tCollider.sharedMesh = terrain;

        terrainObject.transform.position -= new Vector3(60f,0.2f,20);
        //terrainObject.transform.Rotate(-25,0,0);
        //Instantiate(terrainObject, new Vector3(-49,24.43f,-55.5f),Quaternion.Euler(27.81f,0,0));
    }

   
    void createTerrain() {

        //---------------------------------------Punkte hinzufügen-----------------------------------------
        tVertices = new Vector3[(xSize +1) * (zSize+1)];

        for (int z =0, i = 0; z <= zSize; z++) {
            for (int x = 0; x <= xSize; x++) {
                hoehe = Mathf.PerlinNoise(x * 0.2f, z * 0.2f);
                tVertices[i] = new Vector3(x, hoehe, z);
                i++;
            }
        }

        int vertCount = 0; //an welchem Vertex man grad ist
        int triangleCount = 0; //wieviele Triangles man hat
        tTriangles = new int[xSize * zSize * 6]; // Für jedes Viereck, 6 Punkte

        //----------------------------------------Triangles erstellen------------------------------------
        for (int x = 0; x < xSize; x++) {
            for(int z = 0; z < zSize; z++)
            {
                tTriangles[triangleCount + 0] = vertCount + 0; //unten links
                tTriangles[triangleCount + 1] = vertCount + xSize + 1; // unten rechts
                tTriangles[triangleCount + 2] = vertCount + 1; //oben links
                tTriangles[triangleCount + 3] = vertCount + 1;
                tTriangles[triangleCount + 4] = vertCount + xSize + 1;
                tTriangles[triangleCount + 5] = vertCount + xSize + 2; //oben rechts
                vertCount++;
                triangleCount += 6;

            }
            vertCount++;
        }

        //-------------------------------------UV-Koordinaten-------------------------------------------
        /*tUV = new Vector2[(xSize + 1) * (zSize + 1)];
        int countUV = 0; 

        for(int i = 0; i <= xSize; i ++){
            tUV[i] = new Vector2(0, 0);
            tUV[i + 1] = new Vector2(0, 1);
            tUV[i + 2] = new Vector2(0, 1);
            tUV[i + 3] = new Vector2(1, 1);
            countUV += 4;
        }*/

   }
}
