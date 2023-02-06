using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunMeleeBehavior : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth = 500;
    private Animator animator;
    private Rigidbody2D rb;
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {

        health = maxHealth;
        animator = GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsDead();
    }

    public void TakeDamage(int dmg)
    {
        animator.SetTrigger("isHit");
        health -= dmg;

    }
    public bool IsDead()
    {
        if (health <= 0)
        {
            animator.SetBool("isDead", true);
            isDead = true;
            Destroy(gameObject, 1f);
        }
        return isDead;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            TakeDamage(50);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            animator.SetTrigger("isHit");
        }
    }
}
