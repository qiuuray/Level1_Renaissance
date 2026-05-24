using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioClip interactSound;
    private AudioSource audioSource;
    public float delay = 1f; // delay so you can hear the full sound
    
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void Game() 
    {
        if (interactSound != null)
            audioSource.PlayOneShot(interactSound);
        DontDestroyOnLoad(gameObject); // stops start sound from being destroyed
        Invoke("LoadScene", delay);
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Scene 1 Sample");
    }

}
