using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public PlayerDetection playerDetection;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //turn off the globin's ability to charge if it detect a globin
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            //diable charge
            playerDetection.canCharge = false;
            //set the direction of the attack area
            directionAttack();
        }

    }
    // when the player leaves, enable tthe globin to be able tot charge again
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            //return charge functtion to normal
            playerDetection.canCharge = true;
        }
    }

    private void directionAttack()
    {
        //to make the attack directional to where the player is, set the direction of the of the game object (angle)
        //to where the player is
        //Get position of player
        Vector3 playerPos = player.transform.position;
        //Get position of the enemy
        Vector3 enemyPos = transform.parent.position;
        //get the difference between the two
        Vector3 rotation = playerPos - enemyPos;
        //get Rotz in rradians
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        // rotate thee object
        transform.rotation = Quaternion.Euler(0,0,rotZ);

    }


}
