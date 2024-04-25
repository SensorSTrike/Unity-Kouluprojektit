using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerVolumeControl : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider volumeSlider;

    public void SetMasterVolume(float volume)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }
}
