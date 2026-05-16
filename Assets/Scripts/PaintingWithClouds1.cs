using UnityEngine;
using UnityEngine.UI;

public class PaintingWithClouds1 : MonoBehaviour
{
    public GameObject paintingUI;
    public Transform cloudsContainer;
    public int hitsPerCloud = 3;
    
    private bool isPlayerNear = false;
    private int remainingClouds;
    private bool isPaintingOpen = false;
    private bool allCloudsCleared = false;
    
    void Start()
    {
        // hide painting UI until painting clicked
        paintingUI.SetActive(false);

        remainingClouds = cloudsContainer.childCount;
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && !isPaintingOpen)
        {
            OpenPainting();
        }
        
        // close painting when pressing E after clouds are cleared
        else if (isPaintingOpen && allCloudsCleared && Input.GetKeyDown(KeyCode.E))
        {
            ClosePainting();
        }
    }
    
    void OpenPainting()
    {
        paintingUI.SetActive(true);
        isPaintingOpen = true;
    }

    public void OnCloudClicked(GameObject cloud)
    {
        CloudHitCounter counter = cloud.GetComponent<CloudHitCounter>();

        if (counter == null)
        {
            counter = cloud.AddComponent<CloudHitCounter>();
            counter.hitsRequired = hitsPerCloud;
        }

        counter.currentHits++;
        
        // make clouds more transparent on click
        Image cloudImage = cloud.GetComponent<Image>();
        float alpha = 1f - ((float)counter.currentHits / hitsPerCloud);
        cloudImage.color = new Color(1, 1, 1, alpha);
        
        // check if clouds should disappear
        if (counter.currentHits >= hitsPerCloud)
        {
            remainingClouds--;
            Destroy(cloud);

            if (remainingClouds <= 0)
            {
                allCloudsCleared = true;
                Debug.Log("All clouds cleared! Press E to close the painting");
            }
        }
    }

    void ClosePainting()
    {
        paintingUI.SetActive(false);
        isPaintingOpen = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}

public class CloudHitCounter : MonoBehaviour
{
    public int hitsRequired = 3;
    public int currentHits = 0;
    
}
