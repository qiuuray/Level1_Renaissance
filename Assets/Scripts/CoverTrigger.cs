using UnityEngine;

public class CoverTrigger : MonoBehaviour
{
    public PaintingReveal revealScript;

    void OnMouseOver()
    {
        revealScript.OnCoverSwiped();
    }
}