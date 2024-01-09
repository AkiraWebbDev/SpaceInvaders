using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaster : MonoBehaviour
{

    // Variables referencing two edge colliders
    public EdgeCollider2D topWall;
    public EdgeCollider2D bottomWall;

    // Use this for initialization
    void Start()
    {
        SetBoundries();
    }

    void SetBoundries()
    {
        // Get the width and height of the camera (in pixels)
        float screenW = Camera.main.pixelWidth;
        float screenH = Camera.main.pixelHeight;

        // Create an array consisting of two Vector2 objects
        Vector2[] topEdgePoints = new Vector2[2];
        Vector2[] bottomEdgePoints = new Vector2[2];

        // Convert screen coordinates point (0,0) to world coordinates
        Vector3 leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
        // Convert screen coordinates point (0,H) to world coordinates
        Vector3 leftTop = Camera.main.ScreenToWorldPoint(new Vector3(0f, screenH, 0f));
        // Convert screen coordinates point (W,0) to world coordinates
        Vector3 rightBottom = Camera.main.ScreenToWorldPoint(new Vector3(screenW, 0f, 0f));
        // Convert screen coordinates point (W,H) to world coordinates
        Vector3 rightTop = Camera.main.ScreenToWorldPoint(new Vector3(screenW, screenH, 0f));

        // Set the top edge points
        topEdgePoints[0] = leftTop;
        topEdgePoints[1] = rightTop;

        // Set the bottome edge points
        bottomEdgePoints[0] = leftBottom;
        bottomEdgePoints[1] = rightBottom;

        // Position the top wall edge collider
        // at the top edge of the camera
        topWall.points = topEdgePoints;

        // Position the bottom wall edge collider
        // at the bottom edge of the camera
        bottomWall.points = bottomEdgePoints;
    }

    // HUD
    void OnGUI()
    {
        // Show player score in white on the top left of the screen
        GUI.color = Color.white;
        GUI.skin.label.alignment = TextAnchor.UpperLeft;
        GUI.skin.label.fontSize = 40;
        GUI.skin.label.fontStyle = FontStyle.Bold;
        GUI.Label(new Rect(20, 20, 500, 100), "Score: " + GameMaster.playerScore);

        // Show the player lives in red on the top right of the screen
        GUI.color = Color.red;
        GUI.skin.label.alignment = TextAnchor.UpperRight;
        GUI.skin.label.fontSize = 40;
        GUI.skin.label.fontStyle = FontStyle.Bold;
        GUI.Label(new Rect(Screen.width - 320, 20, 300, 100), "Lives: " + GameMaster.playerHealth);
    }
}