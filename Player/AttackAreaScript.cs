using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackAreaScript : MonoBehaviour
{


    /*OnTriggerenter2D(collider):
    1. damage() the collider
    2. knockback() the collider
    3. Sttun() the collider (future addon)
    */
    [SerializeField] private int hitDamageAmount = 10;
    [SerializeField] private int knockbackAmount = 5;

    
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if(collider.GetComponent<Health>() != null)
        {
            collider.GetComponent<Health>().Damage(hitDamageAmount);
            // Add knockback to enemies that can move
            if (collider.GetComponent<Stasis>().canMove == true)
            {
                collider.GetComponent<Knockbacks>().KnockBack(this.transform.parent.gameObject, knockbackAmount);
            }
        }
    }



}
