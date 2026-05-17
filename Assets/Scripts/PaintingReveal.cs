using UnityEngine;
using UnityEngine.UI;

public class PaintingReveal : MonoBehaviour
{
    public GameObject paintingPanel;
    public GameObject coverImage; // cover sprite goes here

    private bool isPlayerNear = false;
    private bool isOpen = false;
    
    void Awake()
    {
        paintingPanel.SetActive(false);
    }
    
    void Update()
    {
        if (isPlayerNear && !isOpen && Input.GetKeyDown(KeyCode.E))
        {
            isOpen = true;
            paintingPanel.SetActive(true);
        }
    }
    
    public void OnCoverSwiped()
    {
        if (!Input.GetMouseButton(0)) return;
        coverImage.SetActive(false);
        Debug.Log("Painting revealed");
        // to add inventory collection here
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
