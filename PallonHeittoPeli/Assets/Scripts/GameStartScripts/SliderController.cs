using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    // Reference to the Slider UI component
    public Slider slider;

    // Default value for the slider
    private float defaultDragDistanceMultiplier = 50f;
    public static float sliderValue;
    public float savedValue; 

    private void Start()
    {
        slider.value = GetComponent<LaunchableObject>().dragDistanceMultiplier;  //unohdin tämän
        // Get the saved value from PlayerPrefs
        savedValue = PlayerPrefs.GetFloat("DragDistanceMultiplier", sliderValue);
        // If the saved value is exactly 0, set the slider to the default value
        if (savedValue == 0f)
        {
            slider.value = defaultDragDistanceMultiplier;
        }
        else
        {
            // Otherwise, set the slider to the saved value
            slider.value = savedValue;
        }
    }

    // Function called when the slider value changes
    public void OnSliderValueChanged()
    {
        // Update the dragDistanceMultiplier variable with the slider's value
        PlayerPrefs.SetFloat("DragDistanceMultiplier", slider.value);
        PlayerPrefs.Save();       
    }
}
