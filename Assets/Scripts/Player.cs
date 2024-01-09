/*
	Created by: Lech Szymanski
				lech.szymanski@otago.ac.nz
				COSC360: Computer Game Design
*/

using UnityEngine;

public class Player : MonoBehaviour {

	// Private variables (not visible in the Inspector panel)
	// The speed of player movement
	float speed = 10;

    // Flag indicating whether the player is at the 
    // left edge of the screen
    bool atLeftWall = false;

    // Flag indicating whether the player is at the 
    // right edge of the screen
    bool atRightWall = false;

    // On collision with a trigger collider...
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check the tag of the object the player
        // has collided with
        if (other.tag == "LeftWall")
        {
            // If collided with the left wall, set
            // the left wall flag to true
            atLeftWall = true;
        }
        else if (other.tag == "RightWall")
        {
            // If collided with the right wall, set
            // the right wall flag to true
            atRightWall = true;
        }
    }

    // When no longer colliding with an object...
    void OnTriggerExit2D(Collider2D other)
    {
        // Check the tag of the object the player
        // has ceased to collide with
        if (other.tag == "LeftWall")
        {
            // If collided with the left wall, set
            // the left wall flag to true
            atLeftWall = false;
        }
        else if (other.tag == "RightWall")
        {
            // If collided with the right wall, set
            // the right wall flag to true
            atRightWall = false;
        }
    }

    // Update is called once per frame
    void Update () {
		// Player movement from input (it's a variable between -1 and 1) for
		// degree of left or right movement
		float movementInput = Input.GetAxis("Horizontal");

        // If close to wall and moving towards it,
        // stop the movement
        if (atLeftWall && (movementInput < 0))
        {
            movementInput = 0;
        }
        if (atRightWall && (movementInput > 0))
        {
            movementInput = 0;
        }

        // Move the player object
        transform.Translate( new Vector3(Time.deltaTime * speed * movementInput,0,0), Space.World);	
	}
}