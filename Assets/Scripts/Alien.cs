using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{

    // When enemy collides with an object with a
    // collider that is a trigger...
    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyWave wave;

        // Check if colliding with the left or right wall
        // (by checking the tags of the collider that the enemy
        //  collided with)
        if (other.tag == "LeftWall")
        {
            // If collided with the left wall, get a reference
            // to the EnemyWave object, which should be a component
            // of enemies parent
            wave = transform.parent.GetComponent<EnemyWave>();
            // Set direction of the wave
            wave.SetDirectionRight();
        }
        else if (other.tag == "RightWall")
        {
            // If collided with the right wall, get a reference
            // to the EnemyWave object, which should be a component
            // of enemies parent
            wave = transform.parent.GetComponent<EnemyWave>();
            // Set direction of the wave
            wave.SetDirectionLeft();
        }
    }
}