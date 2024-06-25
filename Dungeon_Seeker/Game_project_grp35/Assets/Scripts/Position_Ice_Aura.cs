using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position_Ice_Aura : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject ice_elemental; // get ice_elemental boss
    private float zoom = 3.0f; // make it larger
    private PlayerMovement player; // player movement script
    
    void Start()
    {
        ice_elemental=GameObject.Find("MiniBoss_3"); // get miniboss 3 object
        player = GameObject.Find("Player").GetComponent<PlayerMovement>(); // 
        this.transform.position = ice_elemental.transform.position; // get position of boss
        this.transform.localScale = Vector3.one * zoom; // scale up


        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isBoss2Dead){ // if boss2 is dead
            Destroy(gameObject); // destroy itself
            
            
        }
             
    }
}
