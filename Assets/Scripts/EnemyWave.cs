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
        SpawnRandomFormation();
    }

    void Update()
    {
        transform.Translate(new Vector3(0, Time.deltaTime * direction * speed, 0));
    }


    /* Spawns a random one of the following formations of aliens.
        BlockFormation();
        TriangleFormation();
        CircleFormation();
        ZigZagFormation();
    */
    private void SpawnRandomFormation()
    {
        int randNum = Random.Range(0, 4);

        switch (randNum)
        {
            case 0:
                BlockFormation();
                break;
            case 1:
                TriangleFormation();
                break;
            case 2:
                CircleFormation();
                break;
            case 3:
                ZigZagFormation();
                break;
            default:
                BlockFormation();
                break;
        }
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

    // Method spawns aliens in a block like formation, with slight offset.
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

    // Method spawns aliens in a triangular formation.
    public void TriangleFormation()
    {
        float gapBetweenAliens = 1.3f;

        for (int x = 0; x < 6; x++)
        {
            float offsetY = ((x % 2 == 0) ? 0.5f : 0.0f) * gapBetweenAliens;

            int y = (x % 2 == 0) ? -x / 2 : -x / 2 - 1;
            for (; y <= x / 2; y++)
            {
                // Create new game object (from prefab)
                Transform alien = Instantiate(alienPrefab);
                alien.parent = transform;

                // Position the newly create object int he wave
                alien.localPosition = new Vector3((x * gapBetweenAliens), 0 + (y * gapBetweenAliens) - offsetY, 0);
            }
        }

    }

    // This method  was written by google bard, prompted with square and
    // triangle layouts and asked for a filled circle formation,
    // and it did the trick!
    public void CircleFormation()
    {
        int numCircles = 2;
        int aliensPerCircle = 10;

        float radius = 3f;
        for (int circle = 0; circle < numCircles; circle++)
        {
            float currentRadius = radius * (1f - (circle / (float)numCircles));
            float angleIncrement = 360f / aliensPerCircle;

            for (int i = 0; i < aliensPerCircle ; i++)
            {
                float angle = i * angleIncrement;
                float x = Mathf.Cos(angle * Mathf.Deg2Rad) * currentRadius;
                float y = Mathf.Sin(angle * Mathf.Deg2Rad) * currentRadius;

                // Create and position the alien
                Transform alien = Instantiate(alienPrefab);
                alien.parent = transform;
                alien.localPosition = new Vector3(x, y, 0);
            }
        }
    }

    // Method spawns aliens in a zig-zag formation.
    public void ZigZagFormation()
    {
        float gapBetweenAliens = 1.5f;
        int alienCount = 13;
        int yCoordUpperBound = 2;
        int yCoordLowerBound = -2;
        float yDirection = 1;
        float y = 0;
        float x = 0;
        while (alienCount > 0)
        {
            float offsetX = ((y % 2 == 0) ? 0.0f : 0.25f) * gapBetweenAliens;
            // Create new game object (from prefab)
            Transform alien = Instantiate(alienPrefab);
            alien.parent = transform;
            // Position the newly create object int he wave
            alien.localPosition = new Vector3((x * gapBetweenAliens), 0 + (y * gapBetweenAliens), 0);
            
            if (y >= yCoordUpperBound)
            {
                yDirection = -0.5f;
            }
            else if (y <= yCoordLowerBound)
            {
                yDirection = 0.5f;
            }

            x += 0.5f;
            y += yDirection;
            alienCount--;
        }

    }

}
