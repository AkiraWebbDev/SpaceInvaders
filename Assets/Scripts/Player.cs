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

    public Transform explosionPrefab;

    // Private variables (not visible in the Inspector panel)
    // The speed of player movement
    float speed = GameMaster.playerSpeed;

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

    Attack attack;


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
                    Destroy(other.gameObject);
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
            Transform explosion = Instantiate(explosionPrefab);
            explosion.parent = transform.parent.parent;
            explosion.position = other.transform.position;
            Destroy(other.gameObject);
            Damage();
        }
    }

    AudioManager audioManager;

    void Awake()
    {
        spriteAnim = GameObject.Find("PlayerSprite").GetComponent<Animator>();
        if (spriteAnim == null)
        {
            print("Error, no animator found");
        }

        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        if (audioManager == null)
        {
            print("Error, no audio manager found");

        }

        attack = GetComponent<Attack>();
        if (attack == null)
        {
            print("Error, no attack reference found");

        }
    }


    // Update is called once per frame
    void Update () {
		// Player movement from input (it's a variable between -1 and 1) for
		// degree of left or right movement
		float vertMovementInput = Input.GetAxis("Vertical");
        float horiMovementInput = Input.GetAxis("Horizontal");

        // Can be cleaner...
        speed = GameMaster.playerSpeed;
        attack.fireCooldownTime = GameMaster.shotCooldown;

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
            audioManager.PlayPlayerRecharge();
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
        yield return (new WaitForSeconds(4.3f));
        playerInvulnerable = false;
    }
}