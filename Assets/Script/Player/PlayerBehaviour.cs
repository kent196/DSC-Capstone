using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
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
