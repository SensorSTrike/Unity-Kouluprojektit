using UnityEngine;
using System.Collections;

public class BallCollision : MonoBehaviour
{
    // Reference to the GameController or ScoreSystem script to update the score
    [SerializeField]
    private ScoreSystem scoreController;
    [SerializeField]
    private GameManager gameManager;

    private bool hasCollidedWithGround = false;
    private bool hasBeenLaunched = false;

    private void Start()
    {
        scoreController = FindObjectOfType<ScoreSystem>();
        if (scoreController == null)
        {
            Debug.LogError("ScoreSystem not found in the scene!");
        }
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (hasBeenLaunched)
        {
            StartCoroutine(DestroyBallWithDelay());
        }

        // Check if the collision is with a plate
        if (collision.gameObject.CompareTag("Plate100"))
        {
            scoreController.UpdateScore(100);
            DestroyBallWithDelay();

        }
        else if (collision.gameObject.CompareTag("Plate300"))
        {
            scoreController.UpdateScore(300);
            DestroyBallWithDelay();
        }
        else if (collision.gameObject.CompareTag("Plate500"))
        {
            scoreController.UpdateScore(500);
            DestroyBallWithDelay();
        }
        // Check if the collision is with the ground
        else if (collision.gameObject.CompareTag("Ground") && hasBeenLaunched)
        {
            // Check if the ball has already collided with the ground
            if (!hasCollidedWithGround)
            {
                // Set the flag to true to indicate that the ball has collided with the ground
                hasCollidedWithGround = true;

                // Destroy the ball
                DestroyBallWithDelay();
            }
        }
    }
    private IEnumerator DestroyBallWithDelay()
    {
        float destroyDelay = 1.0f; // Adjust the delay as needed (in seconds)
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
        gameManager.RespawnBall();
        scoreController.UpdateRemainingBalls();
    }

    // Method to mark the ball as launched
    public void MarkLaunched()
    {
        hasBeenLaunched = true;
    }
}
