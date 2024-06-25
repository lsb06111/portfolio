using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private GameObject player;  //get player object
    private float speed = 30.0f; // set the speed
    void Start()
    {
        player= GameObject.Find("Player"); 
        this.transform.LookAt(player.transform); // make it face to the player
        
    }

    // Update is called once per frame
    void Update()
    {    
        this.transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);   // make it go forward
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (!other.CompareTag("Boss1")){ // if meet anything else than boss1
            Destroy(gameObject); // destroy itself

        }
        
    }
    void OnCollisionEnter(Collision collision){ // when collides any obstacles
        Destroy(gameObject); // destroy itself
    }    
}