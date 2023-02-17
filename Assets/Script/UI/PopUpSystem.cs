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

    }

    void Update()
    {
        if (playerInRange)
        {
            if (!dialogueBox.activeInHierarchy)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {Debug.Log("bủh bủh lmao");
                    Time.timeScale = 0;
                    dialogueBox.SetActive(true);
                    dialogueText.text = dialogue;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
                {Debug.Log("bủh bủh");
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
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.canJump = false;
            }
            
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.canJump = true;
            }
            
            dialogueBox.SetActive(false);
        }
    }
}
