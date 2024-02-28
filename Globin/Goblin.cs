using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 1. the gameobject moves randomly with vector2 and 2 corooutiines
// 2. depending on vector, it is also influenced by speed (not just from the variable spped)
// but by the random numbers of the vector itself. This is actually nice
public class Goblin : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Vector2 goblinPos;
    // Start is called before the first frame update
    private float minRange = -50f;
    private float maxRange = 50f;

    public GoblinData data;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StopMovement()
    {
        StopCoroutine(Move());
        rb.velocity = new Vector2(0,0);
        yield return new WaitForSeconds(2f); 
        StartCoroutine(Move());
    }

    public IEnumerator Move()
    {
        if (GetComponent<Stasis>().canMove)
        {
            StopCoroutine(StopMovement());

            goblinPos = new Vector2 (Random.Range(minRange,maxRange),Random.Range(minRange,maxRange));
            
            //Check for flipping before move
            CheckForFlipping(goblinPos.x);
            rb.velocity = new Vector2(goblinPos.x * data.speed * Time.fixedDeltaTime, goblinPos.y * data.speed * Time.deltaTime);
            yield return new WaitForSeconds(3f);
            StartCoroutine(StopMovement());
        }
    }

    private void CheckForFlipping(float xValue)
    {
        bool movingRight = xValue > 0;
        bool movingLeft = xValue < 0;

        Vector3 right = new Vector3(1,1,1);
        Vector3 left = new Vector3(-1,1,1);


        if (movingRight)
        {
            transform.localScale = right;
        }
        if (movingLeft)
        {
            transform.localScale = left;
        }

    }


}
