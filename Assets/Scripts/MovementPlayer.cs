using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementPlayer : MonoBehaviour
{
    private bool isNearTeleporter = false;

    void Update()
    {
        if (isNearTeleporter && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Scene2");
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CompareTag("Teleporter"))
            isNearTeleporter = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Teleporter"))
            isNearTeleporter = false;
    }
}
