using UnityEngine;
using UnityEngine.UI;

public class LaunchableObject : MonoBehaviour
{
    public GameObject arrowPrefab; // Prefab of the arrow
    private GameObject arrow; // Reference to the instantiated arrow
    private Vector3 initialMousePosition;
    private Rigidbody rb;
    private float launchForce = 0f; // Initial launch force
    private float MaxLaunchForce = 28.0f;
    public Slider launchSlider; // Reference to the slider UI component
    private bool isDragging = false;
    private BallCollision ballCollision;
    public float dragDistanceMultiplier; // Adjust this multiplier to control drag distance

    void Start()
    {
        dragDistanceMultiplier = PlayerPrefs.GetFloat("DragDistanceMultiplier", 50f);
        rb = GetComponent<Rigidbody>();
        // Ensure slider value matches initial launch force
        ballCollision = GetComponent<BallCollision>(); // Assign BallCollision component
        launchSlider = FindObjectOfType<Slider>();
        UpdateSliderValue();
    }

    void OnMouseDown()
    {
        initialMousePosition = Input.mousePosition;
        // Instantiate the arrow above the object
        arrow = Instantiate(arrowPrefab, transform.position + Vector3.up * 1f, Quaternion.identity);
    }

    public void OnMouseDrag()
    {
        // Normalize drag distance based on screen DPI or resolution
        float dragDistance = (Input.mousePosition - initialMousePosition).magnitude / Screen.dpi;

        // Scale the drag distance to adjust launch force
        float scaledDragDistance = dragDistance * dragDistanceMultiplier;

        // Check if drag distance has changed significantly or if it's the initial drag
        if (Mathf.Abs(scaledDragDistance - launchForce / 50f) > 0.1f || !isDragging)
        {
            launchForce = Mathf.Clamp(scaledDragDistance * 50f * Time.deltaTime, 0f, MaxLaunchForce);
            isDragging = true;
            UpdateSliderValue(); // Update slider value as drag continues
        }

        // Calculate the angle based on the direction of the drag
        Vector3 launchDirection = -(Input.mousePosition - initialMousePosition);
        float angle = Mathf.Atan2(launchDirection.y, launchDirection.x) * Mathf.Rad2Deg + 180f;

        // Adjust the rotation of the arrow based on the angle
        arrow.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void OnMouseUp()
    {
        isDragging = false; // Reset dragging state when mouse is released
        // Use launchForce for launching object
        Vector3 launchDirection = -(Input.mousePosition - initialMousePosition).normalized;
        rb.AddForce(launchDirection * launchForce, ForceMode.Impulse);

        // Set angular velocity for rotation
        float rotationSpeedX = 800f; // Adjust the rotation speed as needed
        Vector3 rotationAxisX = Vector3.Cross(Vector3.up, launchDirection).normalized; // Calculate the rotation axis
        rb.angularVelocity = rotationAxisX * rotationSpeedX * Time.deltaTime; // Apply angular velocity
        
        float rotationSpeedY = 800f; // Adjust the rotation speed as needed
        Vector3 rotationAxisY = Vector3.up; // Rotate around the y-axis
        rb.angularVelocity += rotationAxisY * rotationSpeedY * Time.deltaTime; // Apply angular velocity for sideways rotation

        launchForce = 0f; // Reset launch force after launch
        rb.velocity = Vector3.zero; // Stop the object's movement
        UpdateSliderValue(); // Update slider value after launch
        // Destroy the arrow when the user releases the mouse
        Destroy(arrow);
        ballCollision.MarkLaunched();
        Debug.Log("dragDistanceMultiplier value = " + dragDistanceMultiplier);
    }

    void UpdateSliderValue()
    {
        if (launchSlider != null)
        {
            // Update the slider value based on the launch force
            launchSlider.value = launchForce / MaxLaunchForce;
        }
    }
}
