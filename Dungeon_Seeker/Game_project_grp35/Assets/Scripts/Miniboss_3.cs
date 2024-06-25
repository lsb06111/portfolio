using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miniboss_3 : MonoBehaviour
{
    private GameObject player; // player object
    public GameObject bullet; // bullet object
    Vector3 starting_position; // starting position of boss
    public GameObject shard; // shart object
    public GameObject boss_module; // boss module
    public PlayerMovement playerMovement; // player movement script
    public float HP = 75; // current hp
    public int MaxHP = 75; // max hp
    public AudioSource bossAudio; // audio set for boss
    public int hasShard = 0; // number of shard
    FloatingHealthBar healthBar; // hp bar
    public float healRate = 0.5f; // heal rate
    public AudioClip shootRockSound; // audio clip for shooting rocks


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); // get object of plyaer
        starting_position = this.transform.position; // initialise the starting position of the boss
        boss_module = GameObject.Find("IceElemental"); // import boss module
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>(); // get player movement script
        bossAudio = GetComponent<AudioSource>(); // boss audio
        healthBar = GetComponentInChildren<FloatingHealthBar>(); // get hp bar
        healthBar.UpdateHealthBar(HP, MaxHP); // set the hp bar
        HealthOfBoss3(); // set the initial boss hp
        Skill_Healing(); // place the shard
        hasShard = 2; // number of shards
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.UpdateHealthBar(HP, MaxHP); // update hp
        Skill_Frozen(); // activate skill frozen
        this.transform.position = starting_position; //make the boss only stay at the starting position
        
        if (hasShard > 0) // if has shard is not 0
        {
            if (Time.frameCount % 30 == 0) // every 30 frame
            {
                if (HP + hasShard * 7 >= MaxHP) // if healed total hp is greater than max hp
                {
                    HP = MaxHP; // make hp have the same max hp
                }
                if (HP + hasShard * 7 < MaxHP) // if not
                {
                    HP += hasShard * 7; // heal it by number of shards
                }

            }
        }



        if (Time.frameCount % 90 == 0) // every 90 frames
        {
            if (true)
            {
                boss_module.GetComponent<IceElemantalModule>().attacking(); // attack is activated
                Skill_Ball(); // activate skill ball
            }

        }

    }
    void Skill_Frozen() // frozen skill function
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) < 20) // if player near the boss
        {
            player.GetComponent<PlayerMovement>().speed = 2.0f; // make it slow
        }
        if (Vector3.Distance(player.transform.position, this.transform.position) >= 20) // if player off the boss
        {
            player.GetComponent<PlayerMovement>().speed = 10.0f; // make it 10 speed
        }
    }
    void Skill_Healing() // healing skill function
    {
        //make 2 shards
        Instantiate(shard, new Vector3(this.transform.position.x + 7, this.transform.position.y + 2, this.transform.position.z + 7), this.transform.rotation);
        Instantiate(shard, new Vector3(this.transform.position.x - 7, this.transform.position.y + 2, this.transform.position.z - 7), this.transform.rotation);

    }
    void Skill_Ball() // ball skill function
    {
        //shoot a bullet
        Instantiate(bullet, new Vector3(this.transform.position.x - 5, this.transform.position.y + 5, this.transform.position.z), this.transform.rotation);
        bossAudio.PlayOneShot(shootRockSound, 0.5f); // play the shooting sound

    }


    void HealthOfBoss3()
    {
        // This is to set if the diff set in unity.
        // Each difficulty button is set with its own difficulty and when the spawninterval divides it difficulty, the spawn of 
        // obstacles and powerups will decrease.
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        int diff = gm.diff;
        if (diff == 1) // if begginer difficulty
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

    public void TakeDamage(int damage) // this function takes damge for boss
    {
        HP -= damage; // take damage
        healthBar.UpdateHealthBar(HP, MaxHP); // update hp bar
        boss_module.GetComponent<IceElemantalModule>().being_attack(); // the boss is being attacked
        if (HP <= 0) // if boss dead
        {
            GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>(); // game manager
            gm.gameWin = true; // win the game
            playerMovement.isBoss2Dead = true; // boss2 is dead
            Destroy(gameObject); // destroy itself


        }
    }
}