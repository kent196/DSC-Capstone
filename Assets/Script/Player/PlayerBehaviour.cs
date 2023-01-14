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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
            Debug.Log(GameManager.gameManager.playerHealth.Health);
            healthBar.SetHealth(GameManager.gameManager.playerHealth.Health);
            if (GameManager.gameManager.playerHealth.Health == 0)
            {
                GameManager.gameManager.EndGame();
            }
        }
    }
    public void TakeDamage(int dmgAmount)
    {
        //some conditon
        GameManager.gameManager.playerHealth.DamageUnit(dmgAmount);


    }

    public void Heal(int healAmount)
    {
        //some condition
        GameManager.gameManager.playerHealth.HealUnit(healAmount);
    }
}
