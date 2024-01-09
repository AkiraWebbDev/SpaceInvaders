using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    // Variable pointing to the object prefab
    public Transform alienPrefab;

    // Start is called before the first frame update
    void Start()
    {
        float gapBetweenAliens = 1.5f;

        for(int y = 0; y < 4; y++)
        {
            float offsetX = ((y % 2 == 0) ? 0.0f : 0.5f) * gapBetweenAliens;
            for(int x = -3; x < 3; ++x)
            {
                //Create new game object (from prefab)
                Transform alien = Instantiate(alienPrefab);
                alien.parent = transform;
                // Position the newly create object int he wave
                alien.localPosition = new Vector3((x * gapBetweenAliens) + offsetX, 0 + (y * gapBetweenAliens), 0);
            }
        }
    }
}
