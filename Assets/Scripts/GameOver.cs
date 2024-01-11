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
        GUI.skin.label.fontSize = 40;
        GUI.skin.label.fontStyle = FontStyle.Bold;
        GUI.Label(new Rect(0, Screen.height / 4f, Screen.width, 70), "Game over");

        string message;

        // Check player's lives left...if more than 0,
        // then player won, otherwise the game was lost   
        // Generate appropriate final message
        if (GameMaster.playerHealth <= 0)
        {
            // The lost message will be shown in red
            message = "You lost :(";
            GUI.color = Color.red;
        }
        else
        {
            // The won message will be shown in white
            message = "You won!!!";
            GUI.color = Color.white;
        }
        // Show lost/won message
        GUI.Label(new Rect(0, Screen.height / 4f + 80f, Screen.width, 70), message);

        GUI.color = Color.white;
        GUI.Label(new Rect(0, Screen.height / 4f + 240f, Screen.width, 70), "Press 'return' to continue...");
    }
}