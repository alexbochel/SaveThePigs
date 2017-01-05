using UnityEngine;
using System.Collections;

/**
 * This class handles the movement of the platforms. 
 * 
 * @version 12.19.2016
 * @author Alexander James Bochel
 */
public class PlatformMovement : MonoBehaviour {

    // Variable for the platform moveSpeed. 
    public float platSpeed;

    // Rigidbody variable for platform. 
    private Rigidbody2D platBody;

    // Variable to store current score of the game. 
    public ScoreManager currentScore;


	// Use this for initialization
	void Start () {

        // Set the platform body to the variable. 
        platBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        platBody.velocity = new Vector2(platSpeed, platBody.velocity.y);
        speedUp();
	}

    /**
     * This method speeds up the platforms as the score goes up.
     */
     public void speedUp()
    {
        if (currentScore.scoreCount > 25f)
        {
            platSpeed = -110;
        }
        if (currentScore.scoreCount > 50f)
        {
            platSpeed = -120;
        }
        if (currentScore.scoreCount > 75f)
        {
            platSpeed = -130;
        }
        if (currentScore.scoreCount > 100f)
        {
            platSpeed = -140;
        }
        if (currentScore.scoreCount > 200f)
        {
            platSpeed = -150;
        }
        if (currentScore.scoreCount > 300f)
        {
            platSpeed = -160;
        }
    }
}
