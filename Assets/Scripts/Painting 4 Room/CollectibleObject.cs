using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectibleObject : MonoBehaviour
{
    public Sprite itemSprite;
    public string itemName;
    public string itemDescription;

    public GameObject itemPopup;
    public Image popupImage;
    public TMPro.TextMeshProUGUI popupName;
    public TMPro.TextMeshProUGUI popupDescription;

    private bool isCollected = false;

    void Start()
    {
        itemPopup.SetActive(false);
    }

    void OnMouseDown()
    {
        if (isCollected) return;
        isCollected = true;
        
        // show big popup with item info
        popupImage.sprite = itemSprite;
        popupName.text = itemName;
        popupDescription.text = itemDescription;
        itemPopup.SetActive(true);
        
        // add to inventory
        InventoryController inventory = FindFirstObjectByType<InventoryController>();
        if (inventory != null)
            inventory.AddItem(itemSprite);
        
        CollectibleManager.instance.ObjectCollected();
        
        Invoke("ClosePopup", 3f); //auto closes after 2 secs
    }

    void ClosePopup()
    {
        itemPopup.SetActive(false);
        gameObject.SetActive(false);
    }
}
