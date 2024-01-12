using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            // Go back to the main menu
            SceneManager.LoadScene("MainMenu");
        }
    }

    // Display game over message
    void OnGUI()
    {

        // Show player score in white on the top left of the screen
        GUI.color = Color.cyan;
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUI.skin.label.fontSize = 50;
        GUI.skin.label.fontStyle = FontStyle.Bold;
        GUI.Label(new Rect(0, Screen.height / 4f - 80f, Screen.width, 70), "Game over!");

        GUI.skin.label.fontSize = 40;
        GUI.Label(new Rect(0, Screen.height / 4f + 340f, Screen.width, 70), "Press 'tab' to continue...");

        GUI.skin.label.fontSize = 35;
        GUI.Label(new Rect(0, Screen.height / 4f + 40f, Screen.width, 70), "Stats:");


        string scoreMessage = "Score: " + GameMaster.playerScore;
        string killsMessage = "Destroyed drones: " + GameMaster.enemiesDestroyed;
        string distanceMessage = "Distance: " + GameMaster.distanceTravelled + "km";
        string levelMessage = "Level Reached: " + GameMaster.currentPlayerLevel;
        string speedReached = "Speed: " + GameMaster.playerSpeed;
        string rateOfFire = "Fire rate: " + ((1 / GameMaster.shotCooldown) * 60) + "/min";


        GUI.color = Color.white;
        GUI.skin.label.fontSize = 20;
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;

        GUI.Label(new Rect(0, Screen.height / 4f + 80f, Screen.width, 70), scoreMessage);
        GUI.Label(new Rect(0, Screen.height / 4f + 110f, Screen.width, 70), killsMessage);
        GUI.Label(new Rect(0, Screen.height / 4f + 140f, Screen.width, 70), distanceMessage);
        GUI.Label(new Rect(0, Screen.height / 4f + 170f, Screen.width, 70), levelMessage);
        GUI.Label(new Rect(0, Screen.height / 4f + 200f, Screen.width, 70), speedReached);
        GUI.Label(new Rect(0, Screen.height / 4f + 230f, Screen.width, 70), rateOfFire);






    }
}