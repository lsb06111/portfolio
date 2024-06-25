using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShard : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject miniboss_3; // get miniboss3 object
    public int MaxHP = 20; // set the max hp
    public int HP = 20; // set the current hp
    FloatingHealthBar healthBar; // hp bar

    void Start()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>(); // get hp bar
        healthBar.UpdateHealthBar(HP, MaxHP); // set the initial value of hps
        
    }

    // Update is called once per frame
    void Update()
    {
        
             
    }
    public void TakeDamage(int damage){ // this function takes damage of the boss from the player
        HP -= damage; // decrement hp
        healthBar.UpdateHealthBar(HP, MaxHP); // update the hp
        if (HP <= 0){ // if boss dead
            GameObject.Find("MiniBoss_3(Clone)").GetComponent<Miniboss_3>().hasShard-=1; // decrement has shard counter by 1
            Destroy(gameObject); // destroy itself
        }
    }
}