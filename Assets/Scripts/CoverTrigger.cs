using UnityEngine;
using UnityEngine.EventSystems;

public class CoverTrigger : MonoBehaviour, IPointerEnterHandler
{
    private PaintingReveal revealScript;

    void Start()
    {
        revealScript = FindObjectOfType<PaintingReveal>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (revealScript != null)
            revealScript.OnCoverSwiped();
    }
}