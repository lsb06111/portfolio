using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerMonster : MonoBehaviour
{

 

    public GameObject[] monsterPrefabs; // prefabs of monsters

    private GameManager gameManager; // game manager

    public int maxMonster = 20; // maximum number of monsters for any possible lagging
    public int currentAmountMon = 0; // current number of monster

    Vector3[] spawnPositions = { new Vector3(0, 0, 0), new Vector3(-8,0,9), new Vector3(0, 0, 9), new Vector3(-8, 0, 1),
        new Vector3(-40, 0, 0), new Vector3(8,0,9), new Vector3(-40,0,42) }; // spawn positions of enemies


    bool changingPos = false; // checks if it is the time for changing spawn position

    // Adding a startand interval time 
    private float startDelay = 2.0f;
    private float spawnInterval = 30.0f;


    // Start is called before the first frame update
    void Start()
    {
        //This is to spawn the monster at the start of the game and the set the interval for each spawn.
        InvokeRepeating("SpawnMonster", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager != null) // if game manager is correctly instantiated
        {
            if (!changingPos && gameManager.isBoss1Completed) // make it only called once when boss1 defeated
            {
                Vector3[] spawnPositions2 = {new Vector3(68, 0, 167), new Vector3(196, 0, 142), new Vector3(196, 0, 312), new Vector3(105, 0, 249),
        new Vector3(120, 0, 335), new Vector3(149, 0, 288)}; // make the new spawn positions

                spawnPositions = spawnPositions2; //  change the spawn positions

                changingPos = true; // change it true so it won't be called anymore
            }
        }
        
            
    }

    public void Begin()
    {
        // This code is very important
        // This code allows 2 scripts to communicate with each other.
        // By using the gameobjet to find the file called game manager and name it as gameManager.
        // Thus when we use gameManager in other scripts, it will know what it is refering to.
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //This is to set the spawn interval of 5-10 seconds
        spawnInterval = Random.Range(5.0f, 10.0f);
        // This is to run the method spawn difficulty
        SpawnDifficulty();
        // This will spawn the powerdown repeately depending on the spawn interval
        InvokeRepeating("SpawnMonster", startDelay, spawnInterval);
        InvokeRepeating("SpawnMonster", startDelay, spawnInterval);

    }

    void SpawnMonster()
    {
        if(currentAmountMon < maxMonster) { // if only current number of monsters less than maximum number of monsters

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // get game manager
            if (gameManager.isGameActive == true) // if only game is on active
            {
                // This is to spawn different monsters
                // As this is still in the testing phase, I am only using 1 monster.
                int monsterIndex = Random.Range(0, monsterPrefabs.Length);

                //this is to spawn the monster in 1 small area to check if the spanw manager works. 
                // Will try to make it spawn the whole map in the future.
                //Vector3 spawnPos = new Vector3(Random.Range(spawnRangeX2, spawnRangeX1), spawnPosY, spawnPosZ);
                Vector3 spawnPos = spawnPositions[Random.Range(0, spawnPositions.Length)];
                Debug.Log(spawnPos);



                // This is to randomly spawn the monsters in their positions.
                GameObject mon = Instantiate(monsterPrefabs[monsterIndex], spawnPos, monsterPrefabs[monsterIndex].transform.rotation);

                currentAmountMon++; // increment current number of monsters


                if (monsterIndex == 0 && gameManager.stage2) // if MnD and stage2
                {

                    mon.GetComponent<AI_Monster>().stageName = "stage2"; // make it stage2

                }
                if (monsterIndex == 1 && gameManager.stage2) // if orc
                {
                    mon.GetComponent<AI_Orc>().stageName = "stage2"; // make it stage2


                }

                if (monsterIndex == 0 && !gameManager.stage2) // if MnD and stage1
                {

                    mon.GetComponent<AI_Monster>().stageName = "stage1"; // make it stage1

                }
                if (monsterIndex == 1 && !gameManager.stage2) // if orc and stage1
                {
                    mon.GetComponent<AI_Orc>().stageName = "stage1"; // make it stage1


                }
            }


        }
    }

    void SpawnDifficulty()
    {
        // This is to set if the diff set in unity.
        // Each difficulty button is set with its own difficulty and when the spawninterval divides it difficulty, the spawn of 
        // obstacles and powerups will decrease.
        int diff = gameManager.diff;
        if (diff == 1) // if beginner difficulty
        {
            spawnInterval = spawnInterval / diff;
        }
        else if (diff == 2) // if medium difficulty
        {
            spawnInterval = spawnInterval / diff;
        }
        else if (diff == 3) // if nightmare difficulty
        {
            spawnInterval = spawnInterval / diff;
        }
    }
}