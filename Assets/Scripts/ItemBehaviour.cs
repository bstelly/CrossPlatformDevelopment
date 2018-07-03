using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{

    public Item item/* = new Item()*/;
    public SpriteRenderer sr;
    private bool isColliding = false;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = item.image;
        item.imagePath = AssetDatabase.GetAssetPath(sr.sprite);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isColliding)
        {
            return;
        }

        isColliding = true;
        Debug.Log("collided");
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerBehaviour>();
            player.inventory.Add(item);
            Destroy(gameObject);
        }
    }
}
