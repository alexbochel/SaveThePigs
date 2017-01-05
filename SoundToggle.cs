using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class allows for the game sound to be turned on and off (unfinished). 
 * 
 * @version 1.5.2016
 * @author Alexander James Bochel
 */
public class SoundToggle : MonoBehaviour {

	/**
	 * This method turns sound on. 
	 */
	public void soundOn() {
		AudioListener.pause = false;
	}

	/**
	 * This method turns the sound off. 
	 */
	public void soundOff() {
		AudioListener.pause = true;
	}
}
