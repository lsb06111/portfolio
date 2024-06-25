using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMaker : MonoBehaviour
{

    public GameObject floorTilePrefab; // Drag your floor tile prefab here in the Inspector
    public GameObject wallTilePrefab; // Drag your floor tile prefab here in the Inspector

    public int width = 32; // Number of tiles in the x direction
    public int length = 32; // Number of tiles in the z direction
    public float tileSize = 8; // Size of each tile (assuming each tile is square)
    public float wallSize = 8;


    // Start is called before the first frame update
    void Start()
    {
        CreateFloor();
        CreateWalls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void CreateFloor()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < length; z++)
            {
                Vector3 position = new Vector3(x * tileSize, 0, z * tileSize);
                Instantiate(floorTilePrefab, position, Quaternion.identity, this.transform);
            }
        }
    }

    void CreateWalls()
    {
        for(int x=0; x < width; x++) // for position x 0 start
        {
            Vector3 position = new Vector3(x * wallSize, 0, -3);
            Instantiate(wallTilePrefab, position, Quaternion.Euler(0, 0, 0), this.transform);

        }

        for (int x = 0; x < width; x++) // for position x 251 start
        {
            Vector3 position = new Vector3(251, 0, x*wallSize);
            Instantiate(wallTilePrefab, position, Quaternion.Euler(0, 90, 0), this.transform);

        }

        for (int x = width-1; x >= 0; x--) // for position x 251 start
        {
            Vector3 position = new Vector3(x * wallSize, 0, 251);
            Instantiate(wallTilePrefab, position, Quaternion.Euler(0, 0, 0), this.transform);

        }

        for (int x = 0; x < width; x++) // for position x 251 start
        {
            Vector3 position = new Vector3(-3, 0, x * wallSize);
            Instantiate(wallTilePrefab, position, Quaternion.Euler(0, 90, 0), this.transform);

        }
    }

    void CreatePillar1()
    {

    }
}
