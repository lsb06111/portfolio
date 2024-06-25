using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBaker : MonoBehaviour
{
    public NavMeshSurface surface;

    public void Bake() // this function bakes the entire map again by calling
    {
        
        surface.BuildNavMesh(); // bake the nav mesh
        
        
    }

   
}
