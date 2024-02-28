using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GoblinEnemy", order = 2)]

public class GoblinData : ScriptableObject
{
    public int hp;
    public int damage;
    public float chargeSpeed;
    public float speed; 
    public int knockback;
}
