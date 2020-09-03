using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TL_Obstacle1 : MonoBehaviour
{
    [Header("Materials")]
    public Material material1;
    public Material material2;
    public Material material3;
    public Material material4;

    Material[] mat = new Material[4];

    Vector3[] vertices = new Vector3[80];
    Vector2[] uvs = new Vector2[80];
    Renderer rend;
    Mesh mesh;
    int[][] triangles = new int[4][];

    //Mesh Collider
    MeshCollider meshCollider;

    #region Singleton

    public static TL_Obstacle1 Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion
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
        mat[3] = material4;

        rend.materials = mat;

        //------------- Vertices
        //Boden 1
        vertices[0] = new Vector3(-3.5f, 0, 0);
        vertices[1] = new Vector3(3.5f, 0, 0);
        vertices[2] = new Vector3(-3.5f, 0, 4);
        vertices[3] = new Vector3(3.5f, 0, 4);

        //Wand rechts
        vertices[4] = new Vector3(3.5f, 0, 0);
        vertices[5] = new Vector3(3.5f, 0, 30);
        vertices[6] = new Vector3(3.5f, 5, 0);
        vertices[7] = new Vector3(3.5f, 5, 30);

        //Wand links
        vertices[8] = new Vector3(-3.5f, 0, 0);
        vertices[9] = new Vector3(-3.5f, 0, 30);
        vertices[10] = new Vector3(-3.5f, 5, 0);
        vertices[11] = new Vector3(-3.5f, 5, 30);

        //Decke
        vertices[12] = new Vector3(-3.5f, 5, 0);
        vertices[13] = new Vector3(-3.5f, 5, 30);
        vertices[14] = new Vector3(3.5f, 5, 0);
        vertices[15] = new Vector3(3.5f, 5, 30);

        //Wand vorne rechts
        vertices[16] = new Vector3(2.5f, 0, 0);
        vertices[17] = new Vector3(3.5f, 0, 0);
        vertices[18] = new Vector3(2.5f, 5, 0);
        vertices[19] = new Vector3(3.5f, 5, 0);

        //Wand vorne links
        vertices[20] = new Vector3(-2.5f, 0, 0);
        vertices[21] = new Vector3(-3.5f, 0, 0);
        vertices[22] = new Vector3(-2.5f, 5, 0);
        vertices[23] = new Vector3(-3.5f, 5, 0);

        //Wand hinten rechts
        vertices[24] = new Vector3(2.5f, 0, 30);
        vertices[25] = new Vector3(3.5f, 0, 30);
        vertices[26] = new Vector3(2.5f, 5, 30);
        vertices[27] = new Vector3(3.5f, 5, 30);

        //Wand hinten links
        vertices[28] = new Vector3(-2.5f, 0, 30);
        vertices[29] = new Vector3(-3.5f, 0, 30);
        vertices[30] = new Vector3(-2.5f, 5, 30);
        vertices[31] = new Vector3(-3.5f, 5, 30);

        //Boden 2
        vertices[32] = new Vector3(-3.5f, 0, 8);
        vertices[33] = new Vector3(3.5f, 0, 8);
        vertices[34] = new Vector3(-3.5f, 0, 15);
        vertices[35] = new Vector3(3.5f, 0, 15);

        //Boden 3
        vertices[36] = new Vector3(-3.5f, 0, 26);
        vertices[37] = new Vector3(3.5f, 0, 26);
        vertices[38] = new Vector3(-3.5f, 0, 30);
        vertices[39] = new Vector3(3.5f, 0, 30);

        //Schlucht1 wand hinten
        vertices[40] = new Vector3(-3.5f, -5, 8);
        vertices[41] = new Vector3(3.5f, -5, 8);
        vertices[42] = new Vector3(-3.5f, 0, 8);
        vertices[43] = new Vector3(3.5f, 0, 8);

        //Schlucht1 wand links
        vertices[44] = new Vector3(-3.5f, -5, 4);
        vertices[45] = new Vector3(-3.5f, -5, 8);
        vertices[46] = new Vector3(-3.5f, 0, 4);
        vertices[47] = new Vector3(-3.5f, 0, 8);

        //Schlucht1 wand rechts
        vertices[48] = new Vector3(3.5f, -5, 4);
        vertices[49] = new Vector3(3.5f, -5, 8);
        vertices[50] = new Vector3(3.5f, 0, 4);
        vertices[51] = new Vector3(3.5f, 0, 8);

        //Schlucht1 wand vorne
        vertices[52] = new Vector3(-3.5f, -5, 4);
        vertices[53] = new Vector3(3.5f, -5, 4);
        vertices[54] = new Vector3(-3.5f, 0, 4);
        vertices[55] = new Vector3(3.5f, 0, 4);

        //Schlucht2 wand hinten
        vertices[56] = new Vector3(-3.5f, -5, 26);
        vertices[57] = new Vector3(3.5f, -5, 26);
        vertices[58] = new Vector3(-3.5f, 0, 26);
        vertices[59] = new Vector3(3.5f, 0, 26);

        //Schlucht2 wand links
        vertices[60] = new Vector3(-3.5f, -5, 15);
        vertices[61] = new Vector3(-3.5f, -5, 26);
        vertices[62] = new Vector3(-3.5f, 0, 15);
        vertices[63] = new Vector3(-3.5f, 0, 26);

        //Schlucht2 wand rechts
        vertices[64] = new Vector3(3.5f, -5, 15);
        vertices[65] = new Vector3(3.5f, -5, 26);
        vertices[66] = new Vector3(3.5f, 0, 15);
        vertices[67] = new Vector3(3.5f, 0, 26);

        //Schlucht2 wand vorne
        vertices[68] = new Vector3(-3.5f, -5, 15);
        vertices[69] = new Vector3(3.5f, -5, 15);
        vertices[70] = new Vector3(-3.5f, 0, 15);
        vertices[71] = new Vector3(3.5f, 0, 15);

        //Boden Schlucht1
        vertices[72] = new Vector3(-3.5f, 0, 4);
        vertices[73] = new Vector3(3.5f, 0, 4);
        vertices[74] = new Vector3(-3.5f, 0, 8);
        vertices[75] = new Vector3(3.5f, 0, 8);

        //Boden Schlucht2
        vertices[76] = new Vector3(-3.5f, 0, 15);
        vertices[77] = new Vector3(3.5f, 0, 15);
        vertices[78] = new Vector3(-3.5f, 0, 26);
        vertices[79] = new Vector3(3.5f, 0, 26);
        //-------------

        //------------- UVS
        //Boden 1
        uvs[0] = new Vector2(0f, 0f);
        uvs[1] = new Vector2(1f, 0f);
        uvs[2] = new Vector2(0f, 1f);
        uvs[3] = new Vector2(1f, 1f);

        //Wand rechts
        uvs[4] = new Vector2(3f, 0f);
        uvs[5] = new Vector2(0f, 0f);
        uvs[6] = new Vector2(3f, 1f);
        uvs[7] = new Vector2(0f, 1f);

        //Wand links
        uvs[8] = new Vector2(0f, 0f);
        uvs[9] = new Vector2(3f, 0f);
        uvs[10] = new Vector2(0f, 1f);
        uvs[11] = new Vector2(3f, 1f);

        //Decke
        uvs[12] = new Vector2(1f, 0f);
        uvs[13] = new Vector2(0f, 1f);
        uvs[14] = new Vector2(0f, 0f);
        uvs[15] = new Vector2(1f, 1f);

        //Wand vorne rechts
        uvs[16] = new Vector2(0f, 0f);
        uvs[17] = new Vector2(0.2f, 0f);
        uvs[18] = new Vector2(0f, 1f);
        uvs[19] = new Vector2(0.2f, 1f);

        //Wand vorne links
        uvs[20] = new Vector2(0.2f, 0f);
        uvs[21] = new Vector2(0f, 0f);
        uvs[22] = new Vector2(0.2f, 1f);
        uvs[23] = new Vector2(0f, 1f);

        //Wand hinten rechts
        uvs[24] = new Vector2(0f, 0f);
        uvs[25] = new Vector2(0.2f, 0f);
        uvs[26] = new Vector2(0f, 1f);
        uvs[27] = new Vector2(0.2f, 1f);

        //Wand hinten links
        uvs[28] = new Vector2(0.2f, 0f);
        uvs[29] = new Vector2(0f, 0f);
        uvs[30] = new Vector2(0.2f, 1f);
        uvs[31] = new Vector2(0f, 1f);

        //Boden 2
        uvs[32] = new Vector2(0f, 0f);
        uvs[33] = new Vector2(1f, 0f);
        uvs[34] = new Vector2(0f, 1f);
        uvs[35] = new Vector2(1f, 1f);

        //Boden 3
        uvs[36] = new Vector2(0f, 0f);
        uvs[37] = new Vector2(1f, 0f);
        uvs[38] = new Vector2(0f, 1f);
        uvs[39] = new Vector2(1f, 1f);

        //Schlucht1 wand hinten
        uvs[40] = new Vector2(0f, 0f);
        uvs[41] = new Vector2(1f, 0f);
        uvs[42] = new Vector2(0f, 1f);
        uvs[43] = new Vector2(1f, 1f);

        //Schlucht1 wand links
        uvs[44] = new Vector2(0f, 0f);
        uvs[45] = new Vector2(1f, 0f);
        uvs[46] = new Vector2(0f, 1f);
        uvs[47] = new Vector2(1f, 1f);

        //Schlucht1 wand rechts
        uvs[48] = new Vector2(1f, 0f);
        uvs[49] = new Vector2(0f, 0f);
        uvs[50] = new Vector2(1f, 1f);
        uvs[51] = new Vector2(0f, 1f);

        //Schlucht1 wand rechts
        uvs[52] = new Vector2(1f, 0f);
        uvs[53] = new Vector2(0f, 0f);
        uvs[54] = new Vector2(1f, 1f);
        uvs[55] = new Vector2(0f, 1f);

        //Schlucht2 wand hinten
        uvs[56] = new Vector2(0f, 0f);
        uvs[57] = new Vector2(1f, 0f);
        uvs[58] = new Vector2(0f, 1f);
        uvs[59] = new Vector2(1f, 1f);

        //Schlucht2 wand links
        uvs[60] = new Vector2(0f, 0f);
        uvs[61] = new Vector2(1f, 0f);
        uvs[62] = new Vector2(0f, 1f);
        uvs[63] = new Vector2(1f, 1f);

        //Schlucht2 wand rechts
        uvs[64] = new Vector2(1f, 0f);
        uvs[65] = new Vector2(0f, 0f);
        uvs[66] = new Vector2(1f, 1f);
        uvs[67] = new Vector2(0f, 1f);

        //Schlucht2 wand rechts
        uvs[68] = new Vector2(1f, 0f);
        uvs[69] = new Vector2(0f, 0f);
        uvs[70] = new Vector2(1f, 1f);
        uvs[71] = new Vector2(0f, 1f);

        //Boden Schlucht1
        uvs[72] = new Vector2(0f, 0f);
        uvs[73] = new Vector2(1f, 0f);
        uvs[74] = new Vector2(0f, 1f);
        uvs[75] = new Vector2(1f, 1f);

        //Boden Schlucht2
        uvs[76] = new Vector2(0f, 0f);
        uvs[77] = new Vector2(1f, 0f);
        uvs[78] = new Vector2(0f, 1f);
        uvs[79] = new Vector2(1f, 1f);
        //-------------

        //------------- Triangles

        triangles[0] = new int[] {
            //Boden 1
            0,2,1,
            1,2,3,
            //Boden 2
            32,34,33,
            33,34,35,
            //Boden 3
            36,38,37,
            37,38,39,
            //Boden Schlucht1
            72,74,73,
            73,74,75,
            //Boden Schlucht2
            76,78,77,
            77,78,79
        };

        triangles[1] = new int[] {
            //Wand rechts
            4,5,7,
            4,7,6,
            //Wand links
            8,10,11,
            8,11,9,
            //Wand vorne rechts
            16,17,18,
            18,17,19,
            //Wand vorne links
            20,22,21,
            22,23,21,
            //Wand hinten rechts
            24,26,25,
            25,26,27,
            //Wand hinten links
            29,31,28,
            28,31,30
        };

        triangles[2] = new int[] {
            //Decke
            12,14,13,
            14,15,13
        };

        triangles[3] = new int[] {
            //Schlucht1 Wand hinten
            40,42,41,
            41,42,43,
            //Schlucht1 Wand links
            44,46,45,
            45,46,47,
            //Schlucht1 Wand rechts
            48,49,50,
            49,51,50,
            //Schlucht1 Wand vorne
            52,53,54,
            53,55,54,
            //Schlucht2 Wand hinten
            56,58,57,
            57,58,59,
            //Schlucht2 Wand links
            60,62,61,
            61,62,63,
            //Schlucht2 Wand rechts
            64,65,66,
            65,67,66,
            //Schlucht2 Wand vorne
            68,69,70,
            69,71,70
        };  
        //-------------

        mesh.subMeshCount = 4;

        mesh.vertices = vertices;
        mesh.uv = uvs;

        mesh.SetTriangles(triangles[0], 0);
        mesh.SetTriangles(triangles[1], 1);
        mesh.SetTriangles(triangles[2], 2);
        mesh.SetTriangles(triangles[3], 3);

        mesh.RecalculateNormals();

        //Mesh Collider
        meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
    }

    public void LowerObstacleGround()
    {
        if (vertices[72].y > -5)
        {
            vertices[72] += new Vector3(0, -0.006f, 0);
            vertices[73] += new Vector3(0, -0.006f, 0);
            vertices[74] += new Vector3(0, -0.006f, 0);
            vertices[75] += new Vector3(0, -0.006f, 0);
            vertices[76] += new Vector3(0, -0.006f, 0);
            vertices[77] += new Vector3(0, -0.006f, 0);
            vertices[78] += new Vector3(0, -0.006f, 0);
            vertices[79] += new Vector3(0, -0.006f, 0);

            mesh.Clear();
            mesh.vertices = vertices;
            mesh.uv = uvs;

            mesh.subMeshCount = 4;
            mesh.SetTriangles(triangles[0], 0);
            mesh.SetTriangles(triangles[1], 1);
            mesh.SetTriangles(triangles[2], 2);
            mesh.SetTriangles(triangles[3], 3);    

            mesh.RecalculateNormals();
            meshCollider.sharedMesh = mesh;
        }
    }
}
