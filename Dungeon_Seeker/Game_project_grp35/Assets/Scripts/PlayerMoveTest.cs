using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTest : MonoBehaviour
{

    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer() // a function that moves the player
    {
        
            float horizontalInput = Input.GetAxis("Horizontal"); // for the key of "A" and "D" (horizontal)
            float verticalInput = Input.GetAxis("Vertical"); // for the key of "W" and "S" (vertical)



            if (horizontalInput != 0 || verticalInput != 0) // when either horizontalInput or verticalInput is input
            {
                float angle = Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg; // get the anlge of direction based on the input
                transform.rotation = Quaternion.Euler(0, angle, 0); // rotate with the value
            }

            transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime, Space.World); // make the player move back and forth regardless of its direction
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime, Space.World); // make the player move left and right regardless of its direction
        
    }
}
