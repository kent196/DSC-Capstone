using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 10f;
    [SerializeField] public int damage = 1;
    [HideInInspector] public int maxHealth;
    [HideInInspector] public int health;
    [SerializeField] public LayerMask playerLayer;
    [SerializeField] public Vector3 lookRange = new Vector3(10f, 2f, 1f);
    [HideInInspector] public Vector3 currentLookRange;
    [SerializeField] private Vector3 attackRange = new Vector3(5f, 2f, 1f);
    [SerializeField] public float homeMaxDistance = 20f;
    private Vector3 spiderPos;
    [HideInInspector] public Rigidbody2D rb;
    private Animator animator;
    [HideInInspector] public Vector3 homePos;
    [HideInInspector] public Vector3 playerPos;
    [HideInInspector] public GameObject player;
    public GameObject attackEffect;
    // [SerializeField] private EnemyHealthBar enemyHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentLookRange = lookRange;
        homePos = transform.position;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        health = GameManager.gameManager.spiderHealth.Health;
        maxHealth = GameManager.gameManager.spiderHealth.MaxHealth;

        enemyHealthBar.SetHealth(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        spiderPos = transform.position;
    }

    public bool isPlayerInLookZone()
    {
        Collider2D hitInfo = Physics2D.OverlapBox(spiderPos, currentLookRange, 0f, playerLayer);
        if(hitInfo)
        {
            player = hitInfo.transform.gameObject;
            playerPos = player.transform.position;
            return true;
        }
        else 
        {
            player = null;
            return false;
        }
    }

    public bool isPlayerInAttackZone()
    {
        Collider2D hitInfo = Physics2D.OverlapBox(spiderPos, attackRange, 0f, playerLayer);
        if(hitInfo)
        {
            player = hitInfo.transform.gameObject;
            playerPos = player.transform.position;
            return true;
        }
        else 
        {
            return false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(spiderPos, currentLookRange);

        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(spiderPos, attackRange);
    }

    public void FlipSpiderTo(Vector3 destination)
    {
        if(spiderPos.x <= destination.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Fireball"))
        {
            animator.SetTrigger("hit");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            animator.SetTrigger("hit");
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        // enemyHealthBar.SetHealth(health, maxHealth);
    }
    
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void Heal(int heal)
    {
        health += heal;
        // enemyHealthBar.SetHealth(health, maxHealth);
    }
}