using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Orc : MonoBehaviour
{
    //This is to locate the player
    public GameObject Player;

    private NavMeshAgent Nav;

    private Animator anim;

    private PlayerMovement playerMovement;

    public int HP = 10;
    public int MaxHP = 10;
    public int attack = 15;

    FloatingHealthBar healthBar;

    //public GameObject monster1;

    public Transform targetPlayer;


    private bool isRunning = false;


    public GameObject coinMaterial;

    private GameObject coin;


    //private GameManager gameManager;


    // hp bar
    private GameObject healthPot;
    public GameObject healthPotPrefab;

    //mp bar
    private GameObject manaPot;
    public GameObject manaPotPrefab;

    // key
    private GameObject key;
    public GameObject KeyPrefab;

    bool keyDropped = false;

    public float radius = 3f; // for detection radius

    public bool isDead = false; // check if enemy dead

    public string stageName; // differentiate stage name
    public bool stage2 = false; // if stage2


    int killRate = 5; // current kill rate



    public GameObject dropItems; // object of items

    public SpawnManagerMonster spawnManagerMonster; // spawn manager script

    public List<DropItems> dropList = new List<DropItems>(); // list of items
    bool metPlayer = false; // check if the enemy met player
    int frameCounter = 0; // counter of frame
    public float detectionRadius = 5.0f; // detection radius

    public GameManager gm; // game manager

    //audio
    public AudioSource orcAudio; 
    public AudioClip deathSound;

    int frameCounter2 = 0;
    // Start is called before the first frame update
    void Start()
    {

        healthBar = GetComponentInChildren<FloatingHealthBar>(); // initialise hp bar

        Nav = GetComponent<NavMeshAgent>(); // get nav mesh
        anim = GetComponent<Animator>(); // get animator
        Nav.speed = 2f; // set the speed of nav mesh movement
        anim.speed = 2f; // set the speed of animation
        healthBar.UpdateHealthBar(HP, MaxHP); // set the hp bar
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>(); // initialise player movement

        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform; // set the target player

        orcAudio = GetComponent<AudioSource>(); // initialise audio
        //Nav = GetComponentInChildren<NavMeshAgent>();


        gm = GameObject.Find("GameManager").GetComponent<GameManager>(); // game manager

        HealthOfOrc(); //set the health of orc
        NoOfKills(); // set kill rate of orc

    }

    // Update is called once per frame
    void Update()
    {

        if(stageName == "stage1" && gm.stage2) // if the current orc is spawned in stage 1 but the game is stage2
        {
            GameObject.Find("SpawnManagerMonster").GetComponent<SpawnManagerMonster>().currentAmountMon -= 1; // decrement the current number of monster
            Destroy(gameObject); // destroy
        }

        if (!isDead)
        {
            //This is to tell the animation how fast the nav is going
            anim.SetFloat("velocity", Nav.velocity.magnitude); 

            // This is to set its destination towards the player, allowing the monster to calculate the best route towards the enemy.
            //Nav.SetDestination(Player.transform.position);
            Nav.SetDestination(playerMovement.playerPos);
        }
        

        if (Vector3.Distance(transform.position, playerMovement.transform.position) <= detectionRadius) // if the player is near
        {
            anim.SetBool("metPlayer", true); //make the animation start
            metPlayer = true; // player met
        }


        if (metPlayer) // if met
        {
            frameCounter += 1; // count the frame count

            if (frameCounter == 60) // after 60 frames
            {
                anim.SetBool("metPlayer", false); // turn off the animation
                metPlayer = false; // set it back
                frameCounter = 0; // set it back
            }
        }





    }



    public void spawnItems() // this functions drops items
    {
        int randomChance = Random.Range(1, 101); // initialising the probability set

        if (randomChance <= 25) // if 25%
        {
            //conver the position
            Vector3 position = transform.position;

            // Spawn the coid when the monster is dead
            manaPot = Instantiate(manaPotPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
            // display the coin
            manaPot.SetActive(true);


        }
        if (randomChance > 25 && randomChance <= 50) // if another 25%
        {
            //conver the position
            Vector3 position = transform.position;

            // Spawn the coid when the monster is dead
            healthPot = Instantiate(healthPotPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
            // display the coin
            healthPot.SetActive(true);


        }
        if (randomChance > 50 && randomChance <= 97) // if another 27%
        {
            //conver the position
            Vector3 position = transform.position;

            // Spawn the coid when the monster is dead
            coin = Instantiate(coinMaterial, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
            // display the coin
            coin.SetActive(true);


        }
        if (randomChance > 60) // if 40 %
        {
            if (playerMovement.numberOfKills > killRate) // number of kills should be greater than kill rate
            {
                 
                if (playerMovement.keyDropped == false || playerMovement.countForSecondMap > killRate) // either key hasn't dropped or number of kills for second map is greater than kill rate
                {
                    if (gm.stage2) // if stage2
                    {
                        if(playerMovement.keyDropped == false && playerMovement.countForSecondMap > killRate) // both of them true
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


    void HealthOfOrc() // this function sets the health of orc
    {
        // This is to set if the diff set in unity.
        // Each difficulty button is set with its own difficulty and when the spawninterval divides it difficulty, the spawn of 
        // obstacles and powerups will decrease.
        int diff = gm.diff;
        if (diff == 1) // if beginner difficulty
        {
            HP = HP * diff;
            MaxHP = MaxHP * diff;
        }
        else if (diff == 2)// if medium difficulty
        {
            HP = HP * diff;
            MaxHP = MaxHP * diff;
        }
        else if (diff == 3)// if nightmare difficulty
        {
            HP = HP * diff;
            MaxHP = MaxHP * diff;
        }
    }

    void NoOfKills() // this function sets the kill rate
    {
        int diff = gm.diff;
        

        if (diff == 1)// if beginner difficulty
        {
            killRate = killRate * diff;
        }
        else if (diff == 2)// if medium difficulty
        {
            killRate = killRate * diff;
        }
        else if (diff == 3) // if nightmare difficulty
        {
            killRate = killRate * diff;
        }



    }






    public void TakeDamage(int damage) // this function takes damage for orc from player
    {
        HP -= damage; // decrement hp
        if (HP < 0) // if hp is less than 0
        {
            HP = 0; // make it 0 for the hp bar
        }
        healthBar.UpdateHealthBar(HP, MaxHP); // update the hp for hp bar
        if (HP <= 0) // if enemy is dead
        {
            healthBar.gameObject.SetActive(false); // disable hp bar
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true; // make the enemies dead body not movable
            Nav.enabled = false; // turn off nav mesh



            anim.SetBool("isDead", true); // make death animation start
            if (!isDead) // if not yet dead only for the first time
            {
                playerMovement.numberOfKills += 1; // increment number of kills

            }
            isDead = true; // make it false for unwanted duplicate counts

            if(GameObject.Find("GameManager").GetComponent<GameManager>().stage2) // if stage2
            {
                playerMovement.countForSecondMap += 1; // increment stage2 number of kills
            }
            playerMovement.UpdateKills(); // update kills


            StartCoroutine(DestroyAfterAnimation(1.0f)); // make the enemy destroyed after 1s delay

            orcAudio.PlayOneShot(deathSound, 0.5f); // play the death sound

        }
    }
    private IEnumerator DestroyAfterAnimation(float delay)// this function makes the enemy destroyed after some delay
    {
               
        yield return new WaitForSeconds(delay); 


        GameObject.Find("SpawnManagerMonster").GetComponent<SpawnManagerMonster>().currentAmountMon -= 1; // decrement current number of monsters
        Destroy(gameObject); // destroy



        spawnItems(); // drop items
    }



}