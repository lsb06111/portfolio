using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Openbossgate2 : MonoBehaviour
{
    private Transform gate3, gate4; // transform of gate1 and gate2
    public float rotationSpeed = 0.4f; // speed of rotation
    private float rotationValue = 0; // for checking the rotation value
    public bool openGates2 = false; // for determining if gates should be opened or not
    bool onlyOnce = false;
    MeshCollider bossGateCollider; // mesh collider of boos gate
    Vector3 pos = new Vector3(131, 0, 165);

    private void Start()
    {
        // Get the child objects by name
        gate3 = transform.Find("gate3"); // initialise gate1
        gate4 = transform.Find("gate4"); // initialise gate2

        bossGateCollider = GetComponent<MeshCollider>(); // initialise meshcollider for the boss gate
    }

    private void Update()
    {
        if (openGates2 && rotationValue <= 110) // if gates should be opened and rotation value is less than 110 degree
        {
            rotationValue += rotationSpeed; // update the rotation value
            if (bossGateCollider) bossGateCollider.enabled = false; // remove boss gate mesh collider for player's entering

            // Rotate gate1 and gate2
            gate3.Rotate(0, rotationSpeed, 0);
            gate4.Rotate(0, -rotationSpeed, 0);
        }
        if(rotationValue > 110 && !onlyOnce) // once its fully opened and make sure for it to be called only once
        {
            if(Vector3.Distance(GameObject.Find("Player").transform.position, pos) <= 5f) // if very near
            {
                GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>(); // get game manager

                gm.stage2 = true; // set it stage2
                gm.isBoss1Completed = true; // make boss 1 defeated
                GameObject.Find("NavMesh").GetComponent<NavMeshBaker>().Bake(); // bake again for some of the possible errors
                onlyOnce = true; // make it true so it won't be called again
            }
            
        }
    }
    

    public void StartOpeningGates() // this function decides whether to open the boss gate
    {
        openGates2 = true;
       
    }


}
