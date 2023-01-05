using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public HealthBar healthBar;
    private void Start()
    {
        healthBar.SetMaxHealth(GameManager.gameManager.playerHealth.MaxHealth);

    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            TakeDamage(20);
            Debug.Log("Space key was pressed.");
        }

    }



    private void TakeDamage(int dmgAmount)
    {
        //some conditon
        GameManager.gameManager.playerHealth.DamageUnit(dmgAmount);
        healthBar.SetHealth(GameManager.gameManager.playerHealth.Health);
        if (GameManager.gameManager.playerHealth.Health <= 0)
        {
            Debug.Log("Player is dead");
            GameManager.gameManager.EndGame();
        }

    }

    private void Heal(int healAmount)
    {
        //some condition
        GameManager.gameManager.playerHealth.HealUnit(healAmount);
    }
}
