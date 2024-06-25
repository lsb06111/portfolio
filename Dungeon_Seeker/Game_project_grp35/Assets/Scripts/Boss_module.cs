using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_module : MonoBehaviour
{
    private GameObject miniboss_1;
    // Start is called before the first frame update
    void Start()
    {
        miniboss_1=GameObject.Find("MiniBoss_1");
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position=new Vector3(miniboss_1.transform.position.x,miniboss_1.transform.position.y,miniboss_1.transform.position.z); // keep the same position with the boss
        
    }
}
