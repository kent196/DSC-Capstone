using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpSystem : MonoBehaviour
{
    [SerializeField] public GameObject dialogueBox;
    [SerializeField] private TMP_Text dialogueText;
    public string dialogue;
    [SerializeField] public bool playerInRange;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(14,16,true);
        Physics2D.IgnoreLayerCollision(12,16,true);
    }

    void Update()
    {
        // Debug.Log(playerInRange);
        if (playerInRange)
        {
            if (!dialogueBox.activeInHierarchy)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Time.timeScale = 0;
                    dialogueBox.SetActive(true);
                    dialogueText.text = dialogue;
                }
            }
            else
            {
                if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
                {
                    Time.timeScale = 1;
                    dialogueBox.SetActive(false);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            playerMovement.canJump = false;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            playerMovement.canJump = true;


            dialogueBox.SetActive(false);
        }
    }
}