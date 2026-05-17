using UnityEngine;

public class GmManager : MonoBehaviour
{
    public static GmManager instance;
    
    private int paintingsCleared = 0;
    private int totalPaintings = 5;
    
    public GameObject room6;

    void Awake()
    {
        instance = this;
        room6.SetActive(false);
    }

    public void PaintingCleared()
    {
        paintingsCleared++;
        Debug.Log("Paintings cleared: " + paintingsCleared + "/" + totalPaintings);
        
        if (paintingsCleared >= totalPaintings)
        {
            room6.SetActive(true);
            Debug.Log("All paintings cleared! Room 6 unlocked.");
        }
    }
}
