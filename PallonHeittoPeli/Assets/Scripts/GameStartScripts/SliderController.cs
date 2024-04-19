using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    // Reference to the Slider UI component
    public Slider slider;

    // Reference to the script containing the dragDistanceMultiplier variable
    LaunchableObject scriptWithVariable;
    private float defaultDragDistanceMultiplier = 50f;

    private void Start()
    {
        slider.value = defaultDragDistanceMultiplier;
        float savedValue = PlayerPrefs.GetFloat("DragDistanceMultiplier", defaultDragDistanceMultiplier);
        slider.value = savedValue;
        scriptWithVariable = GetComponent<LaunchableObject>();
    }

    private void Update()
    {
       OnSliderValueChanged();  
    }
    // Function called when the slider value changes
    public void OnSliderValueChanged()
    {
        // Update the dragDistanceMultiplier variable with the slider's value
        PlayerPrefs.SetFloat("DragDistanceMultiplier", slider.value);
    }
}
