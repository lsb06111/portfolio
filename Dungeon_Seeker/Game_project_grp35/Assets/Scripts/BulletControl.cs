using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;  // get player object
    private GameObject bullet_object;
    private float speed = 30.0f; // set the speed
    void Start()
    {
        player= GameObject.Find("Player"); // initialise player
        this.transform.LookAt(player.transform);   // make the bullet facees to the player position     
    }

    // Update is called once per frame
    void Update()
    {
       
        this.transform.Translate(transform.forward * speed * Time.deltaTime, Space.World); // make the bullet go forward
        
    }
    void OnCollisionEnter(Collision collision){ // collides with any obstacles
        Destroy(gameObject);  // destroy
        
    }    
}