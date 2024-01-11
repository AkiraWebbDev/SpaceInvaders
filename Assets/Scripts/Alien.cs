using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public Transform explosionPrefab;

    // Points the alien is worth
    public int points = 100;

    // When enemy collides with an object with a
    // collider that is a trigger...
    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyWave wave;

        // Check if colliding with the left or right wall
        // (by checking the tags of the collider that the enemy
        //  collided with)
        if (other.tag == "TopWall")
        {
            // If collided with the left wall, get a reference
            // to the EnemyWave object, which should be a component
            // of enemies parent
            wave = transform.parent.GetComponent<EnemyWave>();
            // Set direction of the wave
            wave.SetDirectionDown();
        }
        else if (other.tag == "BottomWall")
        {
            // If collided with the right wall, get a reference
            // to the EnemyWave object, which should be a component
            // of enemies parent
            wave = transform.parent.GetComponent<EnemyWave>();
            // Set direction of the wave
            wave.SetDirectionUp();
        }
        else
        {
            // Collision with something that is not a wall
            // Check if collided with a projectile
            // A projectile has a Projectile script component,
            // so try to get a reference to that component
            Projectile projectile = other.GetComponent<Projectile>();

            //If that reference is not null, then check if it's an enemyProjectile      
            if (projectile != null && !projectile.enemyProjectile)
            {
                // Collided with non enemy projectile (so a player projectile)

                // Destroy the projectile game object
                Destroy(other.gameObject);

                // Report enemy hit to the game master
                GameMaster.EnemyHit(this);

                Transform explosion = Instantiate(explosionPrefab);
                explosion.parent = transform.parent.parent;
                explosion.position = transform.position;

                // Destroy self
                Destroy(gameObject);
            }
        }
    }
}