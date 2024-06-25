using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Very important for implementing Nav Mesh.
using UnityEngine.AI;

public class AI_Monster : MonoBehaviour
{

    //This is to locate the player
    public GameObject Player;

    private NavMeshAgent Nav;

    private Animator anim;

    //private GameManager gameManager;

    private PlayerMovement playerMovement;

    public int HP = 5;
    public int MaxHP = 5;
    public int attack = 5;
    FloatingHealthBar healthBar;

    //public GameObject monster1;

    public Transform targetPlayer;


    private bool isRunning = false;

    public bool isDead = false;


    private GameObject coin; // game object for coin
    public GameObject coinMaterial; 


    private GameObject healthPot; // game object for hp
    public GameObject healthPotPrefab;

    private GameObject manaPot; // game object for mp
    public GameObject manaPotPrefab;

    private GameObject key; // game object for key
    public GameObject KeyPrefab;

    int killRate = 5;

    public float radius = 3f; // radius for detection of player position


    // audio sources
    public AudioSource monsterAudio;
    public AudioClip deathSound;


    public GameObject dropItems; // items object

    public List<DropItems> dropList = new List<DropItems>(); // an array of items
    bool metPlayer = false; //check if enemies met player
    int frameCounter = 0; // counter of frame
    public float detectionRadius = 5.0f; // detection radius
    public string stageName; // differentiate the stage name
    public bool stage2 = false; // check if it's stage 2 now

    public GameManager gm; // Game Manager 

    // Start is called before the first frame update
    void Start()
    {

        healthBar = GetComponentInChildren<FloatingHealthBar>(); // instantiate floating hp bar

        Nav = GetComponent<NavMeshAgent>(); // instantiate navmesh
        anim = GetComponent<Animator>(); // instantiate animator
        Nav.speed = 5f; //set navigation speed
        anim.speed = 5f; // set animation speed
        healthBar.UpdateHealthBar(HP, MaxHP); // initialise hp bar 
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>(); // instantiate playerMovement

        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform; // get the player's position

        
        //Nav = GetComponentInChildren<NavMeshAgent>();
        monsterAudio = GetComponent<AudioSource>(); // instantiate audio for monster

        gm = GameObject.Find("GameManager").GetComponent<GameManager>(); // instantiate gameManager

        NoOfKills(); // getting kill rate depending on difficulty
        HealthOfZombie(); // setting health depending on difficulty

    }

    // Update is called once per frame
    void Update()
    {
        if (stageName == "stage1" && gm.stage2) // when stage2 begins
        {
            GameObject.Find("SpawnManagerMonster").GetComponent<SpawnManagerMonster>().currentAmountMon -= 1; // decrement number of enemies
            Destroy(gameObject); // destroy the stage 1 enemy
        }

        if (!isDead) // if the enemy is alive
        {
            //This is to tell the animation how fast the nav is going
            anim.SetFloat("velocity", Nav.velocity.magnitude);

            // This is to set its destination towards the player, allowing the monster to calculate the best route towards the enemy.
            //Nav.SetDestination(Player.transform.position);
            Nav.SetDestination(playerMovement.playerPos);

        }
        

        if(Vector3.Distance(transform.position, playerMovement.transform.position) <= detectionRadius) // when distance between players and enemy within radius
        {
            anim.SetBool("metPlayer", true); // start the attack animation
            metPlayer = true;
        }


        if (metPlayer) // if enemy meets player
        {
            frameCounter += 1; // counting frame

            if (frameCounter == 60) // after 60 frames
            {
                anim.SetBool("metPlayer", false); // turn off the attack animation
                metPlayer = false;  // setting back
                frameCounter = 0; // setting back
            }
        }
        






    }

    public void spawnItems() // this function lets the enemy drop item
    {
        int randomChance = Random.Range(1, 101);

        if (randomChance <= 25) // 25% probability
        {

            // Spawn the coid when the monster is dead
            manaPot = Instantiate(manaPotPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
            // display the coin
            manaPot.SetActive(true);


        }
        if (randomChance > 25 && randomChance <= 50) // another 25 %
        {
            // Spawn the coid when the monster is dead
            healthPot = Instantiate(healthPotPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
            // display the coin
            healthPot.SetActive(true);


        }
        if (randomChance > 50 && randomChance <= 97) // another 27 %
        {
            // Spawn the coid when the monster is dead
            coin = Instantiate(coinMaterial, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
            // display the coin
            coin.SetActive(true);


        }
        if (randomChance > 60) // if percentage 40
        {
            if (playerMovement.numberOfKills > killRate) // if number of kills is greater than 5
            {

                if (playerMovement.keyDropped == false || playerMovement.countForSecondMap > killRate) // if key wasn't dropped or second map counter > 5
                {
                    if (gm.stage2) // if stage 2
                    {
                        if (playerMovement.keyDropped == false && playerMovement.countForSecondMap > killRate) // if key wasn't dropped and second map counter > 5
                        {
                            

                            // Spawn the coid when the monster is dead
                            key = Instantiate(KeyPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                            // display the coin
                            key.SetActive(true);
                            playerMovement.keyDropped = true;
                        }
                    }
                    else
                    {

                        // Spawn the coid when the monster is dead
                        key = Instantiate(KeyPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                        // display the coin
                        key.SetActive(true);
                        playerMovement.keyDropped = true;
                    }

                }

            }

        }




    }

    void HealthOfZombie() // this function sets the health of the enemy depending on its difficulty
    {
        // This is to set if the diff set in unity.
        // Each difficulty button is set with its own difficulty and when the spawninterval divides it difficulty, the spawn of 
        // obstacles and powerups will decrease.
        int diff = gm.diff;
        if (diff == 1)// if beginner difficulty
        {
            HP = HP * diff;
            MaxHP = MaxHP * diff;
        }
        else if (diff == 2) // if medium difficulty
        {
            HP = HP * diff;
            MaxHP = MaxHP * diff;
        }
        else if (diff == 3) // if nightmare difficulty
        {
            HP = HP * diff;
            MaxHP = MaxHP * diff;
        }
    }


    void NoOfKills() // this function sets the kill rate depending on its difficulty
    {
        int diff = gm.diff;


        if (diff == 1) // if beginner difficulty
        {
            killRate = killRate * diff;
        }
        else if (diff == 2) // if beginner difficulty
        {
            killRate = killRate * diff;
        }
        else if (diff == 3) // if nightmare difficulty
        {
            killRate = killRate * diff;
        }



    }







    public void TakeDamage(int damage) // this function takes damage for the enemy from player
    {
        HP -= damage; // decrease the enemy's hp
        if (HP < 0) // just to make sure hp shouldn't be less than 0 for any further errors
        {
            HP = 0;
        }
        healthBar.UpdateHealthBar(HP, MaxHP); // update hp
        if (HP <= 0) // if enemy dies
        {
            healthBar.gameObject.SetActive(false); // remove hp bar

            
            Rigidbody rb = GetComponent<Rigidbody>(); 
            rb.isKinematic = true; // make enemy not being pushed
            Nav.enabled = false; // make it stop



            anim.SetBool("isDead", true); // start death animation
            if (!isDead) // dead for the first time only
            {
                playerMovement.numberOfKills += 1; // increment number of kill

            }
            isDead = true; // set it dead

            playerMovement.UpdateKills(); // update the kill
            if (GameObject.Find("GameManager").GetComponent<GameManager>().stage2) // if stage2
            {
                playerMovement.countForSecondMap += 1; // count number of kill for the stage2
            }

            StartCoroutine(DestroyAfterAnimation(1.0f)); // to make enemy's death animation played properly before its detroyed

            monsterAudio.PlayOneShot(deathSound, 0.5f); // play the death sound
        }
    }
    private IEnumerator DestroyAfterAnimation(float delay) // this function waits amount of delay before it is destroyed
    {
        yield return new WaitForSeconds(delay); 
        GameObject.Find("SpawnManagerMonster").GetComponent<SpawnManagerMonster>().currentAmountMon -= 1; // decrement current amount of monsters
        Destroy(gameObject); // destroy

        spawnItems(); // spawn items
    }


}