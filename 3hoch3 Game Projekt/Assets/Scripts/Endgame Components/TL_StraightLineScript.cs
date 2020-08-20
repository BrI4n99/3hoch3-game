using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TL_StraightLineScript : MonoBehaviour
{
    [Header("Materials")]
    public Material material1;
    public Material material2;
    public Material material3;

    Material[] mat = new Material[3];

    Vector3[] vertices = new Vector3[16];
    Vector2[] uvs = new Vector2[16];
    Renderer rend;
    Mesh mesh;
    int[][] triangles = new int[3][];

    //Mesh Collider
    MeshCollider meshCollider;

    void Start()
    {
        mesh = new Mesh();
        gameObject.AddComponent<MeshFilter>();
        gameObject.GetComponent<MeshFilter>().mesh = mesh;

        mesh.Clear();

        gameObject.AddComponent<MeshRenderer>();
        rend = gameObject.GetComponent<MeshRenderer>();

        mat[0] = material1;
        mat[1] = material2;
        mat[2] = material3;
        //mat[3] = material4;

        rend.materials = mat;

        //------------- Vertices
        //Boden
        vertices[0] = new Vector3(-2.5f, 0, 0);
        vertices[1] = new Vector3(2.5f, 0, 0);
        vertices[2] = new Vector3(-2.5f, 0, 5);
        vertices[3] = new Vector3(2.5f, 0, 5);

        //Wand rechts
        vertices[4] = new Vector3(2.5f, 0, 0);
        vertices[5] = new Vector3(2.5f, 0, 5);
        vertices[6] = new Vector3(2.5f, 5, 0);
        vertices[7] = new Vector3(2.5f, 5, 5);

        //Wand links
        vertices[8] = new Vector3(-2.5f, 0, 0);
        vertices[9] = new Vector3(-2.5f, 0, 5);
        vertices[10] = new Vector3(-2.5f, 5, 0);
        vertices[11] = new Vector3(-2.5f, 5, 5);

        //Decke
        vertices[12] = new Vector3(-2.5f, 5, 0);
        vertices[13] = new Vector3(-2.5f, 5, 5);
        vertices[14] = new Vector3(2.5f, 5, 0);
        vertices[15] = new Vector3(2.5f, 5, 5);
        //-------------

        //------------- UVS
        //Boden
        uvs[0] = new Vector2(0f, 0f);
        uvs[1] = new Vector2(1f, 0f);
        uvs[2] = new Vector2(0f, 1f);
        uvs[3] = new Vector2(1f, 1f);

        //Wand rechts
        uvs[4] = new Vector2(1f, 0f);
        uvs[5] = new Vector2(0f, 0f);
        uvs[6] = new Vector2(1f, 1f);
        uvs[7] = new Vector2(0f, 1f);

        //Wand links
        uvs[8] = new Vector2(0f, 0f);
        uvs[9] = new Vector2(1f, 0f);
        uvs[10] = new Vector2(0f, 1f);
        uvs[11] = new Vector2(1f, 1f);

        //Decke
        uvs[12] = new Vector2(1f, 0f);
        uvs[13] = new Vector2(0f, 1f);
        uvs[14] = new Vector2(0f, 0f);
        uvs[15] = new Vector2(1f, 1f);
        //-------------

        //------------- Triangles

        triangles[0] = new int[] {
            //Boden
            0,2,1,
            1,2,3,
        };

        triangles[1] = new int[] {
            //Wand rechts
            4,5,7,
            4,7,6,
            //Wand links
            8,10,11,
            8,11,9
        };

        triangles[2] = new int[] {
            //Decke
            12,14,13,
            14,15,13
        };

        //-------------

        mesh.subMeshCount = 3;

        mesh.vertices = vertices;
        mesh.uv = uvs;

        mesh.SetTriangles(triangles[0], 0);
        mesh.SetTriangles(triangles[1], 1);
        mesh.SetTriangles(triangles[2], 2);

        mesh.RecalculateNormals();

        //Mesh Collider
        meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
    }
}
