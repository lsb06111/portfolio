using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBossGate : MonoBehaviour
{
    private Transform gate1, gate2; // transform of gate1 and gate2
    public float rotationSpeed = 0.4f; // speed of rotation
    private float rotationValue = 0; // for checking the rotation value
    public bool openGates = false; // for determining if gates should be opened or not

    MeshCollider bossGateCollider; // mesh collider of boos gate

    private void Start()
    {
        // Get the child objects by name
        gate1 = transform.Find("gate1"); // initialise gate1
        gate2 = transform.Find("gate2"); // initialise gate2

        bossGateCollider = GetComponent<MeshCollider>(); // initialise meshcollider for the boss gate
    }

    private void Update()
    {
        if (openGates && rotationValue <=110) // if gates should be opened and rotation value is less than 110 degree
        {
            rotationValue += rotationSpeed; // update the rotation value
            if (bossGateCollider) bossGateCollider.enabled = false; // remove boss gate mesh collider for player's entering

            // Rotate gate1 and gate2
            gate1.Rotate(0, rotationSpeed, 0);
            gate2.Rotate(0, -rotationSpeed, 0); 
        }
    }

    public void StartOpeningGates() // this function decides whether to open the boss gate
    {
        openGates = true;
    }

   
}
