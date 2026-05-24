using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsScene : MonoBehaviour
{
    public AudioClip clickSound;
    private AudioSource audioSource;
    public float delay = 1f;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void LoadControls()
    {
        if (clickSound != null)
            audioSource.PlayOneShot(clickSound);
        Invoke("Load", delay);
    }
    
    void Load()
    {
        SceneManager.LoadScene("Controls");
    }
}
