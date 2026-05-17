using UnityEngine;
using UnityEngine.UI;

public class PaintingReveal : MonoBehaviour
{
    public GameObject paintingPanel;
    public GameObject coverImage;
    public GameObject lockedDialogue;    // "come back when other paintings are done" message
    public GameObject openDialogue;      // normal "press E to interact" message

    private bool isPlayerNear = false;
    private bool isOpen = false;

    void Awake()
    {
        coverImage.SetActive(true);
        lockedDialogue.SetActive(false);
        openDialogue.SetActive(false);
        isOpen = false;
    }

    void Update()
    {
        if (!isPlayerNear) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GmManager.instance.AllCleared())
            {
                // all paintings done, allow interaction
                lockedDialogue.SetActive(false);
                openDialogue.SetActive(false);
                isOpen = true;
            }
            else
            {
                // not all cleared, show locked dialogue
                lockedDialogue.SetActive(true);
            }
        }
    }

    public void OnCoverSwiped()
    {
        if (!Input.GetMouseButton(0)) return;
        if (!isOpen) return;
        coverImage.SetActive(false);
        Debug.Log("Painting revealed!");
        // to add inventory here
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            if (GmManager.instance.AllCleared())
                openDialogue.SetActive(true);
            else
                lockedDialogue.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            lockedDialogue.SetActive(false);
            openDialogue.SetActive(false);
        }
    }
}
