using System;
using UnityEngine;

public class ObjectDialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public AudioClip interactSound; // sound effect goes here
    private AudioSource audioSource;
    private bool isPlayerNear = false;
    private bool isDialogueOpen = false;

    void Awake()
    {
        dialogueBox.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (interactSound != null)
                audioSource.PlayOneShot(interactSound);
            
            if (!isDialogueOpen)
            {
                isDialogueOpen = true;
                dialogueBox.SetActive(true);
            }
            else
            {
                isDialogueOpen = false;
                dialogueBox.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            dialogueBox.SetActive(false);
        }
    }
}
