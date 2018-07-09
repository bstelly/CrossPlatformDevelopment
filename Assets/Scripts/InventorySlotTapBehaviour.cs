using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotTapBehaviour : MonoBehaviour
{

    public Collider2D collider2D;
    public PlayerBehaviour player;
    public Image image;

    // Use this for initialization
    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        player = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
        image = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount == 1)
        //{
        //    Vector2 touchPos = Input.GetTouch(1).position;
            
        //    if (collider2D == GraphicRaycaster./*Physics2D.OverlapPoint(touchPos))*/
        //    {
        //    }
        //}

    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (name == "Image")
        {
            player.inventory.items.Remove(player.inventory.items[0]);
        }
        if (name == "Image1")
        {
            player.inventory.items.Remove(player.inventory.items[1]);
        }
        if (name == "Image2")
        {
            player.inventory.items.Remove(player.inventory.items[2]);
        }
    }
}