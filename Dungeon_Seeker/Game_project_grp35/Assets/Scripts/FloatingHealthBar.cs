using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FloatingHealthBar : MonoBehaviour
{

    [SerializeField] private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateHealthBar(float currentValue, float maxValue) // this function updates the current hp to the hp bar
    {
        slider.value = currentValue / maxValue; // update the hp bar value 
    }
}
