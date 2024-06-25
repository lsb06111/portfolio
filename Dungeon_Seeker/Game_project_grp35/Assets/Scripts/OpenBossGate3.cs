using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpenBossGate3 : MonoBehaviour
{
    private Transform gate5, gate6; // transform of gate1 and gate2
    public float rotationSpeed = 0.4f; // speed of rotation
    private float rotationValue = 0; // for checking the rotation value
    public bool openGates3 = false; // for determining if gates should be opened or not
    bool onlyOnce = false;
    MeshCollider bossGateCollider; // mesh collider of boos gate
    Vector3 pos = new Vector3(131, 0, 165);

    private void Start()
    {
        // Get the child objects by name
        gate5 = transform.Find("gate5"); // initialise gate1
        gate6 = transform.Find("gate6"); // initialise gate2

        bossGateCollider = GetComponent<MeshCollider>(); // initialise meshcollider for the boss gate
    }

    private void Update()
    {
        if (openGates3 && rotationValue <= 110) // if gates should be opened and rotation value is less than 110 degree
        {
            rotationValue += rotationSpeed; // update the rotation value
            if (bossGateCollider) bossGateCollider.enabled = false; // remove boss gate mesh collider for player's entering

            // Rotate gate1 and gate2
            gate6.Rotate(0, rotationSpeed, 0);
            gate5.Rotate(0, -rotationSpeed, 0);
        }
        
    }


    public void StartOpeningGates() // this function decides whether to open the boss gate
    {
        openGates3 = true;

    }


}
