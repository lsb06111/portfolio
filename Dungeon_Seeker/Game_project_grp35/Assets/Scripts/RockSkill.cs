using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSkill : MonoBehaviour
{
    GameObject player; // get player object
    GameObject earth_elemental; // get earth boss object
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("Player"); //initialisation
        earth_elemental=GameObject.Find("EarthElemental"); //initialisation

    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y==0){
            if(Vector3.Distance(player.transform.position,this.transform.position)>=5){ // if near the player
                //Damge the player
                Debug.Log("Hit by falling rock");
                earth_elemental.GetComponent<MiniBoss_1>().shield_count+=1; // increment shield count for boss
            }
        }
        
    }
}
