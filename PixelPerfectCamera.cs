using UnityEngine;
using System.Collections;

/**
 * This class allows for scaling depending on the camera being used (Unfinished)
 * 
 * @version 12.29.2016
 * @author Alexander James Bochel
 */
public class PixelPerfectCamera : MonoBehaviour {

    public static float pixelsToUnits = 1f;
    public static float scale = 1f;
    public Vector2 nativeResolution = new Vector2(240, 160);

    /**
     * Awake
     */
	void Awake () {
        var camera = GetComponent<Camera>();

        if (camera.orthographic)
        {
            scale = Screen.height / nativeResolution.y;
            pixelsToUnits *= scale;
            camera.orthographicSize = (Screen.height / 2.0f) / (pixelsToUnits);
        }
	}
}
