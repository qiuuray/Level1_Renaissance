using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
   public GameObject inventoryPanel;
   public Slot[] slots;
   
   // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	    foreach (var slot in slots)
	    {
           slot.Hide();
	    }
    }

	public bool AddItem(Sprite sprite)
	{
		//look for empty slot
		foreach (Slot slot in slots)
		{
			if (!slot.IsFull)
			{
				slot.Show(sprite);
				return true;
			}
		}
		Debug.Log("Inventory is full");
		return false;
	}
	
}