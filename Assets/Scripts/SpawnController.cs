using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public GameObject alienDartPrefab;
    public GameObject alienWavePrefab;

    public int budget = 2;

    private bool stopSpawning = false;

    public bool waveActive = false;

    private void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
        StartCoroutine("SpawnEnemyRoutine");
        StartCoroutine("SpawnWaveRoutine");

    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (stopSpawning == false)
        {
            if (budget > 0)
            {
                GameObject newEnemy = Instantiate(alienDartPrefab, new Vector3(8f, Random.Range(-4.5f, 4.5f), -2f), Quaternion.identity);
                budget--;
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return new WaitForSeconds(5.0f);
                budget = (int)(Time.realtimeSinceStartup/5);
          
            }

        }
    }


    IEnumerator SpawnWaveRoutine()
    {
        while (stopSpawning == false)
        {
            yield return new WaitForSeconds(20f);
            GameObject newEnemy = Instantiate(alienWavePrefab, new Vector3(8f, 0, -2f), Quaternion.identity);
            newEnemy.transform.parent = transform.parent;
        }

    }

}
