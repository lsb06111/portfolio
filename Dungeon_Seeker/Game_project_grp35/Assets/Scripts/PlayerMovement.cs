using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    //localhost:56644
    public float speed; // speed of the player
    public RectTransform aimRectTransform;


    public Transform orientation; // get orientation of the camera

    private float horizontalInput; // for horizontal movement
    private float verticalInput; // for vertical movement

    Vector3 moveDirection; // get the move direction

    public GameObject[] magicBalls; // get sets of magic balls

    public float yOffset = 3.61f; // set the y offset for the magic ball
    public Vector3 playerPos; // get player position

    public int currentBallIndex = 0; // this is for magic ball selection
     
    public int numberOfKills = 0; // counts the number of kills
     
    public TextMeshProUGUI killsText; // text of kills

    // Added a collecting coin system
    public TextMeshProUGUI coinsText;

    Rigidbody rb; // rigidbody

    // outline for which magic ball is selected in the screen
    public GameObject outline1;
    public GameObject outline2;

    public bool keyDropped = false; // checks if key has been already dropped

    public int coinAmount=0; // number of coins collected

    public GameObject keyImage; // get the image of key

    OpenBossGate openBossGate; // script for bossgate1


    Openbossgate2 openbossgate2;// script for bossgate2

    OpenBossGate3 openbossgate3;// script for bossgate3

    public bool gotKey = false; // checks if player got the key

    public GameObject boss1; // object for boss 1
    public GameObject auraForBoss1; // object for boss1 aura
    public GameObject boss2; // object for boss 2
    public GameObject auraForBoss2; // object for boss2 aura

    private GameManager gameManager; // game manager

    public bool isBoss1Dead = false; // checks if boss1 dead
    public bool isBoss2Dead = false; // checks if boss2 dead

    public Toast toast; // toast message
    public GameObject toastObject; // get toast object

    //Health
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthbar;

    //Mana point
    public int maxMagic = 100;
    public int currentMagic;
    public MagicBar magicbar;

    public NavMeshAgent Nav; // get nav mesh

    int consumeMana; // amount of required mana for one shot

    AI_Monster enemy; // get enemy
    AI_Orc orc; // get orc
    MiniBoss_2 boss1_scripts; // get boss1 script

    public GameObject pauseScene; // object for pause scene
    public GameObject mainCamera; // object for main camera

    bool isGate1Open = false; // checks if gate1 opened
    bool isGate2Open = false; // checks if gate2 opened
    bool isGate3Open = false; // checks if gate3 opened

    bool isESCPressed = false; // checks if ESC is pressed

    public int magicBallDamage = 5; // magic ball damage
    public int countForSecondMap = 0; // count number of enemies in second map

    // For the audio source in unity
    public AudioSource playerAudio;

    public AudioClip shootMagic;

    public AudioClip tookDamage;

    public AudioClip doorOpenSound;

    public AudioClip pickUpLoot;

    public Camera mainCamera_; // get another main camera
    Vector3 aimWorldPos; // get world position for aiming

    Canvas canvas; // get canvas
    Vector2 aimScreenPos; // get aiming screen position
    int frameCounter = 0; // counter of frame
    int requiredMp = 5; // amount of required mp
    bool firstCoin = true; // checks if the player gets the first coin
    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // initialise game manager
        rb = GetComponent<Rigidbody>(); // get the player's rigidbody
        rb.freezeRotation = true; // freeze the rotation
        openBossGate = GameObject.Find("bossgate1").GetComponent<OpenBossGate>(); // initialise the boss gate1

        openbossgate2 = GameObject.Find("bossgate2").GetComponent<Openbossgate2>(); // initialise the boss gate2
        openbossgate3 = GameObject.Find("bossgate3").GetComponent<OpenBossGate3>(); // initialise the boss gate3

        Nav = GetComponent<NavMeshAgent>(); // get nav mesh
        currentHealth = maxHealth; // hp
        currentMagic = maxMagic; // mp

        enemy = GetComponent<AI_Monster>(); // enemy script
        orc = GetComponent<AI_Orc>(); // orc script
        boss1_scripts = GetComponent<MiniBoss_2>(); // boss1 script

        toast = toastObject.GetComponent<Toast>(); // toast script

        playerAudio = GetComponent<AudioSource>(); // get audio
        canvas = aimRectTransform.GetComponentInParent<Canvas>(); // initialise canvas
        


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !collision.gameObject.GetComponent<AI_Monster>().isDead ) // if met non-dead enemy
        {
            currentHealth -= 5; // get damage by 5
            playerAudio.PlayOneShot(tookDamage, 0.5f); // play taking damages sound

        }
        if (collision.gameObject.CompareTag("Orc") && !collision.gameObject.GetComponent<AI_Orc>().isDead) // if met non-dead enemy
        {
            currentHealth -= 15; // get damage by 15
            playerAudio.PlayOneShot(tookDamage, 0.5f);

        }

        if (collision.gameObject.CompareTag("Boss1") || collision.gameObject.CompareTag("boss1_attack")) // if met boss1 or its attack
        {
            currentHealth -= 30; // get damage by 30
            playerAudio.PlayOneShot(tookDamage, 0.5f); // play taking damages sound

        }
        if (collision.gameObject.CompareTag("Boss2") || collision.gameObject.CompareTag("Bullet")) // if met boss2 or its bullet
        {
            currentHealth -= 30; // get damage by 30
            playerAudio.PlayOneShot(tookDamage, 0.5f); // play taking damages sound

        }
        healthbar.SetHealth(currentHealth); // update hp
        if (collision.gameObject.CompareTag("nonBossGate") && gotKey)// if met non boss gate but got key
        {
            gameManager.SetQuest("I can't open this door.. \n I should find another one.."); // set quest message
        }

    }

    // Update is called once per frame
    void Update()
    {
      
        SetKeyInputs(); // set the key inputs
        if (gameManager.isGameActive)
        {

            if (Input.GetKeyDown(KeyCode.T)) // if T pressed
            {
                pauseScene.SetActive(true); // make pause scene active
                gameManager.isGameActive = false; // make game stop
                Time.timeScale = 0; // make time stop
                isESCPressed = true; // make the key pressed true

                Cursor.visible = true; // make the cursor visible
                Cursor.lockState = CursorLockMode.None; // cursor in a unlocked mode
            }

            frameCounter += 1; // increment the frame counter
            if (currentMagic < 5) // if current mp is less than 5
            {
                toast.ShowToast("Not Enough MP"); // show the toast
            }else
            {
                if (Input.GetMouseButtonDown(0)) // 0 is for left mouse button
                {
                    Debug.Log("Left mouse button clicked!");

                    canvas = aimRectTransform.GetComponentInParent<Canvas>(); // get current canvas position
                    aimScreenPos = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, aimRectTransform.position); // convert the position into screen
                    aimWorldPos = mainCamera_.ScreenToWorldPoint(new Vector3(aimScreenPos.x, aimScreenPos.y, 0)); // convert the screen position into the world position



                    GameObject newMagicBall = Instantiate(magicBalls[currentBallIndex], aimWorldPos, orientation.rotation); // instantiate the new magicball

                    

                    newMagicBall.GetComponent<MagicBall>().damage = magicBallDamage; // set the damage
                    // Pass the orientation's forward direction to the magic ball
                    //newMagicBall.GetComponent<MagicBall>().moveDirection = orientation.forward;


                    newMagicBall.GetComponent<MagicBall>().moveDirection = mainCamera.GetComponent<MouseMovement>().cameraRotation.forward; // set the direction





                    currentMagic -= requiredMp; // decrement mp
                    magicbar.SetMagic(currentMagic); // update mp


                    playerAudio.PlayOneShot(shootMagic, 0.5f); // play the sound
                }
            }
            


            if (Input.GetKeyDown(KeyCode.Alpha1)) // electric ball 1 pressed
            {
                if (currentBallIndex == 1) // when only fire ball selected
                {
                    magicBallDamage = magicBallDamage - 5;  // make magicball damage decreased
                    requiredMp = 3; // make required mp 3

                }
                currentBallIndex = 0; // set current index to 0
                outline2.SetActive(false); // disable outline for fireball
                outline1.SetActive(true); // enable outline for electric ball
            }
            if (Input.GetKeyDown(KeyCode.Alpha2)) // fire ball 2 pressed
            {
                if(currentBallIndex == 0) // when only electric ball selected
                {
                    magicBallDamage = magicBallDamage + 5; // make magicball damage increased

                    requiredMp = 8; // make required mp 8
                }

                currentBallIndex = 1; // set current index to 1
                outline2.SetActive(true); // enable outline for fireball
                outline1.SetActive(false); // enable outline for electric ball

            }

            if(currentMagic < 100) // if not full mana
            {
                if(frameCounter % 50== 0 && frameCounter > 0) // every 50 frame
                {
                    currentMagic += 1; // recover currrent mp
                    magicbar.SetMagic(currentMagic); // update mp bar
                    frameCounter = 0; // make it zero prevent overflow
                }
            }

            


        }

        else // if game is inactive
        {
            if (isESCPressed && Input.GetKeyDown(KeyCode.Escape)) // if ESC key pressed
            {
                
                pauseScene.SetActive(false); // make the pause scene invisible
                gameManager.isGameActive = true; // make the game resumed
                Time.timeScale = 1; // make the time resumed
                isESCPressed = false; // make it false
                mainCamera.GetComponent<MouseMovement>().MoveMouseForResume(); // make the mouse movement resumed
            }
        }

        
    
}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin") // if player gets the coin
        {
            Debug.Log("Coin is collected");
            // Plus coins everytime player collects the coins
            coinAmount++;
            // Destroy the coin when it is collected
            Destroy(other.gameObject);
            //Display the amount of coins on the top right
            coinsText.text = "Coin: " + coinAmount;
            if (firstCoin) // if it's first coin
            {
                gameManager.SetQuest("I think I can upgrade myself with this coin.."); // set quest message
                firstCoin = false; // make it false for above code to be called only once
            }
            playerAudio.PlayOneShot(pickUpLoot, 0.5f); // make the sound

        }

        else if (other.gameObject.tag == "HP") // if player gets the HP potion
        {
            Debug.Log("HP is collected");

            if(currentHealth + 30 > maxHealth) // if  recovered hp is greater than its max hp
            {
                currentHealth = maxHealth; // set it to max health
            }
            else
            {
                currentHealth += 30; // recover hp by 30
            }

            healthbar.SetHealth(currentHealth); // update hp bar


            // Destroy the hp potion when it is collected
            Destroy(other.gameObject);
            //play pickup sound
            playerAudio.PlayOneShot(pickUpLoot, 0.5f);


        }
        else if (other.gameObject.tag == "MP") // if gets mp potion
        {
            Debug.Log("MP is collected");
            // Plus coins everytime player collects the coins

            if (currentMagic + 30 > maxMagic) // if recover mp is greater than its max mp
            {
                currentMagic = maxMagic; // set it to max mp
            }
            else
            {
                currentMagic += 30; // recover mp by 30
            }
            magicbar.SetMagic(currentMagic); // update mp bar

            // Destroy the mp potion when it is collected
            Destroy(other.gameObject);
            //play pickup sound
            playerAudio.PlayOneShot(pickUpLoot, 0.5f);


        }
        else if (other.gameObject.tag == "Key") // gets a key
        {
            Debug.Log("Key is collected");

            Destroy(other.gameObject); // destroy the key

            gameManager.SetQuest("Yes, finally I found the key.. \n There must be a door somewhere here.."); // set the quest message


            
            gotKey = true; // got key true
            keyImage.SetActive(true); // make key image visible

            playerAudio.PlayOneShot(pickUpLoot, 0.5f); // play pickup sound
        }

        
        if(other.gameObject.tag== "bossgate1" && gotKey) // if close to bossgate1 with the key
        {
            gameManager.SetQuest("The door is opening! \n I can feel the presence of a boss, it’s getting quite hot.");// set the quest message
            openBossGate.openGates = true; // open the gate
            keyImage.SetActive(false); // make key image invisible
            Instantiate(boss1, new Vector3(60, 0, 120), Quaternion.identity); // instantiate the boss 1
            Instantiate(auraForBoss1, new Vector3(60, 0, 120), Quaternion.identity); // instantiate the boss1 aura
            gotKey = false; // got key false
            playerAudio.PlayOneShot(doorOpenSound, 5f); // play door open sound
            isGate1Open = true; // make gate1 open true

        }

        if (other.gameObject.tag == "bossgate2" && gotKey) // if close to bossgate2 with the key
        {
            openbossgate2.StartOpeningGates(); // open gate 2
            gameManager.SetQuest("The door is opening! \n I should find another key to escape here."); // set the quest message

            keyImage.SetActive(false); // make key image invisible

            isGate2Open = true; // gate2 open

            gotKey = false; // got key false
            keyDropped = false; // key dropped false again for further key drops
            playerAudio.PlayOneShot(doorOpenSound, 5f); // play door open sound

        }
        if (other.gameObject.tag == "bossgate3" && gotKey) // if close to bossgate3 with the key
        {
            openbossgate3.StartOpeningGates(); // open the gate 3
            gameManager.SetQuest("Another boss, its more powerful than the previous one \n it’s getting kind of chilly.");// set the quest message

            keyImage.SetActive(false); // make key image invisible
            Instantiate(boss2, new Vector3(-2.3f, 0, 303), Quaternion.identity); // instantiate the boss 2
            Instantiate(auraForBoss2, new Vector3(-2.3f, 0, 303), Quaternion.identity); // instantiate boss2 aura
            keyDropped = true; // key is dropped

            isGate3Open = true; // gate3 is opened

            gotKey = false; // got key false

            playerAudio.PlayOneShot(doorOpenSound, 5f); // play door open sound

        }
        //if trying to open any gate without the key
        if( (other.gameObject.tag=="bossgate1" && !gotKey && !isGate1Open) || (other.gameObject.tag == "bossgate2" && !gotKey && !isGate2Open) || (other.gameObject.tag == "bossgate3" && !gotKey && !isGate3Open))
        {
            gameManager.SetQuest("I think this is the door but it's locked.. \n There's gotta be a key somewhere...");// set the quest message
        }

    }

    public void UpdateKills() // this function updates the number of kills
    {
        killsText.text = numberOfKills + " Kills"; // update the text
    }

    private void FixedUpdate() // for the fixed update
    {
        MovePlayer(); // make the player move
    }


    private void SetKeyInputs() // this function sets the key inputs
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); // sets horizontal input
        verticalInput = Input.GetAxisRaw("Vertical"); // sets vertical input

    }

    private void MovePlayer() // this function makes the player move
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput; // set the direction for where to move
        Vector3 velocity = moveDirection.normalized * speed; // get a velocity so that the player doesn't move on the slippery floor
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z); // Keep the y velocity unchanged

        playerPos = transform.position; // update player position

    }
}
