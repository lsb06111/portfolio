using UnityEngine;

public class BatchColliderRemover : MonoBehaviour
{
    [ContextMenu("Remove Wall Mesh Colliders")]
    public void RemoveMeshCollidersFromWalls()
    {
        // Get all the MeshColliders in the scene
        MeshCollider[] colliders = GameObject.FindObjectsOfType<MeshCollider>();

        foreach (MeshCollider collider in colliders)
        {
            // Check if the GameObject's name contains "wall" (case-insensitive)
            if (collider.gameObject.name.ToLower().Contains("wall"))
            {
                DestroyImmediate(collider);
            }
        }
    }
}
