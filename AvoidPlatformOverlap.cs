using UnityEngine;
using System.Collections;

public class AvoidPlatformOverlap : MonoBehaviour {

    public LayerMask pinkLayer;
    public BoxCollider2D brownCollider;
    public GameObject pinkPlatform;
	
	/**
     * Update
     */
	void Update () {
	    if (checkOverlap())
        {
            relocate();
        }
	}

    /**
     * This method checks to see if a brown and pink platform are overlapping. 
     */
     public bool checkOverlap()
    {
        if (Physics2D.IsTouchingLayers(brownCollider, pinkLayer))
        {
            return true;
        }
        return false;
    }

    /**
     * This method relocates the brown platform if it is touching the pink one. 
     */
     public void relocate()
    {
        float yPos = Random.Range(transform.position.y - 20, transform.position.y + 20);
        transform.position = new Vector2(transform.position.x, yPos);
    }
}
