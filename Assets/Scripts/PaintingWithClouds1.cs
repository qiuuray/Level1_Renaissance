using UnityEngine;
using UnityEngine.UI;

public class PaintingWithClouds1 : MonoBehaviour
{
    public GameObject paintingUI;
    public Transform cloudsContainer;   
    
    public int hitsPerCloud = 3;

    private bool isPlayerNear = false;
    private bool isPaintingOpen = false;
    private bool allCloudsCleared = false;
    private int remainingClouds = 0;

    void Awake()
    {
        paintingUI.SetActive(false);
    }

    void Start()
    {
        remainingClouds = cloudsContainer.childCount;
        Debug.Log("Clouds found: " + remainingClouds);

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
            else
            {
                Debug.LogWarning("No Button component on: " + child.name);
            }
        }
    }

    void Update()
    {
        if (isPlayerNear && !isPaintingOpen)
            Debug.Log("Press E to open painting");

        if (isPlayerNear && !isPaintingOpen && Input.GetKeyDown(KeyCode.E))
            OpenPainting();

        else if (isPaintingOpen && allCloudsCleared && Input.GetKeyDown(KeyCode.E))
            ClosePainting();
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
        // inventory goes here when mike is ready
    }

    public void OnCloudClicked(GameObject cloud)
    {
        if (cloud == null) return;

        var counter = cloud.GetComponent<CloudHitCounter>();
        if (counter == null) return;

        counter.currentHits++;
        Debug.Log(cloud.name + " hit " + counter.currentHits + "/" + counter.hitsRequired);
        
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

            Debug.Log("Cloud removed! Remaining: " + remainingClouds);

            if (remainingClouds <= 0)
            {
                allCloudsCleared = true;
                Debug.Log("All clouds gone! Press E to close.");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.name + " tag: " + other.tag);
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
