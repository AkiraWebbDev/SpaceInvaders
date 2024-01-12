using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    // Static variables - there's only one instance
    // of this variable for the entire game.

    // Player score and stats
    public static int playerScore = 0;
    public static int enemiesDestroyed = 0;
    public static int distanceTravelled = 0;

    public static int playerSpeed = 4;
    public static float shotCooldown = 0.8f;
    // Player health - always start with 3 lives
    public static int playerHealth = 3;

    public static int currentPlayerLevel = 1;
    public static float scoreToLevel = 500;
    public static float currentXP = 0;

    public static string lastUpgrade;

    // Method to call when enemy is hit
    public static void EnemyHit(Alien alien)
    {
        // Add enemy points to player's score
        playerScore += alien.points;
        currentXP += alien.points;
        enemiesDestroyed += 1;
        CheckXp();
    }

    public static void DartHit(Dart dart)
    {
        playerScore += dart.points;
        currentXP += dart.points;
        enemiesDestroyed += 1;
        CheckXp();
    }

    public static void CheckXp()
    {
        ProgressBar xpBar;
        xpBar = GameObject.Find("ProgressBar").GetComponent<ProgressBar>();

        if (currentXP >= scoreToLevel)
        {
            scoreToLevel = scoreToLevel * 1.4f;
            currentXP = 0;
            currentPlayerLevel += 1;
            RandomUpgrade();
        }

        float percentXP = currentXP / scoreToLevel;
        xpBar.IncrementProgress(percentXP);
    }


    public static void RandomUpgrade()
    {
        int upgrade = (int)Random.Range(1, 9);

        print(upgrade);

        switch (upgrade)
        {
            case 1:
            case 2:
                shotCooldown -= (shotCooldown * 0.10f);
                lastUpgrade = "+10% fire rate";
                break;
            case 3:
                shotCooldown -= (shotCooldown * 0.20f);
                lastUpgrade = "+20% fire rate";
                break;

            case 4:
            case 5:
            case 6:
                playerSpeed += 2;
                lastUpgrade = "+2 speed";
                break;

            case 7:
                playerSpeed += 3;
                shotCooldown -= (shotCooldown - 0.30f);
                lastUpgrade = "+3 speed & +30% fire rate";
                break;

            default:
                playerHealth += 1;
                lastUpgrade = "+1 health";
                break;
        }
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