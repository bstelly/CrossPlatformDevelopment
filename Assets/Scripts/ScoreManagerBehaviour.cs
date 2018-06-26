using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManagerBehaviour : MonoBehaviour
{
    private int score;
    public Text scoreText;
    private PlayerBehaviour player;
    // Use this for initialization

    void Start () {
	    player = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
	}

	// Update is called once per frame
	void Update () {
	    scoreText.text = "Score: " + player.score;
	    if (player.gameWon)
	    {
        }
    }
}
