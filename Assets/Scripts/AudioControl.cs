using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    [SerializeField] private AudioMixer audiocontroller;

    public void MasterVolumeControl(float sliderValue)
    {
        audiocontroller.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
    }
    public void MusicVolumeControl(float sliderValue)
    {
        audiocontroller.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SoundVolumeControl(float sliderValue)
    {
        audiocontroller.SetFloat("SoundVol", Mathf.Log10 (sliderValue) * 20);
    }
}
