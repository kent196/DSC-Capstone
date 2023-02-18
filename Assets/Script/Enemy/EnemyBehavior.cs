using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //Parameters
    [SerializeField] private float maxHealth;
    private float health;
    [SerializeField] private float damage;
    public float MaxHealth
    {
        get{return maxHealth;}
        set{maxHealth = value;}
    }
    public float Health
    {
        get{return health;}
        set{health = value;}
    }
    public float Damage
    {
        get{return damage;}
    }

    //Components
    private Collider2D enemyCollider;
    private Rigidbody2D rb;
    protected Animator animator;
    public Rigidbody2D Rb
    {
        get{return rb;}
        set{rb = value;}
    }
    public Animator Animator
    {
        get{return animator;}
        set{animator = value;}
    }

    [SerializeField] private EnemyHealthBar enemyHealthBarHolder;
    private EnemyHealthBar enemyHealthBar;
    public EnemyHealthBar EnemyHealthbar
    {
        get{return enemyHealthBar;}
        set{enemyHealthBar = value;}
    }
    [SerializeField] private float healthbarYOffset;

    private bool isDead = false;
    public bool IsDead
    {
        get{return isDead;}
        set{isDead = value;}
    }

    //Detect
    [HideInInspector] public GameObject player;
    [HideInInspector] public Vector3 playerPos;
    [HideInInspector] public Vector3 enemyPos;
    [SerializeField] public LayerMask playerLayer;
    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();

        enemyHealthBar = Instantiate(enemyHealthBarHolder, transform.position, Quaternion.identity);
        enemyHealthBar.HealthBarrYOffSet = healthbarYOffset;
        enemyHealthBar.transform.SetParent(this.transform);

        health = maxHealth;
        enemyHealthBar.SetHealth(health, maxHealth);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0 && !IsDead)
        {
            EnemyDead();
        }
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        enemyHealthBar.SetHealth(health, maxHealth);
    }
    
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void Heal(float heal)
    {
        health += heal;
        enemyHealthBar.SetHealth(health, maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Fireball"))
        {
            TakeDamage(10);
            animator.SetTrigger("isHit");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player = other.gameObject;
            TakeDamage(5);
            animator.SetTrigger("isHit");
        }
    }

    //Detect player
    public bool isPlayerInLookBox(Vector2 lookRange)
    {
        Collider2D hitInfo = Physics2D.OverlapBox(transform.position, lookRange, 0f, playerLayer);
        if(hitInfo)
        {
            playerPos = hitInfo.transform.position;
            return true;
        }
        else 
        {
            return false;
        }
    }

    public bool isPlayerInAttackBox(Vector2 attackRange)
    {
        Collider2D hitInfo = Physics2D.OverlapBox(transform.position, attackRange, 0f, playerLayer);
        if(hitInfo)
        {
            player = hitInfo.transform.gameObject;
            playerPos = hitInfo.transform.position;
            return true;
        }
        else 
        {
            return false;
        }
    }

    public bool isPlayerInAttackCircle(float radius)
    {
        Collider2D hitInfo = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
        {
            if(hitInfo)
            {
                player = hitInfo.transform.gameObject;
                playerPos = hitInfo.transform.position;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool isRaycastHit(Vector3 from, Vector3 to, string tag)
    {
        Vector2 direction = (to - from).normalized;
        float distance = Vector3.Distance(from, to);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, direction, distance, ~(1 << 11 | 1 << 14 | 1 << 12 | 1 << 16));
        if(hitInfo && hitInfo.transform.tag == tag)
        {
            Debug.DrawRay(transform.position, direction * distance, Color.yellow, 2f);
            return true;
        }
        else
        {
            return false;
        }
    }

    //Flip enemy to player
    public void FlipEnemyTo(Vector3 destination)
    {
        if(transform.position.x <= destination.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
    }

    //During Dead [10,12,16]
    public void IgnoreLayersCollision(int [] layers, bool isIgnore)
    {
        foreach(int layer in layers)
        {
            Physics2D.IgnoreLayerCollision(layer, gameObject.layer, isIgnore);
        }
    }

    public void EnemyDead()
    {
        isDead = true;
        animator.SetTrigger("dead");
        if(enemyCollider != null)
        {
            enemyCollider.enabled = false;
        }
        if(rb != null)
        {
            rb.isKinematic = true;
            rb.simulated = false;
        }
    }

    public void TakePlayerDamage()
    {
        player.GetComponent<PlayerBehaviour>().TakeDamage(damage);
    }
}
