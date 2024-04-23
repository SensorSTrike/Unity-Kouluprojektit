using UnityEngine;
using UnityEngine.SceneManagement;

public class Backtomenubutton : MonoBehaviour
{
    public void BackToMenu()
    {
        
        float savedvalue = PlayerPrefs.GetFloat("DragDistanceMultiplier", SliderController.sliderValue);
        Debug.Log( "dragdistance multiplier value = " + savedvalue);
        SceneManager.LoadScene("PelinAlku");
    }
}
