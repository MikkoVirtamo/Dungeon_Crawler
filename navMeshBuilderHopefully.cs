using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navMeshBuilderHopefully : MonoBehaviour
{
    public NavMeshSurface surface;
    // Start is called before the first frame update
    void Start()
    {
        surface = GameObject.FindGameObjectWithTag("navMeshSurfaceThing").GetComponent<NavMeshSurface>();
        Invoke("BuildNavMeshAfterLevel", 1.9f);
    }

    public void BuildNavMeshAfterLevel()
    {
       
        surface.BuildNavMesh();
        Debug.Log("navmesh built, supposedly");
    }
}  
