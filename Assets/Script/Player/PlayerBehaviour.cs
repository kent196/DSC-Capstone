using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public HealthBar healthBar;
    private void Start()
    {
        healthBar = FindObjectOfType<HealthBar>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDamage(20);
        //    Debug.Log(GameManager.gameManager.playerHealth.Health);
        //    healthBar.SetHealth(GameManager.gameManager.playerHealth.Health);
        //    if (GameManager.gameManager.playerHealth.Health == 0)
        //    {
        //        GameManager.gameManager.EndGame();
        //    }
        //}
        healthBar.SetHealth(GameManager.gameManager.playerHealth.Health);
        if (GameManager.gameManager.playerHealth.Health <= 0)
        {
            GameManager.gameManager.EndGame();
        }
    }


    public void TakeDamage(int dmgAmount)
    {
        //some conditon
        GameManager.gameManager.playerHealth.DamageUnit(dmgAmount);
        healthBar.SetHealth(GameManager.gameManager.playerHealth.Health);

    }

    public void Heal(int healAmount)
    {
        //some condition
        GameManager.gameManager.playerHealth.HealUnit(healAmount);
        healthBar.SetHealth(GameManager.gameManager.playerHealth.Health);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FlowerProjectile"))
        {
            TakeDamage(200);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heal Flower"))
        {
            Debug.Log("Heal");
            Heal(200);
            healthBar.SetHealth(GameManager.gameManager.playerHealth.Health);
        }
    }


}
