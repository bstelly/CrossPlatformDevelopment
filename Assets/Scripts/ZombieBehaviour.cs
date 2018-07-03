using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{

    public float timer;
    private SpriteRenderer renderer;

	void Start ()
	{
	    timer = 0;
	    renderer = GetComponent<SpriteRenderer>();
	}

	void Update ()
	{
	    timer += Time.deltaTime;
	    if (timer <= 1)
	    {
	        transform.position += Vector3.left;
	        renderer.flipX = true;
	    }

	    if (timer <= 2 && timer > 1)
	    {
            transform.position += Vector3.up;
        }

	    if (timer > 2 && timer <= 3)
	    {
	        transform.position += Vector3.right;
	        renderer.flipX = false;

        }

        if (timer <= 4 && timer > 3)
	    {
	        transform.position += Vector3.up;
        }
        if (timer >= 4)
	    {

	        timer = 0;
	    }
	}
}
