using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss_1 : MonoBehaviour
{

    // Start is called before the first frame update
    int record_health;
    int health = 100; // hp
    private GameObject player; // player object
    private GameObject plane; // plane object
    float speed = 0.01f; // boss speed
    private Rigidbody boss; // rigidbody of itself
    public GameObject bullet; // bullet from boss
    public GameObject rock; // rock from boss
    Vector3 starting_position; // spawn position of boss
    public int shield_count = 0; // count of shield
    bool in_air = false; // if boss jumped
    int skill_decide; // which skill to use

    private PlayerMovement playerMovement; // player movement script

    private GameObject key; // key
    public GameObject KeyPrefab; // prefab of key

    bool keyDropped = false; // is key dropped
    void Start()
    {
        player = GameObject.Find("Player"); // initialise player
        plane = GameObject.Find("Plane"); // initialise plane
        boss = GetComponent<Rigidbody>(); // initialise rigidbody of itself
        starting_position = this.transform.position; // set the starting position
        boss.freezeRotation = true; // make boss not rotated
        record_health = health; // make a record of current health

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 120 == 0) // every 120 frame
        {
            skill_decide = Random.Range(0, 3); // choose random skill
            if (skill_decide == 1) // if skill 1
            {
                Skill_Ball(); // throw ball
            }

            if (skill_decide == 2) // if skill2
            {
                Skill_Rock(); // throw rock
            }

        }
        if (health == 0) // if hp is 0
        {
            Debug.Log("Boss Dead"); 
            Destroy(this); // destroy itself
        }
        if (health < record_health) // if hp changed
        {
            //player.GetComponent<PlayerMovement>().health-=record_health-health;
            record_health = health; // update
        }

    }
    void Skill_Rock() // skill of rock
    {
        Instantiate(rock, new Vector3(this.transform.position.x, this.transform.position.y + 10, this.transform.position.z), this.transform.rotation); // instantiate the rock
    }
    void Skill_Ball()
    {
        Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y + 2, this.transform.position.z), this.transform.rotation); // instantiate the ball

    }

    public void spawnItems() // drop item
    {
        int randomChance = Random.Range(1, 101); // initialise the probability set

        if (randomChance > 1) // 100%
        {

                if (playerMovement.keyDropped == false) // if key is not dropped yet
                {
                    Vector3 position = transform.position;

                    // Spawn the coid when the monster is dead
                    key = Instantiate(KeyPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity); // make the key drop
                    // display the coin
                    key.SetActive(true);
                    playerMovement.keyDropped = true;
                }


            }
        }
    }
           


        
