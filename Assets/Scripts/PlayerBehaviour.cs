using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Advertisements;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

[Serializable]
public class PlayerBehaviour : MonoBehaviour
{
    public Inventory inventory;
    public static bool CanJump { get; set; }
    public static bool DiscardKeyDown { get; set; }
    public float jumpModifier = 1;
    //public static bool GameWon { get; set; }
    public int score;
    private SpriteRenderer renderer;
    //private Vector2 touchOrigin = -Vector2.one;

    void Start ()
	{
	    renderer = GetComponent<SpriteRenderer>();
	}

    void Update ()
    {
	    GetInput();
        if (transform.position.y <= -100)
        {
            transform.position = new Vector3(-10, -19.77f, 0);
            score -= 100;
            Debug.Log("Game Over");
        }
	}


    void GetInput()
    {
        //DETECTING TAPS FOR TOUCH CONTROLS

        //int horizontal = 0;
        //int vertical = 0;
        //if (Input.touchCount > 0)
        //{
        //    Touch touchOne = Input.touches[0];
        //    if (touchOne.phase == TouchPhase.Began)
        //    {
        //        touchOrigin = touchOne.position;
        //    }
        //    else if (touchOne.phase == TouchPhase.Ended && touchOrigin.x >= 0)
        //    {
        //        Vector2 touchEnd = touchOne.position;
        //        float x = touchEnd.x - touchOrigin.x;
        //        float y = touchEnd.y - touchOrigin.y;
        //        touchOrigin.x = -1;

        //        if (Mathf.Abs(x) > Mathf.Abs(y))
        //        {
        //            horizontal = x > 0 ? 1 : -1;
        //        }
        //        else
        //        {
        //            vertical = y > 0 ? 1 : -1;
        //        }
        //    }
        //}
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left;
            renderer.flipX = true;

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right;
            renderer.flipX = false;
        }

        if (Input.GetButton("Jump"))
        {
            if (CanJump)
            {
                transform.position += Vector3.up * jumpModifier;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            CanJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && !DiscardKeyDown)
        {
            DiscardKeyDown = true;
            if(inventory.items.Count >= 1)
            inventory.Remove(inventory.items[0]);
        }
        if (Input.GetKey(KeyCode.Alpha2) && !DiscardKeyDown)
        {
            DiscardKeyDown = true;
            if (inventory.items.Count >= 2)
                inventory.Remove(inventory.items[1]);
        }
        if (Input.GetKey(KeyCode.Alpha3) && !DiscardKeyDown)
        {
            DiscardKeyDown = true;
            if (inventory.items.Count >= 3)
                inventory.Remove(inventory.items[2]);
        }

        if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Alpha3))
        {
            DiscardKeyDown = false;
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            inventory.Serialize();
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            string directory = Application.persistentDataPath + "/save.json";
            string json = File.ReadAllText(directory);
            inventory.Deserialize(json);
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject world = GameObject.Find("World");
        GameObject coins = GameObject.Find("Coins");
        //GameObject enemies = GameObject.Find("Enemies");
        //GameObject boosts = GameObject.Find("JumpBoosts");


        //if (col.gameObject.name == "WinArea" && !GameWon)
        //{
        //    GameWon = true;
        //    var count = inventory.items.Count;
        //    count *= 5000;
        //    score += count;
        //}

        for (int i = 0; i < world.transform.childCount; i++)
        {
            if (col.gameObject.name == world.transform.GetChild(i).name)
            {
                CanJump = true;
            }
        }

        for (int i = 0; i < coins.transform.childCount; i++)
        {
            if (col.gameObject.name == coins.transform.GetChild(i).name)
            {
                Destroy(coins.transform.GetChild(i).gameObject);
                score += 100;
            }
        }

        //for (int i = 0; i < enemies.transform.childCount; i++)
        //{
        //    if (col.gameObject.name == enemies.transform.GetChild(i).name)
        //    {
        //        transform.position = new Vector3(-10, -19.77f, 0);
        //        score -= 100;
        //    }
        //}

        //for (int i = 0; i < boosts.transform.childCount; i++)
        //{
        //    if (col.gameObject.name == boosts.transform.GetChild(i).name)
        //    {
        //        Destroy(boosts.transform.GetChild(i).gameObject);
        //        jumpModifier += .5f;
        //    }
        //}

    }
}