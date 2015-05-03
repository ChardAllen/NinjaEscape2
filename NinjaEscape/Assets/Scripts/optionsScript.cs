using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class optionsScript : MonoBehaviour {

    public Slider volumeSlide;

    public void Sliding()
    {
        GameObject temp = GameObject.Find("Volume Slide");
        volumeSlide = temp.GetComponent<Slider>();
        AudioListener.volume.Equals(volumeSlide.normalizedValue);
        volumeSet._masterVolume = volumeSlide.normalizedValue;
    }

    public void OnApply()
    {
        AudioListener.volume.Equals(volumeSlide.normalizedValue);
        volumeSet._masterVolume = volumeSlide.normalizedValue;
    }

}
