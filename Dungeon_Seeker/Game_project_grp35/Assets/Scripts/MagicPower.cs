using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicPower : MonoBehaviour
{
    public Slider magicbar; // mp bar
    int magic_value = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // if mouse left click
        {
            magic_value -= 5; // take mp value by 5
            magicbar.value = magic_value; // update mp value
        }
    }
}