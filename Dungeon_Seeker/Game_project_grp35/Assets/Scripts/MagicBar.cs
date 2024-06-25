using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicBar : MonoBehaviour
{

    public Slider slider; // mp bar


    public void SetMaxMagic(int magic) // set the max mp
    {
        slider.maxValue = magic; // set max mp for bar
        slider.value = magic; // set mp for bar

    }

    public void SetMagic(int magic) // set mp
    {
        slider.value = magic; // update the mp value


    }

}
