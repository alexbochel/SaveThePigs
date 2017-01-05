using UnityEngine;
using System.Collections;

/**
 * This class handles the brown pig's movement. 
 * 
 * @version 12.18.2016
 * @author Alexander James Bochel
 */
public class PigMovement : MonoBehaviour {

    // This field controls the players jump speed. 
    public float jumpSpeed;

    // This field holds the RigidBody 2D component that will be affected. 
    private Rigidbody2D myBody;

    // Selection of layer masks available. 
    public LayerMask whatIsGround;
    public LayerMask whatIsAlsoGround;

    // Get the collider of the pig object. 
    private Collider2D myCollider;

    // Get the score for the ScoreManager. 
    public ScoreManager scoreTracker;

    /*
     * Use this for initialization
     */
    void Start ()
    {
        // Set the rigid body and collider to that of the pigs.  
        myBody = GetComponent<Rigidbody2D>(); 
        myCollider = GetComponent<BoxCollider2D>();
	}
	
	/*
     * Update is called once per frame
     */
	void Update ()
    {
        myBody.velocity = new Vector2(myBody.velocity.x, myBody.velocity.y);

        jump();
	}

    /*
     * This changes the jumpSpeed to allow the player to jump.  
     */
    public void jump()
    {
        if (checkCanJump())
        {
            myBody.velocity = new Vector2(myBody.velocity.x, jumpSpeed);
            scoreTracker.scoreCount++;
        }
    }

    /*
     * This helper method checks if the player is touching the ground and
     * whether or not the spaceBar has been pressed.  
     */
    private bool checkCanJump()
    {
        // For laptop control. 
        if (Input.GetKeyDown(KeyCode.UpArrow) && Physics2D.IsTouchingLayers(myCollider, whatIsGround))
        {
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && Physics2D.IsTouchingLayers(myCollider, whatIsAlsoGround))
        {
            return true;
        }

        // For mobile device control. 
        foreach (Touch touch in Input.touches) {

            if (touch.position.x > (Screen.width / PixelPerfectCamera.pixelsToUnits) / 2 &&
                Physics2D.IsTouchingLayers(myCollider, whatIsGround))
            {
                return true;
            }
            else if (touch.position.x > Screen.width / 2 && 
                Physics2D.IsTouchingLayers(myCollider, whatIsAlsoGround))
            {
                return true;
            }
        }

        return false;
    }
}
