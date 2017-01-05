using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    // Score text and count
    public Text scoreText;
    public float scoreCount;
    public float pointsPerSecond;
    public bool canAddPoints = true;
	
	/**
     *  Update is called once per frame.
     */
	void Update () {
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        checkNewHighScore();
	}

    /**
     * This method checks to see if a new high score can be added. 
     */
     public void checkNewHighScore()
    {
        if (scoreCount > PlayerPrefs.GetFloat("High Score", 0))
        {
            saveHighScore();
        }
    }

    /**
     * This method saves the high score for the local game. 
     */
     public void saveHighScore()
    {
        PlayerPrefs.SetFloat("High Score", scoreCount);
    }
}
