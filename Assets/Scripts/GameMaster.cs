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

    // Method to call when enemy is hit
    public static void EnemyHit(Alien alien)
    {
        // Add enemy points to player's score
        playerScore += alien.points;
    }

    // Method to call when player is hit
    public static void PlayerHit()
    {
        playerHealth--;
        // Reduce player's lives
        if (playerHealth > 0)
        {
            // If more lives left, then reload the
            // level 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}