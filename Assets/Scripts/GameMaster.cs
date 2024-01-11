using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    // Static variables - there's only one instance
    // of this variable for the entire game

    // Player health - always start with 3 lives
    public static int playerHealth = 3;
    // Player score
    public static int playerScore = 0;

    public static int enemiesDestroyed = 0;

    public static int distanceTravelled = 0;


    public static int playerSpeed = 5;
    public static float rateOfFire = 1;

    // Method to call when enemy is hit
    public static void EnemyHit(Alien alien)
    {
        // Add enemy points to player's score
        playerScore += alien.points;
        enemiesDestroyed += 1;
    }

    public static void DartHit(Dart dart)
    {
        playerScore += dart.points;
        enemiesDestroyed += 1;

    }

    // Method to call when player is hit
    public static void PlayerHit()
    {
        playerHealth--;

        if (playerHealth <= 0)
        {
            distanceTravelled = (int)((Time.realtimeSinceStartup * 75) / 1000);
            SceneManager.LoadScene("GameOver");
        }
    }

    IEnumerator GameOverLoad()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameOver");
    }
}