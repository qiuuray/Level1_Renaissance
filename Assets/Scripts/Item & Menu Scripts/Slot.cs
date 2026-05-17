using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image currentItem; //the item currently held in this slot
   public bool IsFull;

    public void Hide()
    {
        currentItem.color = Color.clear;
        IsFull = false;
    }

    public void Show(Sprite sprite)
    {
        currentItem.sprite = sprite;
        currentItem.color = Color.white;

        IsFull = true;
    }
}

