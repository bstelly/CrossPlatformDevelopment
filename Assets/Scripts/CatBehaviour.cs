using System.Collections;
using System.Collections.Generic;
using System.Threading;

using UnityEngine;

public class CatBehaviour : MonoBehaviour
{
    private float timer = 0;

    void Start () {
	    System.Random rand = new System.Random();
	    timer = rand.Next(0, 5);
    }

    void Update ()
	{
	    timer += Time.deltaTime;

	    if (timer <= 2)
	    {
            transform.position += Vector3.up;
	    }

	    if (timer >= 4)
	    {
	        timer = 0;
	    }
	}
}
