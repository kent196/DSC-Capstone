using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotgunBehavior : EnemyBehavior
{
    // private bool isDead = false;
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
            // isDead = true;
        }
    }
}