using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * This class handles the displaying of high and latest scores. 
 * 
 * @version 1.3.2016
 * @author Alexander James Bochel
 */
public class HighScoreManager : MonoBehaviour {

    // Get the Text box to update scores. 
    public Text highScoreText;
    public Text latestScoreText;
    public float highScore;
    public float latestScore;

	/**
     *  Start method. 
     */
	void Start () {
        // Load saved high score and last score and add it to a variable. 
        highScore = PlayerPrefs.GetFloat("High Score", 0);
        latestScore = PlayerPrefs.GetFloat("Score at Death", 0);

        // Print the high score and latest score. 
        highScoreText.text = "High Score: " + highScore;
        latestScoreText.text = "Your Score: " + latestScore;
	}
}
