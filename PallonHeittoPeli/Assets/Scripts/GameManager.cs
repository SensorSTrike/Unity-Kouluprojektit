using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab; // Prefab of the ball
    public Transform ballSpawnPoint; // Transform representing the spawn point of the ball
    public CinemachineVirtualCamera virtualCamera; // Reference to the Cinemachine virtual camera
    private GameObject currentBall; // Reference to the current ball GameObject
    private int ballsSpawned = 0; // Number of balls spawned
    
    
    void Start()
    {
        SpawnBall();
    }

    void SpawnBall()
    {
        if (ballsSpawned < 5)
        {
            // Instantiate a new ball at the spawn point
            currentBall = Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);
            ballsSpawned++;
            virtualCamera.Follow = currentBall.transform;
            virtualCamera.LookAt = currentBall.transform;
        }
        else
        {
            Debug.Log("Maximum number of balls reached. Game over.");
            LoadGameEnd();
        }
    }

    public void RespawnBall()
    {
        // Destroy the current ball
        Destroy(currentBall);

        // Spawn a new ball at the spawn point
        SpawnBall();

        // Move the virtual camera to focus on the new ball
        virtualCamera.Follow = currentBall.transform;
    }

    public void LoadGameEnd()
    {
        SceneManager.LoadScene("PelinLoppu");
        float savedValue = PlayerPrefs.GetFloat("DragDistanceMultiplier", SliderController.sliderValue);
        Debug.Log("Slider value at game end: " + savedValue);
    }
}
