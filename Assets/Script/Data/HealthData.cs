using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HealthData")]
public class HealthData : ScriptableObject
{
    public int maxHealth;
    public int health;
}
