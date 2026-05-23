using UnityEngine;
using UnityEngine.UI;

public class PaintingWithClouds1 : MonoBehaviour
{
    public GameObject paintingUI;
    public Transform cloudsContainer; 
    public GameObject dialogueBox;
    public Sprite itemSprite;
    public GameObject pickupDialogue;
    public AudioClip interactSound;
    
    public int hitsPerCloud = 3;

    private bool isPlayerNear = false;
    private bool isPaintingOpen = false;
    private bool allCloudsCleared = false;
    private int remainingClouds = 0;
    private bool isDialogueOpen = false;
    private bool isDone = false;
    private AudioSource audioSource;

    void Awake()
    {
        paintingUI.SetActive(false);
        dialogueBox.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        remainingClouds = cloudsContainer.childCount;

        foreach (Transform child in cloudsContainer)
        {
            var counter = child.gameObject.AddComponent<CloudHitCounter>();
            counter.hitsRequired = hitsPerCloud;
            
            var btn = child.GetComponent<Button>();
            if (btn != null)
            {
                GameObject cloudRef = child.gameObject; 
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(() => OnCloudClicked(cloudRef));
            }
        }
    }

    void Update()
    {
        if (isPlayerNear && !isPaintingOpen && !isDialogueOpen && Input.GetKeyDown(KeyCode.E))
        {
            if (interactSound != null)
                audioSource.PlayOneShot(interactSound);
            isDialogueOpen = true;
            dialogueBox.SetActive(true);
        }
        else if (isDialogueOpen && Input.GetKeyDown(KeyCode.E))
        {
            isDialogueOpen = false;
            dialogueBox.SetActive(false);
            OpenPainting();
        }
        else if (isPaintingOpen && allCloudsCleared && Input.GetKeyDown(KeyCode.E))
        {
            ClosePainting();
        }
    }

    void OpenPainting()
    {
        isPaintingOpen = true;
        paintingUI.SetActive(true);
    }

    void ClosePainting()
    {
        isPaintingOpen = false;
        paintingUI.SetActive(false);
        GmManager.instance.PaintingCleared();

        InventoryController inventory = FindFirstObjectByType<InventoryController>();
        if (inventory != null && itemSprite != null)
        {
            inventory.AddItem(itemSprite);
            pickupDialogue.SetActive(true);
            Invoke("HidePickupDialogue", 2f);  // hides after 2 seconds
        }
        isDone = true;
        
    }

    void HidePickupDialogue()
    {
        pickupDialogue.SetActive(false);
    }

    public void OnCloudClicked(GameObject cloud)
    {
        if (cloud == null) return;

        var counter = cloud.GetComponent<CloudHitCounter>();
        if (counter == null) return;

        counter.currentHits++;
        
        var img = cloud.GetComponent<Image>();
        if (img != null)
        {
            float alpha = 1f - ((float)counter.currentHits / counter.hitsRequired);
            img.color = new Color(1f, 1f, 1f, Mathf.Clamp01(alpha));
        }

        if (counter.currentHits >= counter.hitsRequired)
        {
            remainingClouds--;
            cloud.SetActive(false);   
            Destroy(cloud, 0.1f);     

            if (remainingClouds <= 0)
            {
                allCloudsCleared = true;
                Debug.Log("All clouds gone! Press E to close.");
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
            isPlayerNear = false;
    }
}

public class CloudHitCounter : MonoBehaviour
{
    public int hitsRequired = 3;
    public int currentHits = 0;
}
