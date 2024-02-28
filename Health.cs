using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


/* ATTENTION: This is a class that will be attached to a GameObject, thus implicitly the
values associated here, will "this"'s values
*/

public class Health : MonoBehaviour
{
    public float currentHealth;
    [SerializeField] private float maxHealth;
    
    
    void Awake()
    {
        //Set the health of the gameobject
        SetHealth(100,100);
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void SetHealth(int startingHealth, int startingMaxHealth)
    {
        this.currentHealth = startingHealth;
        this.maxHealth = startingMaxHealth;
    }

    public void Damage(int amount)
    {
        this.currentHealth -= amount;
        StartCoroutine(DamagedIndicator(Color.red));

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private IEnumerator DamagedIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;   
    }
}
