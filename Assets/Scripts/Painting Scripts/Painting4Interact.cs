using UnityEngine;
using UnityEngine.SceneManagement;

public class Painting4Interact : MonoBehaviour
{
    public GameObject dialogueBox; 
    public string sceneToLoad; 
    
    private bool isPlayerNear = false;
    private bool isDialogueOpen = false;
    
    void Awake()
    {
        dialogueBox.SetActive(false);
    }
    
    void Update()
    {
        if (!isPlayerNear) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isDialogueOpen && GmManager.instance.AllCleared())
            {
                // all 3 cleared, show dialogue
                isDialogueOpen = true;
                dialogueBox.SetActive(true);
            }
            else if (!isDialogueOpen && !GmManager.instance.AllCleared())
            {
                // not cleared yet, show locked dialogue
                Debug.Log("Clear all paintings first!");
            }
            else if (isDialogueOpen)
            {
                // second E press, load the new scene
                SceneManager.LoadScene("Painting4Scene");
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            isDialogueOpen = false;
            dialogueBox.SetActive(false);
        }
    }
}

