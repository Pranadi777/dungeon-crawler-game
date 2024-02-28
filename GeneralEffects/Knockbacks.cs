using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockbacks : MonoBehaviour
{
    public void KnockBack(GameObject knocker, int strength)
    {

        //get the dirrection between the area and the collider
        Vector2 direction = (this.transform.position - knocker.transform.position).normalized;
        //get the rigid body of the coollideer to apply the force
        this.GetComponent<Rigidbody2D>().AddForce(force: direction * strength,ForceMode2D.Impulse);

        

    } 
}
