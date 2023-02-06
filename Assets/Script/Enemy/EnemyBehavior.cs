using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Spider,
    Flower,
    Shotgun,
    Sniper
}
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
    private Rigidbody2D rb;
    private Animator animator;
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
    [SerializeField] private EnemyType enemyType;

    private bool isDead = false;
    public bool IsDead
    {
        get{return isDead;}
        set{isDead = value;}
    }

    void Awake()
    {
        isDead = (PlayerPrefs.GetInt(gameObject.name + "_isDead") == 1);

        if(isDead)
        {
            if(transform.tag == "Spider")
            {
                Destroy(gameObject);
            }
            else Destroy(gameObject.transform.parent.gameObject);
        }

        rb = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();

        enemyHealthBar = Instantiate(enemyHealthBarHolder, new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), Quaternion.identity);
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

    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        enemyHealthBar.SetHealth(health, maxHealth);
    }
    
    public void Destroy()
    {
        isDead = true;
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
            TakeDamage(5);
            animator.SetTrigger("isHit");
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt(gameObject.name + "_isDead", isDead? 1 : 0);
        PlayerPrefs.Save();
    }
}
