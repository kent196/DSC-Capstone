using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunMeleeBehavior : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth = 500;
    private Animator animator;
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {

        health = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        IsDead();
        Debug.Log(health);
    }

    public void TakeDamage(int dmg)
    {
        animator.SetTrigger("isHit");
        health -= dmg;

    }
    public void IsDead()
    {
        if (health <= 0)
        {
            animator.SetBool("isDead", true);
            isDead = true;
            Destroy(gameObject, 1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            TakeDamage(50);
        }
    }
}
