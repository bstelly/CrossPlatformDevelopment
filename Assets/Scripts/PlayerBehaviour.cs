using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{

    private bool canJump = true;
    private float jumpModifier = 1;
    public bool gameWon;
    public int score;
    private SpriteRenderer renderer;

	void Start ()
	{
	    renderer = GetComponent<SpriteRenderer>();
	}

	void FixedUpdate ()
    {

	    GetInput();

        if (transform.position.y <= -100)
        {
            transform.position = new Vector3(-10, -19.77f, 0);
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
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1), ForceMode2D.Force);
                //transform.position += Vector3.up * jumpModifier;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            canJump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject world = GameObject.Find("World");
        GameObject coins = GameObject.Find("Coins");
        GameObject enemies = GameObject.Find("Enemies");
        GameObject boosts = GameObject.Find("JumpBoosts");


        if (col.gameObject.name == "WinArea")
        {
            gameWon = true;
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