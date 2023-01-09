using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
            Debug.Log(GameManager.gameManager.playerHealth.Health);
        }
    }
    private void TakeDamage(int dmgAmount)
    {
        //some conditon
        GameManager.gameManager.playerHealth.DamageUnit(dmgAmount);

    }

    private void Heal(int healAmount)
    {
        //some condition
        GameManager.gameManager.playerHealth.HealUnit(healAmount);
    }
}
