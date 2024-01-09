using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
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
        GUI.color = Color.white;
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUI.skin.label.fontSize = 40;
        GUI.skin.label.fontStyle = FontStyle.Bold;
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Press any key to start");
    }
}