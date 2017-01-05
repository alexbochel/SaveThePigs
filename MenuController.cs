using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    /**
     * This method changes the scene from the menu. 
     * @param sceneName The scene to move to. 
     */
    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
	
}
