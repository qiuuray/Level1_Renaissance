using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager instance;

    public int totalObjects = 5;
    private int collectedCount = 0;

    public GameObject completionDialogue; // pops up when you finish collecting the items
    public string TitleScreen;
    public Image fadeImage; // black UI image covering the screen, used to fade to black

    void Awake()
    {
        instance = this;
        completionDialogue.SetActive(false);
        if (fadeImage != null)
        {
            fadeImage.color = new Color(0, 0, 0, 0); //start transparent
        }
    }
    
    public void ObjectCollected()
    {
        collectedCount++;
        Debug.Log("Collected: " + collectedCount + "/" + totalObjects);

        if (collectedCount >= totalObjects)
        {
            completionDialogue.SetActive(true);
            Invoke("StartFade", 5f);
        }
    }

    void StartFade()
    {
        completionDialogue.SetActive(false);
        StartCoroutine(FadeToBlack());
    }

    System.Collections.IEnumerator FadeToBlack()
    {
        float duration = 2f;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Clamp01(timer / duration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        
        SceneManager.LoadScene(TitleScreen);
    }
}
