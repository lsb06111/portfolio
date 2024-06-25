using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// import the library of TMPRo
using TMPro;
//This is useful for restart button.
using UnityEngine.SceneManagement;
//This is to enable us to interact with the buttons in unity.
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    //This is to call the spawnmanager monster.
    public SpawnManagerMonster spawnManagerMon;
    // This is to set the variable to the name scoretext
    public TextMeshProUGUI timeText;

    //public SpawnManagerPU spawnManagerPU;

    //public SpawnManager spawnManager;
    

    public TextMeshProUGUI youWinText;

    //This is to indicate the gameover text
    public TextMeshProUGUI gameOverText;
    // This is t indicate whether the game is active or not.
    public bool isGameActive;
    // This is to indicate the restart button.
    public Button restartButton;
    // This is to indicate the title screen object in unity.
    public GameObject titleScreen;
    // set the time to 300
    public float time = 300;
    // To make the finish line
    public GameObject finishLine;
    // To pull the difficulty from the start game so spawn manager can use it.
    public int diff;

    public GameObject mainCamera; // object for main camera

    public GameObject pauseScene; // object for pause scene

    public GameObject settingScene; // object for setting scene

    public int bossCount = 0; // number of boss defeated
    public GameObject popupHTP;  // object for How To Play

    public Slider sensSlider; // sensitivity slider

    public float oldSensValue; // old sensitivity value
    public TextMeshProUGUI sensText; // text in sensivity scene

    public GameObject storeScene;  // object for store scene

    public TextMeshProUGUI hp; // text of hp
    public TextMeshProUGUI mp; // text of mp
    public TextMeshProUGUI attack; // text of attack
    public TextMeshProUGUI speed; // text of speed


    public GameObject magicBall;  // object for magic ball


    public bool isBoss1Completed = false; // checks if boss1 defeated
    public GameObject winScene;  // object for win scene

    int hpUpgrade = 0; // number of upgrade of hp
    int mpUpgrade = 0; // number of upgrade of mp
    int attackUpgrade = 0; // number of upgrade of attack
    float speedUpgrade = 0;// number of upgrade of speed


    public TextMeshProUGUI amountOfCoin; // text of amount of coin

    PlayerMovement player; // player movement script

    public bool stage2 = false; // stage2 or stage1

    public bool gameWin = false; // win or not
    public GameObject gameOverScene; // object for game over scene


    public bool isQuest; // check if quests
    public TextMeshProUGUI questText; // text of quest
    public GameObject questIndicator; // object for the quest

    float duration = 5.0f;  // duration in seconds for fadeout
    float counter = 0; // frame counter
    Color textColor; // color of the text
    float alpha; // a value in color
    public Image questBG; // background of quest
    Color bgColor; // color of background
    public string questMessage; // contents of quest

    public TextMeshProUGUI winText; // text of win




    // Start is called before the first frame update
    void Start()
    {
        sensSlider.value = 75; // initialise the first sensitivity 75
        oldSensValue = sensSlider.value; // initialise the old sensitivity value
        player = GameObject.Find("Player").GetComponent<PlayerMovement>(); // initialise the player movement script
        isQuest = true; // quest true
        textColor = questText.color; // get the quest color
        bgColor = questBG.color; // get the background colour 
        questMessage = "One of the monsters must have a key..."; // set the first quest message
        questText.text = questMessage; // set the first quest message
        //Screen.SetResolution(640, 480, true);


    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive && isQuest) // if game started and if there's any quest
        {
            
            if(counter < duration) // only for the duration
            {
                questIndicator.SetActive(true); // make it visible
                counter += Time.deltaTime; // counting time
                alpha = Mathf.Lerp(1, 0, counter / duration); //make the alpha slightly decreased
                questText.color = new Color(textColor.r, textColor.g, textColor.b, alpha); // update the color of the quest
                questBG.color = new Color(bgColor.r, bgColor.g, bgColor.b, alpha); // update the background colour of the quest


            }
            else // after duration
            {
                questIndicator.SetActive(false); // make is invisible
                isQuest = false; // there is no quest
                counter = 0; // set it back
            }
        }

        if (oldSensValue != sensSlider.value) // if the slider value has been changed
        {
            oldSensValue = sensSlider.value; // save the current value into the old one for the further checking
            sensText.text = oldSensValue + ""; // update the sensitivity text
            mainCamera.GetComponent<MouseMovement>().SetSensitivity(oldSensValue); // set the new sensitivity
        }

        if (Input.GetKeyDown(KeyCode.Alpha5)) // if key 5 pressed
        {
            PopUpShop(); // pop up the store
            isGameActive = false; // make the game pause
            Time.timeScale = 0; // make the game pause

            Cursor.visible = true; // make the cursor visible
            Cursor.lockState = CursorLockMode.None; // cursor in a unlocked mode
        }

        if(player.currentHealth <= 0) // if player dead
        {
            gameOverScene.SetActive(true); // game over scene visible
            isGameActive = false; // make the game stop
            Time.timeScale = 0; // make the game pause

            Cursor.visible = true; // make the cursor visible
            Cursor.lockState = CursorLockMode.None; // cursor in a unlocked mode
        }
        if (gameWin)
        {
            winScene.SetActive(true); // win scene visible
            isGameActive = false;// make the game stop
            Time.timeScale = 0; // make the game pause

            Cursor.visible = true; // make the cursor visible
            Cursor.lockState = CursorLockMode.None; // cursor in a unlocked mode
        }

    }
    public void SetQuest(string msg) // this function sets the quest
    {
        questIndicator.SetActive(false); //make the previous one invisible
        isQuest = false; // set the previous quest false
        counter = 0; // set it back to 0
        questMessage = msg; // set the quest messsage
        questText.text = questMessage; // set the quest text
        isQuest = true; // make the current quest true
    }
    public void RestartGame()
    {
        //It uses the scenemanager class and load the scene that we need.
        // the scenemanager will take the active scene and get the name of it which is the string.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Note to use the button in unity, click on the button and scroll down
        // It will have a list there. Add the script u need for the button and set the function as needed 
        // In this case it is the restart button.
    }

    public void StartGame(int difficulty)
    {
        // This is to pull the spawn manager power up class to use its methods
        spawnManagerMon = GameObject.Find("SpawnManagerMonster").GetComponent<SpawnManagerMonster>();


        //This is to set the game active when the game starts
        // VERY IMPORTANT : like most programming languages, it run by sequence of the lines so if the code is not placed at the right
        // // order, it will break teh game.
        isGameActive = true;


        //This is to divide spawnrate by difficulty e.g spawnRate/Difficulty 1/1, 1/2, 1/3.
        //spawnInterval /= difficulty;

        //This is to start the spawn timer.
        //StartCoroutine(SpawnTarget());

        // This is to pull the difficulty from startgame and allow spawn manager to use it.
        diff = difficulty;

        if(diff == 1) //if beginner difficulty
        {
            winText.text = "Congratulations you escaped! \n but it looks like your battle is not over yet."; // change the win scene content
        }
        else if (diff == 2) //if medium difficulty
        {
            winText.text = "Another floor cleared, one more to freedom.\n Just one more to go, so close to taking your revenge."; // change the win scene content
        }
        else if (diff == 3) //if nightmare difficulty
        {
            winText.text = "Wow congratulations you cleared the game! \n time to have your revenge against the world."; // change the win scene content
        }

        // This is needed as it shows the default score which is 0 before starting.
        // UpdateScore(0);
        //This will hide the title screen when the game starts
        // When the game stops and restarts it will appear again
        titleScreen.gameObject.SetActive(false);

        // This is to run the spawn managers when the game starts
        spawnManagerMon.Begin();

        Time.timeScale = 1; // make the game start
        mainCamera.GetComponent<MouseMovement>().MoveMouseForResume(); // make mouse movement resume



    }


    public void Restart() // restart the game
    {
        RestartGame();
    }
    public void Resume() // resumes the game
    {
        Time.timeScale = 1; // make the game start
        pauseScene.SetActive(false); // set pause scene invisible
        isGameActive = true; // set the game active
        mainCamera.GetComponent<MouseMovement>().MoveMouseForResume(); // make mouse movement resume
    }

    public void CloseShop() // close the store
    {
        storeScene.SetActive(false); // set store scene invisible
        Time.timeScale = 1; // make the game start
        isGameActive = true; // set the game active
        mainCamera.GetComponent<MouseMovement>().MoveMouseForResume(); // make mouse movement resume
    }
    public void GoSetting() // open up the setting
    {

        settingScene.SetActive(true); // make setting scene visible

    }
    public void CloseSetting() // close the setting
    {
        settingScene.SetActive(false);  // make setting scene invisible
    }

    public void PopUpHTP() // open How To Play
    {

        popupHTP.SetActive(true); // make HTP visible

    }
    public void CloseHTP() // close How To Play
    {
        popupHTP.SetActive(false); // make HTP invisible
    }

    public void PopUpShop() // open store
    {
        storeScene.SetActive(true); // make the store scene visible
        amountOfCoin.text = "You Have: " + player.coinAmount + " coins"; // update current amount of coin

    }


    public void upgradeHP() // this function upgrades hp
    {
        if(player.coinAmount > 0) // only if player has more than 0 coins
        {
            player.maxHealth += 10; // increase max hp
            player.currentHealth += 10; // increase current hp
            player.healthbar.SetHealth(player.currentHealth); // update hp
            //for display
            hpUpgrade += 10;
            hp.text = "+" + hpUpgrade;
            player.coinAmount -= 1;
            amountOfCoin.text = "You Have: " + player.coinAmount + " coins";
            player.coinsText.text = "Coin: " + player.coinAmount;
        }
        else // if 0 coin
        {
            player.toast.ShowToast("Not Enough Coin!"); // show the toast message
        }
        
    }
    public void upgradeMP() // this function upgrades mp
    {
        if (player.coinAmount > 0) // only if player has more than 0 coins
        {
            player.maxMagic += 10; // increase max mp
            player.currentMagic += 10; // increase current mp
            player.magicbar.SetMagic(player.currentMagic); // update mp
            //for display
            mpUpgrade += 10;
            mp.text = "+" + mpUpgrade;
            player.coinAmount -= 1;
            amountOfCoin.text = "You Have: " + player.coinAmount + " coins";
            player.coinsText.text = "Coin: " + player.coinAmount;

        }
        else // if 0 coin
        {
            player.toast.ShowToast("Not Enough Coin!"); // show the toast message
        }

    }
    public void upgradeAttack() // this function upgrades attack
    {
        if (player.coinAmount > 0) // only if player has more than 0 coins
        {

            player.magicBallDamage += 1; // increase damage
            //for display
            attackUpgrade += 1;
            attack.text = "+" + attackUpgrade;

            player.coinAmount -= 1;
            amountOfCoin.text = "You Have: " + player.coinAmount + " coins";
            player.coinsText.text = "Coin: " + player.coinAmount;
        }
        else // if 0 coin
        {
            player.toast.ShowToast("Not Enough Coin!"); // show the toast message
        }
    }
    public void upgradeSpeed() // this function upgrades speed
    {
        if (player.coinAmount > 0) // only if player has more than 0 coins
        {
            player.speed += 0.5f; // increase the speed

            //for display
            speedUpgrade += 0.5f;
            speed.text = "+" + speedUpgrade;

            player.coinAmount -= 1;
            amountOfCoin.text = "You Have: " + player.coinAmount + " coins";
            player.coinsText.text = "Coin: " + player.coinAmount;
        }
        else // if 0 coin
        {
            player.toast.ShowToast("Not Enough Coin!"); // show the toast message
        }
    }

}
