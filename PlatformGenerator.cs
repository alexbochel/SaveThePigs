using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

    // Variable field for the random number that will determine platform spacing. 
    float waitingTime;
    float timer;

    // Variable for yPosition of next platform. 
    float yPos;

    // Variable for the next platform spawned by current platform. 
    public GameObject newPlatform;

    // Variable for the collider. 
    public BoxCollider2D boxCollider;

	/**
     * Use this for initialization
     */
	void Start () {
        waitingTime = Random.Range(0.9f, 1.3f);
        boxCollider = GetComponent<BoxCollider2D>();
	}
	
	/**
     * Update is called once per frame
     */
	void Update () {
        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            createPlatform();
            timer = -20;
        }

        ensurePosition();
	} 

    /**
     * This method creates a new platform object when the counter is 0.
     */
     public void createPlatform()
    {
        // Generate relatively random number for y position of new platform. 
        yPos = Random.Range(transform.position.y - 20, transform.position.y + 20);

        // Create the new platform at given y coordinate. 
        Instantiate(this, new Vector2(Screen.width / 5, yPos), Quaternion.identity);
    }
	 
    /**
     * This method ensures the y position is appropriate. 
     */
     private void ensurePosition()
    {
        // Checks for yPos above the screen. 
        if (transform.position.y > 75f)
        {

            int offsetY =  Random.Range(20, 100);
            yPos = transform.position.y - offsetY;
            transform.position = new Vector2(transform.position.x, yPos);
        }

        // Checks for yPos below screen.
        if (transform.position.y < -75f)
        {
            yPos = transform.position.y + 5;
            transform.position = new Vector2(transform.position.x, yPos);
        }
    }
}
