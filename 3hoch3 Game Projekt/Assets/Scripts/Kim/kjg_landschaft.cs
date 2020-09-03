using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_landschaft : MonoBehaviour
{
    Mesh terrain;
    GameObject terrainObject;
    public Material matLandschaft;
    MeshCollider tCollider;

    Vector3[] tVertices;
    int[] tTriangles;

    int xSize = 60;
    int zSize = 60;
    // Start is called before the first frame update
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
        updateMesh();

        terrainObject.transform.position -= new Vector3(60,1f,0);
    }

    float hoehe;
    void createTerrain() {
        tVertices = new Vector3[(xSize +1) * (zSize+1)];
;
        for (int z =0, i = 0; z <= zSize; z++) {
            for (int x = 0; x <= xSize; x++) {
                hoehe = Mathf.PerlinNoise(x*0.4f, z *0.4f)* 2f;
                tVertices[i] = new Vector3(x, hoehe, z);
                i++;
            }
        }

        int vertCount = 0; //an welchem Vertex man grad ist
        int triangleCount = 0; //wieviele Trianglex man hat
        tTriangles = new int[xSize * zSize * 6];

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
   }

    void updateMesh() {

        terrain.Clear();

        terrain.vertices = tVertices;
        terrain.triangles = tTriangles;
        terrain.RecalculateNormals();
        tCollider.sharedMesh = terrain;
    }
}
