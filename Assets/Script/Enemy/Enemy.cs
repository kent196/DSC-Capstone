using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public int damage = 1;
    [SerializeField] public int health = 100;
}
