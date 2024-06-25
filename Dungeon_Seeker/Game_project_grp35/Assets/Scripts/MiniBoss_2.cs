using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss_2 : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public GameObject bullet;
    Vector3 starting_position;
    public int fire_ball_dmg=10;
    public GameObject boss_module;
    public GameObject fireAura;

    //public GameObject keyForMap2;

    public PlayerMovement playerMovement;
    private float range_aura=10.0f;

    public int HP = 50;
    public int MaxHP = 50;
    public int attack = 30;
    private GameObject key;
    public GameObject KeyPrefab;

    FloatingHealthBar healthBar;


    public AudioSource bossAudio;

    public AudioClip shootRockSound;

    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("Player"); // get player object
        starting_position=this.transform.position; // set initial position
        boss_module=GameObject.Find("FireElemental"); // import boss module
        healthBar = GetComponentInChildren<FloatingHealthBar>(); // hp bar for boss
        healthBar.UpdateHealthBar(HP, MaxHP); // initialise hp bar for boss
        fireAura = GameObject.Find("Meteors AOE(Clone)"); // import aura

        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>(); // get player movement script
        bossAudio = GetComponent<AudioSource>(); // get audio set
        HealthOfBoss2(); // set the initial hp for boss

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position=starting_position;
        //Debug.Log(Vector3.Distance(player.transform.position,this.transform.position));
        if(Time.frameCount%60==0){ // every 60 frames
            Skill_Ball(); // activate skill ball
            Skill_Flame();   // activate skill flame
            if(Vector3.Distance(player.transform.position,this.transform.position)<range_aura){ // if player near the aura
                Skill_Burning(); // activate burning
            }
            
        }
        
    }
    void Skill_Flame(){ // skill of flame
        fireAura.GetComponent<PositionFireAura>().zoom+=0.2f; // make it larger
        range_aura+=0.2f; // make the range also larger
    }
    void Skill_Burning(){ // skill of burning
        player.GetComponent<PlayerMovement>().currentHealth-=5; // take 5 hp from player
        player.GetComponent<PlayerMovement>().healthbar.SetHealth(player.GetComponent<PlayerMovement>().currentHealth); // update hp for player
        //player.GetComponent<AudioSource>().PlayOneShot("tookDamage", 0.5f);
    }
    void Skill_Ball(){ // skill of ball
        boss_module.GetComponent<IceElemantalModule>().attacking(); // being attacked
        Instantiate(bullet,new Vector3(this.transform.position.x,this.transform.position.y+5,this.transform.position.z),this.transform.rotation); // instantiate the balls
        bossAudio.PlayOneShot(shootRockSound, 0.5f);// play the sound

    }
    public void TakeDamage(int damage) // this function takes damge
    {
        HP -= damage; // decrement hp with damage
        healthBar.UpdateHealthBar(HP, MaxHP); // update hp
        boss_module.GetComponent<IceElemantalModule>().being_attack(); // being attacked
        if (HP <= 0) // if boss dead
        {
            GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>(); // get game manager
            gm.bossCount += 1; // increment the boss count
            gm.isBoss1Completed = true; // boss1 is defeated
            gm.SetQuest("That was hard.. \n Oh there's another key!"); // set quest message
            if (gm.stage2 && gm.bossCount ==2) // if stage2 and boss count is 2
            {
                gm.gameWin = true; // you win game

            }
            playerMovement.isBoss1Dead = true; // boss1 is dead

            Destroy(gameObject); // destroy itself

            // it should drop the key for the second map
            spawnItems();

        }
    }

    void HealthOfBoss2()
    {
        // This is to set if the diff set in unity.
        // Each difficulty button is set with its own difficulty and when the spawninterval divides it difficulty, the spawn of 
        // obstacles and powerups will decrease.
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        int diff = gm.diff;
        if (diff == 1) // if beginner difficulty
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


    public void spawnItems() // this function spawns the item
    {
        int randomChance = Random.Range(1, 101); // set the initial probability set

        if (randomChance > 1) // 100 %
        {


                // Spawn the coid when the monster is dead
                key = Instantiate(KeyPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity); // instantiate key
                // display the coin
                key.SetActive(true); // make it visible
                playerMovement.keyDropped = true; // key is dropped now
            


        }
    }
}
