using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAttack : MonoBehaviour
{
    private GameObject player;
    //this variable is too pull the data scriptable object refercne from the parent (so you dont have to add the scriptable object here toos)
    private GoblinData goblinData;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        goblinData = gameObject.GetComponentInParent<Goblin>().data;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if(collider.tag == "Player")
        {
            collider.GetComponent<Health>().Damage(goblinData.damage);
            collider.GetComponent<Knockbacks>().KnockBack(this.transform.parent.gameObject, goblinData.knockback);


        }
    }
}
