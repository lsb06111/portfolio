using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public GameObject player; // player object

    float rotationX; // x rotation
    float rotationY; // y rotation

    public float sensitivityX; // sensitivity for X
    public float sensitivityY; // sensitivity for Y

    public Transform orientation; // just for the storation of the camera rotation

    private GameManager gameManager; // game manager

    public float sensitivity = 15f; // set sensitivity

    private bool isLocked = false; // checking if mouse is locked

    public Transform cameraRotation; // get camera rotation


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // initialise the game manager script


    }

    // Update is called once per frame
    void Update()
    {

        moveMouse(); // call the mouse move function
        cameraRotation = transform; // update current camera rotation with transform. 
        if (gameManager.isGameActive) // if game is active
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivityX; // get the mouse X value based on mouse x position and its sensitivity
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivityY; // get the mouse Y value based on mouse y position and its sensitivity

            rotationY += mouseX; // calculation for rotation Y

            rotationX -= mouseY; // calculation for rotation X

            rotationX = Mathf.Clamp(rotationX, -90f, 90f); // further calculation for rotation X

            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0); // change the current rotation based on the values above



            orientation.rotation = Quaternion.Euler(0, rotationY, 0); // keep the rotation value for the camera

            player.transform.rotation = Quaternion.Euler(0f, rotationY, 0f); // also rotates the player so that it doesn't look awkward as the camera moves




        }



    }

    

    public void SetSensitivity(float value) // this function sets the sensitivity
    {
        sensitivityX = value; // set x
        sensitivityY = value; // set y

    }

    
    public void MoveMouseForResume() // this function makes the mouse movement enabled with a lock state
    {
        rotationY = player.transform.eulerAngles.y; // get rotation y of the player
        Cursor.visible = false; // make the cursor invisible
        Cursor.lockState = CursorLockMode.Locked; // cursor in a locked mode
                                                  //Cursor.lockState = CursorLockMode.Un
        isLocked = true; // make it lock
    }


    void moveMouse() //this function makes the mouse movement move
    {
        
        if (gameManager.isGameActive) // if game is on active
        {
            
            if (isLocked == false) // if the mouse is not locked
            {
                rotationY = player.transform.eulerAngles.y; //  get rotation y of the player
                Cursor.visible = false; // make the cursor invisible
                Cursor.lockState = CursorLockMode.Locked; // cursor in a locked mode
                //Cursor.lockState = CursorLockMode.Un
                isLocked = true; // make it lock
            }
        }
    }
}
