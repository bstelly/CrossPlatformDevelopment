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

    void Start () {
	    player = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
	}

    void Update () {
	    scoreText.text = "Score: " + player.score;
	}
}
