using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingScript : MonoBehaviour
{
    //Reference the attack area (with child attack area)
    [SerializeField] private GameObject attackArea;

    //time Attackarea is active
    [SerializeField] private float timeToAttack = 0.25f;


    public void activateAttack()
    {
        //Acctivate coreRoutine to activate attackArea
        StartCoroutine(activateAttackArea());
    }

    IEnumerator activateAttackArea()
    {
        //disable the sword sprite when attacking (so only slashing is turned on)
        GameObject.FindGameObjectWithTag("Sword").GetComponent<SpriteRenderer>().enabled = false;
         attackArea.SetActive(true);

        yield return new WaitForSeconds(timeToAttack);

        GameObject.FindGameObjectWithTag("Sword").GetComponent<SpriteRenderer>().enabled = true;
        attackArea.SetActive(false);
    }


}
