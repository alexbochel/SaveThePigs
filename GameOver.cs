using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

/**
 * This class controls what happens when a pig falls off of the screen.
 *  
 * @version 12.25.2016
 * @author Alexander James Bochel
 */
public class GameOver : MonoBehaviour {

    // In game music
    public AudioClip gameMusic;

    // Text for GameOver screen.
    public float scoreAtDeath;

    // Score manager containing score value. 
    public ScoreManager scoreManager;

    // Game count for ads. 
    public int adCount;
    

	/**
     * Update
     */
	void Update () {
	    if (isOffscreen())
        {
            deletePig();
            toGameOverScreen();
            adCount = PlayerPrefs.GetInt("Play Ad", 0) + 1;
            PlayerPrefs.SetInt("Play Ad", adCount);
            showAd();
        }
	}

    /**
     * This method checks to see if the pig is offscreen. 
     * 
     * @return bool Whether ot not the pig is offscreen. 
     */
     public bool isOffscreen()
    {
        // Checks for yPos below or behind screen. 
        if (transform.position.y < -80)
        {
            return true;
        }

        return false;
    }

    /**
     * This method deletes the pig from the world.
     */
     public void deletePig()
    {
        Destroy(gameObject);
    }

    /**
     * This method changes the scene to the GameOver Screen. 
     */
     public void toGameOverScreen()
    {
        scoreAtDeath = scoreManager.scoreCount;
        PlayerPrefs.SetFloat("Score at Death", scoreAtDeath);
        SceneManager.LoadScene("GameOver");
    }

    /**
     * This method plays the unity add after every three games. 
     */
    public void showAd()
    {
        if (adCount == 5)
        {
            Advertisement.Show();
            PlayerPrefs.SetInt("Play Ad", 0);
        }
    }
}