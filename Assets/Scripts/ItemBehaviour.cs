using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{

    public string name;
    public SpriteRenderer sr;
    public Sprite image;
    private bool isColliding = false;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        image = sr.sprite;
        //item.imagePath = AssetDatabase.GetAssetPath(sr.sprite);
        //Debug.Log("Asset path " + item.imagePath);
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
            player.inventory.Add(this);
            Destroy(gameObject);
        }
    }
}
