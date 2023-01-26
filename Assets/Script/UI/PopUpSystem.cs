using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpSystem : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text dialogueText;
    public string dialogue;
    [SerializeField] bool playerInRange;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if(dialogueBox.activeInHierarchy)
            {
                dialogueBox.SetActive(false);
            }else{
                dialogueBox.SetActive(true);
                dialogueText.text = dialogue;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogueBox.SetActive(false);
        }   
    }
}
