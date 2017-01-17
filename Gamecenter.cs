using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;

/**
 * This class controls the Gamecenter social platform. 
 * 
 * @version 1.1.2017
 * @author Alexander James Bochel
 */
public class Gamecenter : MonoBehaviour
{

    /**
     *  Use this for initialization
     */
    void Start()
    {
        // Authenticate and register a ProcessAuthentication callback
        // This call needs to be made before we can proceed to other calls in the Social API
        Social.localUser.Authenticate(ProcessAuthentication);
    }

    /**
     *  This function gets called when Authenticate completes
     *  @param success Boolean 
     */
    public void ProcessAuthentication(bool success)
    {
        if (success)
        {
            Debug.Log("Authenticated, checking achievements");

            // Request loaded achievements, and register a callback for processing them
            Social.LoadAchievements(ProcessLoadedAchievements);
        }
        else
            Debug.Log("Failed to authenticate");
    }

    // This function gets called when the LoadAchievement call completes
    void ProcessLoadedAchievements(IAchievement[] achievements)
    {
        if (achievements.Length == 0)
            Debug.Log("Error: no achievements found");
        else
            Debug.Log("Got " + achievements.Length + " achievements");

        // You can also call into the functions like this
        Social.ReportProgress("Achievement01", 100.0, result =>
        {
            if (result)
                Debug.Log("Successfully reported achievement progress");
            else
                Debug.Log("Failed to report achievement");
        });
    }

    /**
     * When called, this method displays the high scores leaderboard. 
     */
     public void showLeaderboard()
    {
        GameCenterPlatform.ShowLeaderboardUI("saveThePigs", TimeScope.AllTime);
        Social.ShowLeaderboardUI();
    }
}
