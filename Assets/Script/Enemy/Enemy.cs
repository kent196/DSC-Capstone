using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float moveSpeed = 10f;

    public float MaxHealth
    {
        get{return maxHealth;}
        set{maxHealth = value;}
    }

    public float Damage
    {
        get{return damage;}
        set{damage = value;}
    }
    public float MoveSpeed
    {
        get{return moveSpeed;}
        set{moveSpeed = value;}
    }

}
