using UnityEngine;

public class GmManager : MonoBehaviour
{
    public static GmManager instance;
    
    private int paintingsCleared = 0;
    private int totalPaintings = 4;
    
    public GameObject room6;

    void Awake()
    {
        instance = this;
    }

    public void PaintingCleared()
    {
        paintingsCleared++;
        Debug.Log("Paintings cleared: " + paintingsCleared + "/" + totalPaintings);
    }
    
    public bool AllCleared()
    {
        return paintingsCleared >= totalPaintings;
    }
}
