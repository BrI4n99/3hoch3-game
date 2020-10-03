using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TL_CreateNavMesh : MonoBehaviour
{
    public GameObject NavMeshBuilder;
    public GameObject NavMeshSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            NavMeshBuilder.AddComponent<LocalNavMeshBuilder>();
            NavMeshSource.AddComponent<NavMeshSourceTag>();
        }
    }
}
