using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBehaviour : EnemyBehavior
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Dead();
    }

    public void Dead()
    {
        if (Health <= 0)
        {
            IsDead = true;
            WhenEnemyDead();
            GetComponentInChildren<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            Animator.SetTrigger("isDead");
        }
    }
}
