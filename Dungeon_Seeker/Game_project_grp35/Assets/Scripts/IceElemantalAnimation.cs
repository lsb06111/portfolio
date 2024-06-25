using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceElemantalModule : MonoBehaviour
{
    private GameObject player; // player object
    private Animator anim; // animator
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("Player"); // get player object
        anim = GetComponent<Animator>(); // get its animator
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(player.transform);// make itself look at the player
        
    }
    public void attacking(){ // function for attacking animation
        anim.SetTrigger("attack"); // attack trigger
        anim.SetTrigger("back"); // back trigger
    }
    public void being_attack(){ // function for damaging
        anim.SetTrigger("beattack"); // damage trigger
        anim.SetTrigger("back2"); // back trigger

    }
}
