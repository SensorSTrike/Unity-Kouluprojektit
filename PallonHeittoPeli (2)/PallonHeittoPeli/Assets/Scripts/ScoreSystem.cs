using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System; // Import TextMeshPro namespace

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI playerScore; // Change the field type to TextMeshProUGUI
    [SerializeField]


    private int score = 0; // Initialize score to zero
    public int BallsLeft = 5; // Maximum number of balls allowed in the game

    public void UpdateRemainingBalls()
    {
        BallsLeft--;
        UpdateScoreDisplay();   
    }

    // Method to update the score with a specified number of points
    public void UpdateScore(int points)
    {
        score += points; // Add the specified points to the score
        UpdateScoreDisplay(); // Update the score display
    }

    // Method to update the score display
    private void UpdateScoreDisplay()
    {
        if (playerScore != null)
        {
            playerScore.text = "Player Score: " + score.ToString() + " " + "Balls Left = " + BallsLeft.ToString(); // Update the text of the TextMeshProUGUI component with the new score
        }
    }
}
