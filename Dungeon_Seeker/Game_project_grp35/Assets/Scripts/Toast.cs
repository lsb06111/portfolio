using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Toast : MonoBehaviour
{
    public TextMeshProUGUI toastText;
    bool isShown = false;
    int frameCounter = 0;
    string currentMessage;
    bool differentMessage = false;
    Color color;
    float colorA;

    private void Start()
    {
        color = toastText.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShown) // if the toast message is shown
        {
            frameCounter += 1; // start counting frame

            if(frameCounter %2==0 && frameCounter > 0) // every two frames,
            {
                color = toastText.color; // get the current color
                colorA = color.a; // get alpha of the text
                colorA -= 5; // decrement the alpha
                color.a = colorA; // replace back
                toastText.color = color; // replace back
                if (colorA == 0) // if alpha is 0
                {
                    frameCounter = 0; // set it back to 0
                    isShown = false; // toast message is not shown
                }
            }
        }
    }


    public void ShowToast(string message) // this function shows the toast message
    {
        currentMessage = message; // set current message

        if(currentMessage != message) // if there's different message comes up
        {
            differentMessage = true; // different message true
        }
        toastText.text = message; // set the toast text

        color = toastText.color; // get the color of the text
        color.a = 255; // set the alpha to 255
        toastText.color = color; // replace back

        isShown = true; // make it show


    }

  
}
