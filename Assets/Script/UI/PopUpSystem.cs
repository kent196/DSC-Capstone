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
            other.GetComponent<PlayerMovement>().canJump = false;
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            other.GetComponent<PlayerMovement>().canJump = true;
            dialogueBox.SetActive(false);
        }
    }
}
