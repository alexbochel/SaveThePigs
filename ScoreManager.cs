using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;

/**
 * This class manages the saving of high and latest scores. 
 * 
 * @version 1.10.2016
 * @author Alexander James Bochel
 */
public class ScoreManager : MonoBehaviour {

    // Score text and count
    public Text scoreText;
    public long scoreCount;
    public float pointsPerSecond;
    public bool canAddPoints = true;
	
	/**
     *  Update is called once per frame.
     */
	void Update () {
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        checkNewHighScore();

        // TODO - Remove ater update 2.0
        reportScore((long)PlayerPrefs.GetFloat("High Score", 0), "saveThePigs");
    }

    /**
     * This method checks to see if a new high score can be added. 
     */
     public void checkNewHighScore()
    {
        if (scoreCount > PlayerPrefs.GetFloat("High Score", 0))
        {
            saveHighScore();
            reportScore(scoreCount, "saveThePigs");
        }
    }

    /**
     * This method saves the high score for the local game. 
     */
     public void saveHighScore()
    {
        PlayerPrefs.SetFloat("High Score", scoreCount);
    }

    /**
     * This method reports the new high score to Gamecenter. 
     * @param score The high score being reported. 
     * @param string ID of the leaderboard being reported to. 
     */
     public void reportScore(long score, string leaderboardID)
    {
        Debug.Log("Reporting score " + score + " on leaderboard " + leaderboardID);
        Social.ReportScore(score, leaderboardID, success =>
        {
            Debug.Log(success ? "Reported score successfully" : "Failed to report score");
        });
    }
}
