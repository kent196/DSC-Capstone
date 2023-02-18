using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : EnemyBehavior
{
    [SerializeField] public float attackRadius;

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
