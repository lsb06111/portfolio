using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	public Slider slider; // hp bar
	

	public void SetMaxHealth(int health) // set the max hp 
	{
		slider.maxValue = health; //set the bar's max hp 
		slider.value = health; // set the bar value

	}

    public void SetHealth(int health) // set current hp
	{
		slider.value = health; // set the current hp

	
	}

}
