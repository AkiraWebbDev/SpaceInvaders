using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    // Variable pointing to the object prefab
    public Transform alienPrefab;

    // Speed of the wave movement
    public float speed;

    // Direction of the wave movement (-ve means left, +ve means right)
    public int direction = -1;

    // Start is called before the first frame update
    void Start()
    {
        BlockFormation();
    }

    void Update()
    {
        transform.Translate(new Vector3(0, Time.deltaTime * direction * speed, 0));
    }

    // Method for changing wave direction (to be invoked
    // from a collider)
    public void SetDirectionUp()
    {
        // Check if the current direction is to the right
        if (direction == -1)
        {
            // Changing the direction
            // push the wave down a bit as well
            direction = 1;
            transform.Translate(new Vector3(-0.4f, 0, 0));
        }
    }

    // Method for changing wave direction (to be invoked
    // from a collider)
    public void SetDirectionDown()
    {
        // Check if the current direction is to the left
        if (direction == 1)
        {
            // Changing the direction
            // push the wave down a bit as well
            direction = -1;
            transform.Translate(new Vector3(-0.4f, 0, 0));
        }
    }

    public void BlockFormation()
    {
        float gapBetweenAliens = 1.5f;

        for (int y = 0; y < 6; y++)
        {
            float offsetX = ((y % 2 == 0) ? 0.0f : 0.5f) * gapBetweenAliens;
            for (int x = -2; x < 1; ++x)
            {
                // Create new game object (from prefab)
                Transform alien = Instantiate(alienPrefab);
                alien.parent = transform;
                // Position the newly create object int he wave
                alien.localPosition = new Vector3((x * gapBetweenAliens) + offsetX, 0 + (y * gapBetweenAliens), 0);
            }
        }
    }

}
