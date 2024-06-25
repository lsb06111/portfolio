using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class DropItems : ScriptableObject
{
    public GameObject diObject; // get object

    public string DropI_name; // item name

    public int drop_chance; // probability 

    public DropItems(string DropI_name, int drop_chance) // make constructor
    {
        this.DropI_name = DropI_name; // initialisation
        this.drop_chance = drop_chance; // initialisation






    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
