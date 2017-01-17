using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.GameCenter;

/**
 * This class allows for the changing of scenes. 
 * 
 * @version 1.5.2016
 * @author Alexander James Bochel
 */
public class MenuController : MonoBehaviour
{

    /**
     * This method changes the scene from the menu. 
     * 
     * @param sceneName The scene to move to. 
     */
    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }	
}
