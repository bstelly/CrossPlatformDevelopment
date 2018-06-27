using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public Inventory inventory;
    private bool canJump = true;
    private bool discardKeyDown = false;
    private float jumpModifier = 1;
    public bool gameWon;
    public int score;
    private SpriteRenderer renderer;

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
            if (canJump)
            {
                transform.position += Vector3.up * jumpModifier;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            canJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && !discardKeyDown)
        {
            discardKeyDown = true;
            if(inventory.items.Count >= 1)
            inventory.Remove(inventory.items[0]);
        }
        if (Input.GetKey(KeyCode.Alpha2) && !discardKeyDown)
        {
            discardKeyDown = true;
            if (inventory.items.Count >= 2)
                inventory.Remove(inventory.items[1]);
        }
        if (Input.GetKey(KeyCode.Alpha3) && !discardKeyDown)
        {
            discardKeyDown = true;
            if (inventory.items.Count >= 3)
                inventory.Remove(inventory.items[2]);
        }

        if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Alpha3))
        {
            discardKeyDown = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject world = GameObject.Find("World");
        GameObject coins = GameObject.Find("Coins");
        GameObject enemies = GameObject.Find("Enemies");
        GameObject boosts = GameObject.Find("JumpBoosts");


        if (col.gameObject.name == "WinArea" && !gameWon)
        {
            gameWon = true;
            var count = inventory.items.Count;
            count *= 5000;
            score += count;
        }

        for (int i = 0; i < world.transform.childCount; i++)
        {
            if (col.gameObject.name == world.transform.GetChild(i).name)
            {
                canJump = true;
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

        for (int i = 0; i < enemies.transform.childCount; i++)
        {
            if (col.gameObject.name == enemies.transform.GetChild(i).name)
            {
                transform.position = new Vector3(-10, -19.77f, 0);
                score -= 100;
            }
        }

        for (int i = 0; i < boosts.transform.childCount; i++)
        {
            if (col.gameObject.name == boosts.transform.GetChild(i).name)
            {
                Destroy(boosts.transform.GetChild(i).gameObject);
                jumpModifier += .5f;
            }
        }

    }
}