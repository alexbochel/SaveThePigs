using UnityEngine;
using System.Collections;

/**
 * This script deletes a platform once it is far enough away from the screen. 
 */
public class DeletePlatform : MonoBehaviour {

    public float offset = 10000f;

    private bool offscreen;
    private float offscreenX;
    public Rigidbody2D myBody;

    public float posX;
    public float dirX;

    /**
     * Awake
     */ 
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

	/**
     * Start
     */
	void Start ()
    {
        offscreenX = (Screen.width / PixelPerfectCamera.pixelsToUnits) / 2 + offset;
	}
	
	/**
     * Updates the game. 
     */
	void Update ()
    {
        posX = transform.position.x;
        dirX = myBody.velocity.x;

        checkOffset();

        if (checkOffset())
        {
            OutOfBounds();
        }
	}

    /**
     * This method checks to see if the object is offscreen. 
     */
    public bool checkOffset()
    {
        if (Mathf.Abs (posX) > offscreenX)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /**
     * This method deletes the object from the game. 
     */
     public void OutOfBounds()
    {
        Destroy(gameObject);
    }
}
