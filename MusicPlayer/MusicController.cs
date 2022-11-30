using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bgm;
    public Slider slider;

    public TextMeshProUGUI volume_value; // 0-1之间
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("prefered_volume"))
        {
            LoadPreferedVolume();
        }
        else
        {
            slider.value = (float)0.1;
        }
    }
    public void SetVolume()
    {
        AudioListener.volume = slider.value;
        volume_value.text = ((int)(100*slider.value)).ToString();
    }

    public void LoadPreferedVolume()
    {
        slider.value = PlayerPrefs.GetFloat("prefered_volume");
    }
    
    public void SavePreferedVolume()
    {
        PlayerPrefs.SetFloat("prefered_volume", slider.value);
    }
    
    public void PlayMusic()
    {
        audioSource.clip = bgm;
        audioSource.Play();
    }
    
    public void PauseMusic()
    {
        audioSource.clip = bgm;
        audioSource.Pause();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
