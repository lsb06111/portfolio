using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MagicBall : MonoBehaviour
{
    public float speed = 25; // speed of flying

    public int damage = 5; // damage of magic ball

    public Vector3 moveDirection; // move direction for flying


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World); // fly to the direction
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("wall")) // if met wall
        {
            Destroy(gameObject); // destroy itself
        }

        if (other.CompareTag("Enemy")) // if met enemy
        {

            Debug.Log("enemy detected!");

            Destroy(gameObject); // destroy itself

            other.GetComponent<AI_Monster>().TakeDamage(damage); // take damage for enemy
        }
        if (other.CompareTag("Orc")) // if met orc
        {

            Debug.Log("enemy detected!");

            Destroy(gameObject); // destroy itself

            other.GetComponent<AI_Orc>().TakeDamage(damage); // take damage for orc
        }
        if (other.CompareTag("Boss1")) // if met boss1
        {
            Destroy(gameObject); // destroy itself
            other.GetComponent<MiniBoss_2>().TakeDamage(damage); // take damage for boss1
        }
        if (other.CompareTag("Boss2")) // if met boss2
        {
            Destroy(gameObject); // destroy itself
            other.GetComponent<Miniboss_3>().TakeDamage(damage); // take damage for boss2
        }
        if (other.CompareTag("Shard")) // if met shard
        {
            Destroy(gameObject); // destroy itself
            other.GetComponent<IceShard>().TakeDamage(damage); // take damage for shard
        }



    }

}