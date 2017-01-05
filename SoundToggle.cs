using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
