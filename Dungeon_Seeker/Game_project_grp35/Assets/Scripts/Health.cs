using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public Slider healthbar; // hp bar
    int health_value = 100; // current hp value
    // Start is called before the first frame update
    void OnCollisionEnter(Collision col) // if collision with obstacles
    {
        health_value -= 10; // make it decreased by 10
        healthbar.value = health_value; // update value
    }

    // Update is called once per frame
    void Update()
    {

    }
}