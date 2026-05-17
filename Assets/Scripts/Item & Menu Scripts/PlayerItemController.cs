using UnityEngine;

public class PlayerItemController : MonoBehaviour
{
    private InventoryController inventoryController;

    private Item item;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryController = FindFirstObjectByType<InventoryController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                //add item to inventory
                bool itemAdded = inventoryController.AddItem(item.Sprite);
                if (itemAdded)
                {
                    Destroy(collision.gameObject);
                }
            }
        }
        
    }
}
