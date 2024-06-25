using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFireAura : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject fire_elemental; // fire_elemental boss object
    public float zoom = 2.0f; // for scaling up
    private PlayerMovement player; // player movement script

    void Start()
    {
        fire_elemental=GameObject.Find("FireElemental"); // get fireElemental object
        player = GameObject.Find("Player").GetComponent<PlayerMovement>(); // get script
        this.transform.position = fire_elemental.transform.position; // update position with the boss position
        

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = Vector3.one * zoom; // scale up by the time
        if (player.isBoss1Dead) //  if boss1 dead
        {
            Destroy(gameObject); // destroyed
            
        }
        
        
        
    }
}