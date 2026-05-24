using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToStart : MonoBehaviour
{
    public AudioClip clickSound;
    private AudioSource audioSource;
    public float delay = 1f;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void LoadStartScreen()
    {
        if (clickSound != null)
            audioSource.PlayOneShot(clickSound);
        Invoke("LoadStart", delay);
    }
    
    void LoadStart()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
