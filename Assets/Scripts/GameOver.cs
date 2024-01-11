using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown("return") || Input.GetKeyDown("enter"))
        {
            // Go back to the main menu
            SceneManager.LoadScene("MainMenu");
        }
    }

    // Display game over message
    void OnGUI()
    {

        // Show player score in white on the top left of the screen
        GUI.color = Color.white;
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUI.skin.label.fontSize = 50;
        GUI.skin.label.fontStyle = FontStyle.Bold;
        GUI.Label(new Rect(0, Screen.height / 4f - 80f, Screen.width, 70), "Game over!");

        GUI.skin.label.fontSize = 40;
        GUI.Label(new Rect(0, Screen.height / 4f + 300f, Screen.width, 70), "Press 'return' to continue...");

        GUI.skin.label.fontSize = 35;
        GUI.Label(new Rect(0, Screen.height / 4f + 40f, Screen.width, 70), "Stats:");

        GUI.skin.label.fontSize = 30;
        GUI.skin.label.alignment = TextAnchor.MiddleLeft;

        string scoreMessage = "Score: " + GameMaster.playerScore;
        string killsMessage = "Kills: " + GameMaster.enemiesDestroyed;
        string distanceMessage = "Distance: " + GameMaster.distanceTravelled + "km";

        GUI.Label(new Rect(250f, Screen.height / 4f + 80f, Screen.width, 70), scoreMessage);
        GUI.Label(new Rect(250f, Screen.height / 4f + 120f, Screen.width, 70), killsMessage);
        GUI.Label(new Rect(250f, Screen.height / 4f + 160f, Screen.width, 70), distanceMessage);



    }
}