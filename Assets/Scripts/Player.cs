/*
	Created by: Lech Szymanski
				lech.szymanski@otago.ac.nz
				COSC360: Computer Game Design
    Updated by: Luke Webb
                weblu938@student.otago.ac.nz
*/

using UnityEngine;
using System.Collections;

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

    bool atLeftWall = false;
    bool atRightWall = false;

    Animator spriteAnim;

    bool playerInvulnerable = false;

    // On collision with a trigger collider...
    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "TopWall":
                // If collided with the top wall, set
                // the top wall flag to true
                atTopWall = true;
                break;

            case "BottomWall":
                // If collided with the bottom wall, set
                // the bottom wall flag to true
                atBottomWall = true;
                break;

            case "LeftWall":
                atLeftWall = true;
                break;

            case "RightWall":
                atRightWall = true;
                break;

            default:
                // Collision with something that is not a wall
                // Check if collided with a projectile
                // A projectile has a Projectile script component,
                // so try to get a reference to that component
                Projectile projectile = other.GetComponent<Projectile>();

                //If that reference is not null, then check if it's an enemyProjectile      
                if (projectile != null && projectile.enemyProjectile)
                {
                    // Collided with an enemy projectile
                    Damage();
                }
                break;
        }
    }

    // When no longer colliding with an object...
    void OnTriggerExit2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "TopWall":
                // If collided with the top wall, set
                // the top wall flag to true
                atTopWall = false;
                break;

            case "BottomWall":
                // If collided with the bottom wall, set
                // the bottom wall flag to true
                atBottomWall = false;
                break;

            case "LeftWall":
                atLeftWall = false;
                break;

            case "RightWall":
                atRightWall = false;
                break;

            default:
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Damage();
        }
    }

    void Start()
    {
        spriteAnim = GameObject.Find("PlayerSprite").GetComponent<Animator>();
        if (spriteAnim == null)
        {
            print("Error, no animator found");
        }
    }


    // Update is called once per frame
    void Update () {
		// Player movement from input (it's a variable between -1 and 1) for
		// degree of left or right movement
		float vertMovementInput = Input.GetAxis("Vertical");
        float horiMovementInput = Input.GetAxis("Horizontal");


        // If close to wall and moving towards it,
        // stop the movement
        if (atTopWall && (vertMovementInput > 0))
        {
            vertMovementInput = 0;
        }
        if (atBottomWall && (vertMovementInput < 0))
        {
            vertMovementInput = 0;
        }
        if (atLeftWall && (horiMovementInput < 0))
        {
            horiMovementInput = 0;
        }
        if (atRightWall && (horiMovementInput > 0))
        {
            horiMovementInput = 0;
        }

        // Move the player object
        transform.Translate(
            new Vector3(
                        Time.deltaTime * speed * horiMovementInput,
                        Time.deltaTime * speed * vertMovementInput,
                        0), Space.World);


        if(Input.GetButton("Jump"))
        {
            // Get player's attack component
            // and execute it's shoot() method
            Attack attack = GetComponent<Attack>();
            attack.Shoot();
        }
	}

    public void Damage()
    {
        if (!playerInvulnerable)
        {
            // Report the player hit to the game master
            GameMaster.PlayerHit();
            spriteAnim.SetTrigger("Hit");
            StartCoroutine("PlayerInvulnTimer");
        }
        else
        {
            return;
        }
    }

    IEnumerator PlayerInvulnTimer()
    {
        playerInvulnerable = true;
        yield return (new WaitForSeconds(1));
        playerInvulnerable = false;
    }
}