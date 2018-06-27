using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class PanelBehaviour : MonoBehaviour {

    private PlayerBehaviour player;
    public Image imageBox1;
    public Image imageBox2;
    public Image imageBox3;
    private List<Image> images;

    void Start()
    {
        images = new List<Image>{imageBox1, imageBox2, imageBox3};
        player = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update () {
	    var count = player.inventory.items.Count;

        for (int i = 0; i < 3; i++)
        {
            images[i].sprite = null;
        }

        for (int i = 0; i < count; i++)
	    {
	        images[i].sprite = player.inventory.items[i].image;
	    }
    }
}
