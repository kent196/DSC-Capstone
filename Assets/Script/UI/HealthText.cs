using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    public Text text;
    private void Start()
    {
        text = FindObjectOfType<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GameManager.gameManager.playerHealth.Health + "/" + GameManager.gameManager.playerHealth.MaxHealth;
        //text shows current health/max health
    }
}
