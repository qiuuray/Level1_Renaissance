using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public Sprite Sprite;
    
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Sprite;
    }
}
