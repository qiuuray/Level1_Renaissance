using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ButterflyCollectible : MonoBehaviour
{
    public Sprite itemSprite;
    public AudioClip interactSound;

    public GameObject dialogueBox;

    private bool isPlayerNear = false;
    private bool isCollected = false;

    private void Awake()
    {
        dialogueBox.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerNear && !isCollected && Input.GetKeyDown(KeyCode.E))
        {
            isCollected = true;
            dialogueBox.SetActive(true);
            
            InventoryController inventory = FindObjectOfType<InventoryController>();
            if (inventory != null && itemSprite != null)
                inventory.AddItem(itemSprite);
            
            Invoke("HideDialogue", 2f);
            gameObject.SetActive(false);
        }
    }

    void HideDialogue()
    {
        dialogueBox.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = false;
            
    }
}
