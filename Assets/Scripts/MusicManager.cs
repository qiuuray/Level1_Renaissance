using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    void Awake()
    {
        // only one music manager ever exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // persists between scenes
        }
        else
        {
            Destroy(gameObject);  // destroy duplicates
        }
    }
}
