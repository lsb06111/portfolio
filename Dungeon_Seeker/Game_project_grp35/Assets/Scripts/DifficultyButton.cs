using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This is to enable us to interact with the buttons in unity.
using UnityEngine.UI;
//This is useful for restart button.
using UnityEngine.SceneManagement;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    //This is to set the difficulty for each button in unity
    public int difficulty;
    // Start is called before the first frame update

    void Start()
    {
        // This code is very important
        // This code allows 2 scripts to communicate with each other.
        // By using the gameobjet to find the file called game manager and name it as gameManager.
        // Thus when we use gameManager in other scripts, it will know what it is refering to.
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //This is to activate the button component.
        button = GetComponent<Button>();

        // This is to check if the button is clicked and if so it will show run the method in the bracket.
        button.onClick.AddListener(SetDifficulty);



    }

    // Update is called once per frame
    void Update()
    {

    }
    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        // This will start the game when the button is pressed according to the difficulty.
        gameManager.StartGame(difficulty);
    }
}
