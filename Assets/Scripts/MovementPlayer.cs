using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementPlayer : MonoBehaviour
{
    public GameObject dialogueBox;
    public string sceneToLoad = "Scene2";
    public float delayBeforeTeleport = 3f; // so players have time to read
    
    private bool isNearTeleporter = false;

    void Awake()
    {
        dialogueBox.SetActive(false);
    }
    void Update()
    {
        if (!isNearTeleporter) return;
        
        if (isNearTeleporter && Input.GetKeyDown(KeyCode.E))
        {
            {
                dialogueBox.SetActive(true);
                Invoke("LoadScene", delayBeforeTeleport);
            }
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CompareTag("Teleporter"))
            isNearTeleporter = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Teleporter"))
        {
            isNearTeleporter = false;
            dialogueBox.SetActive(false);
        }
           
    }
}
