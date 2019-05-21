using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdater : MonoBehaviour {

    private TextMeshProUGUI scoreText;
    private GameSession session;

	// Use this for initialization
	void Start () {
        UpdateScore();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        session = FindObjectOfType<GameSession>();
        scoreText.SetText(session.getScore().ToString());
    }
}
