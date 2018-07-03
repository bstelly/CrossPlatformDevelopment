using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    private GameObject player;
    private float z = -90;



    void Start ()
	{
	    player = GameObject.Find("Player");

	}



    void Update ()
	{
	    transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 10, z);

	}
}
