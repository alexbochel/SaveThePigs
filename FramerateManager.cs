using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class handles the framerate for the game. 
 * 
 * @version 1.10.2017
 * @author Alexander James Bochel
 */
public class FramerateManager : MonoBehaviour {

	/**
     * This method sets the framerate. 
     */
     void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
