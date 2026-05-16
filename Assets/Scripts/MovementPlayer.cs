using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementPlayer : MonoBehaviour
{
    public GameObject teleporter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CompareTag("Teleporter"))
        {
           SceneManager.LoadScene("Scene2");
        }
    }
}
