/*
	Created by: Lech Szymanski
				lech.szymanski@otago.ac.nz
				COSC360: Computer Game Design
    Updated by: Luke Webb
                weblu938@student.otago.ac.nz
*/

using UnityEngine;

public class Player : MonoBehaviour {

	// Private variables (not visible in the Inspector panel)
	// The speed of player movement
	float speed = 10;

    // Flag indicating whether the player is at the 
    // left edge of the screen
    bool atTopWall = false;

    // Flag indicating whether the player is at the 
    // right edge of the screen
    bool atBottomWall = false;

    // On collision with a trigger collider...
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check the tag of the object the player
        // has collided with
        if (other.tag == "TopWall")
        {
            // If collided with the top wall, set
            // the top wall flag to true
            atTopWall = true;
        }
        else if (other.tag == "BottomWall")
        {
            // If collided with the bottom wall, set
            // the bottom wall flag to true
            atBottomWall = true;
        }
        else
        {
            // Collision with something that is not a wall
            // Check if collided with a projectile
            // A projectile has a Projectile script component,
            // so try to get a reference to that component
            Projectile projectile = other.GetComponent<Projectile>();

            //If that reference is not null, then check if it's an enemyProjectile      
            if (projectile != null && projectile.enemyProjectile)
            {
                // Collided with an enemy projectile

                // Destroy the projectile game object
                Destroy(other.gameObject);

                // Report the player hit to the game master
                GameMaster.PlayerHit();

                // Destroy self
                Destroy(gameObject);
            }
        }
    }

    // When no longer colliding with an object...
    void OnTriggerExit2D(Collider2D other)
    {
        // Check the tag of the object the player
        // has ceased to collide with
        if (other.tag == "TopWall")
        {
            // If collided with the left wall, set
            // the left wall flag to true
            atTopWall = false;
        }
        else if (other.tag == "BottomWall")
        {
            // If collided with the right wall, set
            // the right wall flag to true
            atBottomWall = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            // Report enemy hit to the game master
            GameMaster.PlayerHit();

            // Destroy the player game object
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update () {
		// Player movement from input (it's a variable between -1 and 1) for
		// degree of left or right movement
		float movementInput = Input.GetAxis("Vertical");

        // If close to wall and moving towards it,
        // stop the movement
        if (atTopWall && (movementInput > 0))
        {
            movementInput = 0;
        }
        if (atBottomWall && (movementInput < 0))
        {
            movementInput = 0;
        }

        // Move the player object
        transform.Translate( new Vector3(0, Time.deltaTime * speed * movementInput, 0), Space.World);

        if(Input.GetButton("Jump"))
        {
            // Get player's attack component
            // and execute it's shoot() method
            Attack attack = GetComponent<Attack>();
            attack.Shoot();
        }
	}
}