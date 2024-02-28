using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{

    private GameObject player;
    // can charge to stopo for child attacking script - i.e. not too close to player
    public bool canCharge = true;
    //this variable is too pull the data scriptable object refercne from the parent (so you dont have to add the scriptable object here toos)
    private GoblinData goblinData;

    // Start is called before the first frame update
    void Start()
    {
        //set the variable for the player
        player = GameObject.FindGameObjectWithTag("Player");
        //set the reference for the Goblin's (parent) data scriptable variable
        goblinData = gameObject.GetComponentInParent<Goblin>().data;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            if (gameObject.GetComponentInParent<Stasis>().canMove && canCharge)
            {
                Charge();
            }

        }
    }


    private void Charge()
    {

        transform.parent.position = Vector2.MoveTowards(transform.parent.position, player.transform.position, goblinData.chargeSpeed * Time.deltaTime);
    }
}
