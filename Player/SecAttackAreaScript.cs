using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecAttackAreaScript : MonoBehaviour
{

    [SerializeField] private float freezeTime = 3f;
    private void OnTriggerStay2D(Collider2D collider)
    {
        // If the input is left the following will happen
        if (collider.GetComponent<Health>() != null && Input.GetMouseButton(1))
        {
            StartCoroutine(SecondAttack(collider));
            StartCoroutine(SecAttackAnimation());
        }
    }

    IEnumerator SecondAttack(Collider2D col)
    {
        //if not null becmee you might kill it during the crounitn
        if (col != null)
        {
            col.GetComponent<Stasis>().canMove = false;
            //col.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            //pausee the enemy
            //trigger the animation
            yield return new WaitForSeconds(freezeTime);

        }

        if (col != null)
        {
            //col.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            col.GetComponent<Stasis>().canMove = true;
            //for enemies like goblins, you need to start their coroutine for movement again
            if (col.GetComponent<Goblin>() != null)
            {
                col.GetComponent<Goblin>().Move();
            }
        }


    }

    IEnumerator SecAttackAnimation()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().enabled = false;

    }



}
