using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{

    public Item item;
    public SpriteRenderer sr;
    private bool isColliding = false;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = item.image;
    }

    // Update is called once per frame
    void Update()
    {

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
            player.inventory.items.Add(item);
            Destroy(gameObject);
        }
    }

}
