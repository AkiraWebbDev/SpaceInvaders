using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            // Start the new game

            // Reset the player lives and
            // score
            GameMaster.playerHealth = 3;
            GameMaster.playerScore = 0;
            // Load the first level
            SceneManager.LoadScene("Level1");
        }
    }

    // Display main menu message
    void OnGUI()
    {
        GUI.color = Color.cyan;
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUI.skin.label.fontSize = 50;
        GUI.skin.label.fontStyle = FontStyle.Bold;
        GUI.Label(new Rect(0, -150, Screen.width, Screen.height), "Space Invaders Ultra 5000");

        GUI.color = Color.magenta;
        GUI.skin.label.fontSize = 30;
        GUI.Label(new Rect(0, -110, Screen.width, Screen.height), "By Luke Webb");

        GUI.color = Color.white;
        GUI.skin.label.fontSize = 20;
        GUI.Label(new Rect(0, 20, Screen.width, Screen.height), "WASD or Arrow keys to move, Space to shoot.");
        GUI.Label(new Rect(0, 50, Screen.width, Screen.height), "Survive for as long as possible!");

        GUI.color = Color.cyan;
        GUI.color = Color.white;
        GUI.skin.label.fontSize = 40;
        GUI.Label(new Rect(0, 150, Screen.width, Screen.height), "Press Space to start");
    }
}